using System;
using System.Collections.Generic;

namespace GeoSharp.SqlCeImpl
{
    public class GeoSharpIndexSqlCeImpl:IGeoSharpIndex,IDisposable
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

        #region Implementation of IGeoSharpIndex

        public IEnumerable<T> Find<T>(T t,int id) where T : GeoInfoBase
        {
            //return FindSqlCe(id) as IEnumerable<T>;
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find<T>(T t, string geoName) where T : GeoInfoBase
        {
            //return FindSqlCe(geoName) as IEnumerable<T>;
            throw new NotImplementedException();
        }

        #endregion
    }
}