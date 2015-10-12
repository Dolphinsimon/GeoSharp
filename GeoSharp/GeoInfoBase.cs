using System.Collections.Generic;

namespace GeoSharp
{
    /// <summary>
    /// The base class for GeoSharp
    /// </summary>
    public abstract class GeoInfoBase:IGeoSharpIndex
    {
        public int Id { get; protected set; }
        public object Value { get; protected set; }

        #region Implementation of IGeoSharpIndex

        public abstract IEnumerable<T> Find<T>(T t, int id) where T : GeoInfoBase;
        public abstract IEnumerable<T> Find<T>(T t, string geoName) where T : GeoInfoBase;

        #endregion
    }

}

