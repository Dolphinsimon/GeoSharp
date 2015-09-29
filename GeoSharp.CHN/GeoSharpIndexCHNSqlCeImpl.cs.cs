using System;
using System.Collections.Generic;
using System.Linq;
using GeoSharp.SqlCeImpl;

namespace GeoSharp.CHN
{
    public class GeoSharpIndexSqlCeImpl : IGeoSharpIndex, IDisposable
    {
        private readonly GeoSharpSQLCEEntities _entities;

        public GeoSharpIndexSqlCeImpl()
        {
            _entities = new GeoSharpSQLCEEntities();
        }

        public GeoSharpIndexSqlCeImpl(GeoSharpSQLCEEntities entities)
        {
            _entities = entities;
        }
        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() => _entities.Dispose();


        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private IEnumerable<GeoInfoPRCImpl> FindSqlCe(int id)
            => _entities.ISO3166_2_156.Where(a => a.Id == id).Select(b => new GeoInfoPRCImpl
            {
                City = b.City,
                District = b.District,
                Id = b.Id,
                Province = b.Province
            }).ToList();


        private IEnumerable<GeoInfoPRCImpl> FindSqlCe(string geoName)
            =>
                _entities.ISO3166_2_156.Where(
                    a => a.City.Contains(geoName) || a.Province.Contains(geoName) || a.District.Contains(geoName))
                    .Select(b => new GeoInfoPRCImpl
                    {
                        City = b.City,
                        District = b.District,
                        Id = b.Id,
                        Province = b.Province
                    }).ToList();


        public IEnumerable<GeoInfoPRCImpl> Find(int id)
            => FindSqlCe(id);


        public IEnumerable<GeoInfoPRCImpl> Find(string geoName)
            => FindSqlCe(geoName);


        #region Implementation of IGeoSharpIndex

        IEnumerable<GeoInfoBase> IGeoSharpIndex.Find(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<GeoInfoBase> IGeoSharpIndex.Find(string geoName)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}