using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace NhiNguyenNamNguyen_Project3
{
    public partial class MainForm : Form
    {
        public static string tickerSymbol;
        public static string companyName;
        public static int startDate;
        public static int endDate;
        public static string period;

        public MainForm()
        {
            InitializeComponent();

            startDatePicker.MaxDate = DateTime.Now;
            endDatePicker.MaxDate = DateTime.Now;

            var reader = new StreamReader(@"SP500.csv");
            List<string> tickers = new List<string>();

            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                tickers.Add(values[0] + " - " + values[1]);
            }

            foreach (var ticker in tickers)
            {
                tickerComboBox.Items.Add(ticker);
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            string[] tickerVal = tickerComboBox.Text.Split('-');
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0);

            tickerSymbol = tickerVal[0].Remove(tickerVal[0].Length - 1, 1);
            companyName = tickerVal[1];
            startDate = Convert.ToInt32((startDatePicker.Value.ToUniversalTime() - epoch).TotalSeconds);
            endDate = Convert.ToInt32((endDatePicker.Value.ToUniversalTime() - epoch).TotalSeconds);
            period = periodComboBox.Text;

            var newStockChart = new StockForm();
            newStockChart.Show();
        }
    }
}
