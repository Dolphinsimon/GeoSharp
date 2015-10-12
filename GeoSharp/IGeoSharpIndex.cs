using System.Collections.Generic;

namespace GeoSharp
{
    interface IGeoSharpIndex
    {
        IEnumerable<T> Find<T>(T t, int id) where T : GeoInfoBase;
        IEnumerable<T> Find<T>(T t,string geoName) where T: GeoInfoBase;
    }

}