using System.Diagnostics;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeoSharp
{
    [TestClass]
    // ReSharper disable once InconsistentNaming
    public class GeoInfoPRCImplTest
    {
        [TestMethod]
        public void TestFind()
        {
            const int s=110000;
            var t=GeoInfoPRCImpl.Find(s);
            Debug.WriteLine(t.Count());
        }

        [TestMethod]
        public void TestFindString()
        {
            const string s = "徐州";
            var t = GeoInfoPRCImpl.Find(s);
            Debug.WriteLine(t.Count());
        }
    }
}
