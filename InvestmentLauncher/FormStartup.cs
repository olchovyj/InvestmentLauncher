using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvestmentLauncher
{
    public partial class FormStartup : Form
    {
        public FormStartup()
        {
            InitializeComponent();
            Tiingo ti = new Tiingo();
            DataTable dt = ti.HistPricesDT("PG", Convert.ToDateTime("10/18/20"), Convert.ToDateTime("10/25/20"));
            dataGridView1.DataSource = dt;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
