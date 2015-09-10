using System.Collections.Generic;

namespace GeoSharp
{
    // ReSharper disable once InconsistentNaming
    public class GeoInfoPRCImpl:GeoInfoBase
    {
        private static readonly GeoSharpIndexSqlCeImpl IndexSqlCeImpl=new GeoSharpIndexSqlCeImpl();
        /// <summary>
        /// Codes for the administrative divisions of the People's Republic of China
        /// </summary>
        public int Id { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public static IEnumerable<GeoInfoPRCImpl>Find(int id)
        {
            return IndexSqlCeImpl.Find(id);
        }

        public static IEnumerable<GeoInfoPRCImpl> Find(string geoName)
        {
            return IndexSqlCeImpl.Find(geoName);
        } 
    }
}