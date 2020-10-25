using System;
using System.Data;
using InvestmentLauncher;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

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
        [TestMethod]
        public void GetDataTableTest()
        {
            DateTime startDate = Convert.ToDateTime("1/5/2010");
            DateTime endDate = Convert.ToDateTime("1/12/2010");
            DataTable dt = ti.HistPricesDT("PG", startDate, endDate);            
            Assert.IsInstanceOfType(dt,typeof(DataTable));
            Assert.AreEqual(60.44,Convert.ToDouble(dt.Rows[3]["Close"]));
        }



    }
}
