using GeoSharp.CHN;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeoSharp.Tests
{
    [TestClass]
    // ReSharper disable once InconsistentNaming
    public class GeoInfoPRCImplTest
    {
        [TestMethod]
        public void TestFind()
        {
            var geo = new GeoInfoCHNImpl();
            const int s=110000;
            var t=geo.Find(geo,s);
            Assert.IsNotNull(t);
        }

        [TestMethod]
        public void TestFindString()
        {
            var geo = new GeoInfoCHNImpl();
            const string s = "徐州";
            var t = geo.Find(geo,s);
            Assert.IsNotNull(t);
        }
    }
}
