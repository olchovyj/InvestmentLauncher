using System;
using System.Data;
using InvestmentLauncher;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InvestmentLauncherTest
{
    [TestClass]
    public class FormStartupTest
    {
        public FormStartupTest()
        {

        }
        [TestMethod]
        public void HistoricalPricesDTTest()
        {
            Stock stk = new Stock("PG");
            Assert.IsInstanceOfType(stk.HistoricalPricesDT(DateTime.Now, DateTime.Now), typeof(DataTable));
                        
        }
    }
}
