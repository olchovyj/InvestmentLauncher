using InvestmentLauncher.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestmentLauncher
{
    public class Stock
    {
        string ticker;
        public Stock(string ticker_)
        {
            ticker = ticker_;
        }
    }
}
