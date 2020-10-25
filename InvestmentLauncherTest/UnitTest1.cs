using System;
using InvestmentLauncher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InvestmentLauncherTest
{
    [TestClass]
    public class TiingoTest
    {
        private Tiingo ti;
        public TiingoTest()
        {
            ti = new Tiingo();
        }
        [TestMethod]
        public void GetJSONTest()
        {
            Assert.IsTrue(ti.HistPricesJSON().Length > 10);
        }
    }
}
