using System;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Data;
using System.Collections.Generic;

namespace NhiNguyenNamNguyen_Project3
{
    /// <summary>
    /// This function holds the data members of StockForm class
    /// </summary>
    public partial class StockForm : Form
    {
        private string tickerSymbol;
        private string companyName;
        private int startDate;
        private int endDate;
        private string period;

        private DataTable database = new DataTable();

        /// <summary>
        /// this function initializes the StockForm class
        /// </summary>
        public StockForm()
        {
            InitializeComponent();

            tickerSymbol = MainForm.tickerSymbol;
            companyName = MainForm.companyName;
            startDate = MainForm.startDate;
            endDate = MainForm.endDate;
            period = MainForm.period;

            // Load data from URL
            loadData();

            // Create dataTable
            database.Columns.Add("Date", typeof(String));
            database.Columns.Add("Open", typeof(Double));
            database.Columns.Add("Close", typeof(Double));
            database.Columns.Add("High", typeof(Double));
            database.Columns.Add("Low", typeof(Double));
        }

        /// <summary>
        /// This function loads the required data to create chart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StockForm_Load(object sender, EventArgs e)
        {
            // Create title
            stockTitle.Text = tickerSymbol;
            stockName.Text = companyName;

            // Add data to Chart
            var reader = new StreamReader(@"..\..\stockData.csv");
            List<string> stock = new List<string>();

            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                // Add new data to database
                DataRow data = database.NewRow();

                data["Date"] = values[0];
                data["Open"] = values[1];
                data["High"] = values[2];
                data["Low"] = values[3];
                data["Close"] = values[4];

                database.Rows.Add(data);
            }

            createChart();
        }

        /// <summary>
        /// This function loads the data from Yahoo Finance
        /// </summary>
        private void loadData()
        {
            if (period == "Daily") period = "1d";
            else if (period == "Weekly") period = "1wk";
            else period = "1mo";

            string historicalDataURL = "https://query1.finance.yahoo.com/v7/finance/download/" + tickerSymbol + "?period1=" + startDate + "&period2=" + endDate + "&interval=" + period + "&events=history&includeAdjustedClose=true";
            string filePath = @"..\..\stockData.csv";

            WebClient client = new WebClient();
            byte[] buffer = client.DownloadData(historicalDataURL);

            Stream stream = new FileStream(filePath, FileMode.Create);
            BinaryWriter writer = new BinaryWriter(stream);

            writer.Write(buffer);
            stream.Close();
        }

        /// <summary>
        /// This function creates the candlestick chart
        /// </summary>
        private void createChart()
        {
            //Clear Grid
            stockChart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            stockChart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
            //Init
            stockChart.Series["data"].XValueMember = "Date";
            stockChart.Series["data"].YValueMembers = "High,Low,Open,Close";
            stockChart.Series["data"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            stockChart.Series["data"].CustomProperties = "PriceDownColor=Red,PriceUpColor=Green";
            stockChart.Series["data"]["OpenCloseStyle"] = "Triangle";
            stockChart.Series["data"]["ShowOpenClose"] = "Both";
            stockChart.DataManipulator.IsStartFromFirst = true;
            stockChart.DataSource = database;
            stockChart.DataBind();
        }
    }
}
