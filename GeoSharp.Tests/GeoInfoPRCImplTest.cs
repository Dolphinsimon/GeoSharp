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
            const int s=110000;
            var t=GeoInfoPRCImpl.Find(s);
            Assert.IsNotNull(t);
        }

        [TestMethod]
        public void TestFindString()
        {
            const string s = "徐州";
            var t = GeoInfoPRCImpl.Find(s);
            Assert.IsNotNull(t);
        }
    }
}
