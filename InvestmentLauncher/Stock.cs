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
        public DataTable HistoricalPricesDT(DateTime startDate, DateTime endDate)
        {
            DataTable dt = new DataTable();
            string url = "https://api.tiingo.com/api/test/";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Content-Type:application/json");
            request.Headers.Add("Authorization:Token " + Resources.TiingoKey );
            request.Method = "GET";
            string content = string.Empty;
            using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using(StreamReader sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                    }
                }
            }
            MessageBox.Show(content);
            return dt;
        }
    }
}
