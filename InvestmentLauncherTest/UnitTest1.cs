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
            DateTime startDate = Convert.ToDateTime("1/5/2010");
            DateTime endDate = Convert.ToDateTime("1/12/2010");
            string result = ti.HistPricesJSON("PG", startDate, endDate);
            Console.WriteLine(result);
            Assert.IsTrue(result.Length > 10);
        }
    }
}
