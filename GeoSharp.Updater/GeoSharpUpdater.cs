using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Transactions;

namespace GeoSharp
{
    public class GeoSharpUpdater
    {
        private readonly SortedDictionary<int, string> _geoInfo=new SortedDictionary<int, string>();
        private readonly GeoSharpSQLCEEntities _entities = new GeoSharpSQLCEEntities();

        /// <summary>
        /// Get the total number of rows
        /// </summary>
        /// <param name="filePath">filepath</param>
        /// <returns>An array that contains every row.</returns>
        private static IEnumerable<string> GetRows(string filePath)
        {
            using (var reader = new StreamReader(filePath, Encoding.UTF8))
            {
                return reader.ReadToEnd().Split('\n');
            }
        }

        private static int GetNumber(string text)
        {
            const string pattern = @"\d+";

            var matches = Regex.Matches(text, pattern, RegexOptions.Singleline);    // Split on hyphens
            if (matches.Count != 1) throw new ArgumentOutOfRangeException(text,"Not only one number in this line!");
            return (from Match match in matches select Convert.ToInt32(match.Value)).FirstOrDefault();
        }

        private static string GetText(string text)
        {
            const string pattern = @"[\u4e00-\u9fa5]+";

            var matches = Regex.Matches(text, pattern, RegexOptions.Singleline);    // Split on hyphens
            if (matches.Count != 1) throw new ArgumentOutOfRangeException(text, "Not only one string in this line!");
            return (from Match match in matches select match.Value).FirstOrDefault();
        }

        private void SortGeoInfo(string row)
        {
            if (string.IsNullOrWhiteSpace(row)) return;
            var key = GetNumber(row);
            var value = GetText(row);
            _geoInfo.Add(key, value);
        }

        [SuppressMessage("ReSharper", "InvertIf")]
        private static SortedDictionary<int, string[]> FinalizeGeoInfo(SortedDictionary<int, string> dictionary)
        {
            var geoDic=new SortedDictionary<int,string[]>();
            foreach (var geo in dictionary)
            {
                string temp;
                var tempStrings = new string[3];
                if (geo.Key/10000*10000 == geo.Key)
                {
                    tempStrings[0] = geo.Value;
                    geoDic.Add(geo.Key,tempStrings);
                    continue;
                }
                if (dictionary.TryGetValue(geo.Key/10000*10000, out temp))
                {
                    tempStrings[0] = temp;
                    if (geo.Key/100*100 == geo.Key)
                    {
                        tempStrings[1] = geo.Value;
                        geoDic.Add(geo.Key, tempStrings);
                        continue;
                    }
                    if (dictionary.TryGetValue(geo.Key / 100 * 100, out temp))
                    {
                        tempStrings[1] = temp;
                        tempStrings[2] = geo.Value;
                        geoDic.Add(geo.Key,tempStrings);
                    }
                }

            }
            return geoDic;
        }

        private static SortedDictionary<int, string[]> AddPinyin(SortedDictionary<int, string[]> geoDic)
        {
            foreach (var geo in geoDic)
            {
                for (var i = 0; i < geo.Value.Length; i++)
                {
                    if(geo.Value[i]==null) continue;
                    geo.Value[i] += ChinesePhoneticAlphabetConvert.SerilizeChineseCharacter(geo.Value[i]);
                }
                
            }
            return geoDic;
        }

        private void StoreGeoInfotoSqlCe(SortedDictionary<int, string[]> geoDictionary)
        {
            using (var trans=new TransactionScope())
            {
                foreach (var geoInfo in geoDictionary.Select(geo => new GeoInfoPRCImpl
                {
                    Id = geo.Key,
                    Province = geo.Value[0],
                    City = geo.Value[1],
                    District = geo.Value[2]
                }))
                {
                    _entities.ISO3166_2_156.Add(new ISO3166_2_156
                    {
                        City = geoInfo.City,
                        District = geoInfo.District,
                        Id = geoInfo.Id,
                        Province = geoInfo.Province
                    }); 
                }
                _entities.SaveChanges();
                trans.Complete();
            }
        }

        

        public void Start(string path)
        {
            var rows = GetRows(path);
            foreach (var row in rows)
            {
                SortGeoInfo(row);
            }
            var data=AddPinyin(FinalizeGeoInfo(_geoInfo));
            StoreGeoInfotoSqlCe(data);
        }
    }
}