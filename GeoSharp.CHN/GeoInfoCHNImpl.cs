using System;
using System.Collections.Generic;
using System.Linq;
using GeoSharp.SqlCeImpl;

namespace GeoSharp.CHN
{
    // ReSharper disable once InconsistentNaming
    public class GeoInfoCHNImpl:GeoInfoBase,IDisposable
    {
        /// <summary>
        /// Codes for the administrative divisions of the People's Republic of China
        /// </summary>
        public new object Value => Province + City + District;

        public string Province { get; set; }

        public string City { get; set; }

        public string District { get; set; }
        
        private readonly GeoSharpSQLCEEntities _entities;

        public GeoInfoCHNImpl()
        {
            _entities = new GeoSharpSQLCEEntities();
        }

        public GeoInfoCHNImpl(GeoSharpSQLCEEntities entities)
        {
            _entities = entities;
        }

        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose() => _entities.Dispose();

        #endregion

        public override IEnumerable<T> Find<T>(T t, int id)
            => Find(id) as IEnumerable<T>;

        public override IEnumerable<T> Find<T>(T t, string geoName)
            => Find(geoName) as IEnumerable<T>;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private IEnumerable<GeoInfoCHNImpl> Find(int id)
            => _entities.ISO3166_2_156.Where(a => a.Id == id).Select(b => new GeoInfoCHNImpl
            {
                City = b.City,
                District = b.District,
                Id = b.Id,
                Province = b.Province
            }).ToList();


        private IEnumerable<GeoInfoCHNImpl> Find(string geoName)
            =>
                _entities.ISO3166_2_156.Where(
                    a => a.City.Contains(geoName) || a.Province.Contains(geoName) || a.District.Contains(geoName))
                    .Select(b => new GeoInfoCHNImpl
                    {
                        City = b.City,
                        District = b.District,
                        Id = b.Id,
                        Province = b.Province
                    }).ToList();
    }
}