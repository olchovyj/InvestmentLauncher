using InvestmentLauncher.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestmentLauncher
{
    public class Tiingo
    {
        public Tiingo()
        {

        }

        public string HistPricesJSON(string ticker, DateTime startDate, DateTime endDate)
        {
            string url = "https://api.tiingo.com/tiingo/daily/"+ticker+"/prices?startDate="+startDate.ToString("yyyy-M-d")+"&endDate="+endDate.ToString("yyyy-M-d");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "application/json";
            request.Headers.Add("Authorization:Token " + Resources.TiingoKey);
            request.Method = "GET";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
        public class StockHistoryJSON
        {
            public List<StockJSON> lsj;
            public StockHistoryJSON()
            {
                lsj = new List<StockJSON>();
            }
            public class StockJSON
            {
                public string date;
                public string close;
                public string high;
                public string low;
                public string open;
                public string volume;
                public string adjClose;
                public string adjHigh;
                public string adjLow;
                public string adjOpen;
                public string divCash;
                public string splitFactor;
            }
        }
    }
}
