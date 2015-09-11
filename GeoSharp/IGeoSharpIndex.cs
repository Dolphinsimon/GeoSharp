using System.Collections.Generic;

namespace GeoSharp
{
    public interface IGeoSharpIndex
    {
        IEnumerable<GeoInfoBase> Find(int id);
        IEnumerable<GeoInfoBase> Find(string geoName);
    }

}