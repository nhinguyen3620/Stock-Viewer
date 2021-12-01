using System;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

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

        private double max = 0;
        private double min = -1;

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

            // Create combo box for pattern selection
            addPattern();
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
                if (values[1] == "null" || values[2] == "null" || values[3] == "null" || values[4] == "null")
                {
                    continue;
                }

                // Add new data to database
                DataRow data = database.NewRow();

                data["Date"] = values[0];
                data["Open"] = values[1];
                data["High"] = values[2];
                data["Low"] = values[3];
                data["Close"] = values[4];

                for (int i = 1; i <= 4; i++)
                {
                    if (Double.Parse(values[i]) > max)
                    {
                        max = Double.Parse(values[i]);
                    }

                    if (min == -1 || Double.Parse(values[i]) < min)
                    {
                        min = Double.Parse(values[i]);
                    }
                }

                database.Rows.Add(data);
            }
            reader.Close();

            createChart();
            for (int i = 0; i < stockChart.Series["data"].Points.Count; i++)
            {
                var point = stockChart.Series["data"].Points[i];
                double yRange = stockChart.ChartAreas["ChartArea1"].AxisY.Maximum - stockChart.ChartAreas["ChartArea1"].AxisY.Minimum;
                RectangleAnnotation annotation = new RectangleAnnotation();
                annotation.BackColor = Color.FromArgb(128, Color.White);
                annotation.ToolTip = "rectangle annotation";
         
            
                annotation.Width = 50 / stockChart.Series["data"].Points.Count;
                annotation.Height = ((point.YValues[0] - point.YValues[1]) / yRange) * 85;
           
                annotation.AnchorY = - annotation.Height ;
                annotation.AnchorOffsetY = -(annotation.Height );


                annotation.SetAnchor(point);
    
                stockChart.Annotations.Add(annotation);
                }
            
        }

        private void cbBoxPat_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cbBoxPat.Text)
            {
                case "Neutral Doji":
                    detectNeutralDoji();
                    break;
                case "Long-Legged Doji":
                    detectLongLeggedDoji();
                    break;
                case "Dragonfly Doji":
                    detectDragonfly_or_GravestoneDoji();
                    break;
                case "Gravestone Doji":
                    detectDragonfly_or_GravestoneDoji();
                    break;
                case "Marubozu":
                    break;
                case "Bearish Harami":
                    break;
                case "Bullish Harami":
                    break;
            }
        }

        private bool isDojiPattern()
        {
            return true;
        }

        private bool detectNeutralDoji()
        {
            if (!isDojiPattern()) return false;

            return true;
        }

        private bool detectLongLeggedDoji()
        {
            if (!isDojiPattern()) return false;

            return true;
        }

        private bool detectDragonfly_or_GravestoneDoji()
        {
            if (!isDojiPattern()) return false;

            return true;
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

            Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.Read);
            BinaryWriter writer = new BinaryWriter(stream);

            writer.Write(buffer);
            stream.Close();
        }

        /// <summary>
        /// This function creates the candlestick chart
        /// </summary>
        private void createChart()
        {
            stockChart.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            stockChart.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineWidth = 0;
            stockChart.ChartAreas["ChartArea1"].AxisY.Maximum = (int) (max+10);
            stockChart.ChartAreas["ChartArea1"].AxisY.Minimum = (int) (min-10);

            stockChart.ChartAreas["ChartArea1"].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.WordWrap;
            stockChart.ChartAreas["ChartArea1"].AxisX.IsLabelAutoFit = true;
            stockChart.ChartAreas["ChartArea1"].AxisX.LabelStyle.Enabled = true;


            stockChart.Series["data"].XValueMember = "Date";
            stockChart.Series["data"].XValueType = ChartValueType.Date;

            stockChart.Series["data"].YValueMembers = "High,Low,Open,Close";

            stockChart.Series["data"].CustomProperties = "PriceDownColor=Red,PriceUpColor=Green";
            stockChart.Series["data"]["OpenCloseStyle"] = "Triangle";
            stockChart.Series["data"]["ShowOpenClose"] = "Both";
            //stockChart.Series["data"]["PixelPointWidth"] = "10";
            stockChart.Series["data"]["PointWidth"] = "0.5";

            stockChart.DataSource = database;
            stockChart.DataBind();
        }

        private void addPattern()
        {
            cbBoxPat.Items.Add("Neutral Doji");
            cbBoxPat.Items.Add("Long-Legged Doji");
            cbBoxPat.Items.Add("Dragonfly Doji");
            cbBoxPat.Items.Add("Gravestone Doji");
            cbBoxPat.Items.Add("Marubozu");
            cbBoxPat.Items.Add("Bearish Harami");
            cbBoxPat.Items.Add("Bullish Harami");
        }
    }
}
