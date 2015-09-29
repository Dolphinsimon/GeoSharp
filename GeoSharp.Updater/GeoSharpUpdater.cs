using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Transactions;
using GeoSharp.CHN;
using GeoSharp.SqlCeImpl;

namespace GeoSharp.Updater
{
    public class GeoSharpUpdater
    {
        private readonly SortedDictionary<string, string> _geoInfo=new SortedDictionary<string, string>();
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

        private static string GetNumber(string text)
        {
            const string pattern = @"\d+";

            var matches = Regex.Matches(text, pattern, RegexOptions.Singleline);    // Split on hyphens
            if (matches.Count != 1) throw new ArgumentOutOfRangeException(text,"Not only one number in this line!");
            return (from Match match in matches select match.Value).FirstOrDefault();
        }

        private static string GetText(string text)
        {
            const string pattern = @"\D+";

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


        private void StoreGeoInfotoSqlCe(SortedDictionary<string, string> geoDictionary)
        {
            using (var trans=new TransactionScope())
            {
                foreach (var geoInfo in geoDictionary)
                {
                    _entities.ISO3166_1_NUMERIC.Add(new ISO3166_1_NUMERIC
                    {
                        Id = geoInfo.Key,
                        CountryName = geoInfo.Value
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
            StoreGeoInfotoSqlCe(_geoInfo);
        }
    }
}