using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace NhiNguyenNamNguyen_Project3
{
    public partial class MainForm : Form
    {
        public static String tickerValue;
        public static DateTime startDate;
        public static DateTime endDate;
        public static String period;

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
            tickerValue = tickerComboBox.Text;
            startDate = startDatePicker.Value;
            endDate = endDatePicker.Value;
            period = periodComboBox.Text;

            var newStockChart = new StockForm();
            newStockChart.Show();
        }
    }
}
