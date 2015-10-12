using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Transactions;
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
            using (var reader = new StreamReader(filePath, Encoding.Unicode))
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


        private void SortISO3166_1_NUMERIC(string row)
        {
            if (string.IsNullOrWhiteSpace(row)) return;
            var key = GetNumber(row);
            var value = GetText(row);
            _geoInfo.Add(key, value);
        }

        private void SortISO3166_1_ALPHA_3(string row)
        {
            if (string.IsNullOrWhiteSpace(row)) return;
            var formatRow = row.Replace("\t", "").Replace("\r","");
            var key = formatRow.Substring(0, 3);
            var value = formatRow.Substring(3);
            _geoInfo.Add(key, value);
        }

        private void StoreISO3166_1_NUMERICtoSqlCe(SortedDictionary<string, string> geoDictionary)
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

        private void StoreISO3166_1_ALPHA_3toSqlCe(SortedDictionary<string, string> geoDictionary)
        {
            using (var trans = new TransactionScope())
            {
                foreach (var geoInfo in geoDictionary)
                {
                    _entities.ISO3166_1_ALPHA_3.Add(new ISO3166_1_ALPHA_3
                    {
                        Code = geoInfo.Key,
                        CountryName = geoInfo.Value
                    });
                }
                _entities.SaveChanges();
                trans.Complete();
            }
        }

        

        public void StartISO3166_1_NUMERIC(string path)
        {
            var rows = GetRows(path);
            foreach (var row in rows)
            {
                SortISO3166_1_NUMERIC(row);
            }
            StoreISO3166_1_NUMERICtoSqlCe(_geoInfo);
        }

        public void StaartISO3166_1_ALPHA_3(string path)
        {
            var rows = GetRows(path);
            foreach (var row in rows)
            {
                SortISO3166_1_ALPHA_3(row);
            }
            StoreISO3166_1_ALPHA_3toSqlCe(_geoInfo);
        }
    }
}