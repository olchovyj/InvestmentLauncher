using InvestmentLauncher.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
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

        public DataTable HistPricesDT(string ticker, DateTime startDate, DateTime endDate)
        {
            DataTable dt = new DataTable();
            DataColumn dateCol = dt.Columns.Add("Date");
            DataColumn closeCol = dt.Columns.Add("Close");
            DataColumn highCol = dt.Columns.Add("High");
            DataColumn  lowCol = dt.Columns.Add("Low");
            DataColumn  openCol = dt.Columns.Add("Open");
            DataColumn  volumeCol = dt.Columns.Add("Volume");
            DataColumn  adjCloseCol = dt.Columns.Add("adjClose");
            DataColumn  adjHighCol = dt.Columns.Add("adjHigh");
            DataColumn  adjLowCol = dt.Columns.Add("adjLow");
            DataColumn  adjOpenCol = dt.Columns.Add("adjOpen");
            DataColumn  divCashCol = dt.Columns.Add("divCash");
            DataColumn  splitFactorCol = dt.Columns.Add("splitFactor");
            string jsonOutput = HistPricesJSON(ticker, startDate, endDate);
            StockHistory sh = new StockHistory();
            sh.lh = JsonConvert.DeserializeObject<List<StockHistory.History>>(jsonOutput);
            foreach (StockHistory.History h in sh.lh)
            {
                DataRow dr = dt.Rows.Add();
                dr[dateCol] = h.date;
                dr[closeCol] = h.close;
                dr[highCol] = h.high;
                dr[lowCol] = h.low;
                dr[openCol] = h.open;
                dr[volumeCol] = h.volume;
                dr[adjCloseCol] = h.adjClose;
                dr[adjHighCol] = h.adjHigh;
                dr[adjLowCol] = h.adjLow;
                dr[adjOpenCol] = h.adjOpen;
                dr[divCashCol] = h.divCash;
                dr[splitFactorCol] = h.splitFactor;
            }
            return dt;
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
        public class StockHistory
        {
            public List<History> lh = new List<History>();
            public class History
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
