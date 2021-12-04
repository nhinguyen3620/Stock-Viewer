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

        private List<RectangleAnnotation> annotationList = new List<RectangleAnnotation>();

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
        }

        /// <summary>
        /// This function will be called when the selected index of the combo box changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbBoxPat_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearRectangle();

            //loop through the candlesticks
            for (int i = 0; i < stockChart.Series["data"].Points.Count; i++)
            {
                int result = 0;

                switch (cbBoxPat.Text)
                {
                    case "Neutral Doji":
                        result = isNeutralDoji(i);
                        break;
                    case "Long-Legged Doji":
                        result = isLongLeggedDoji(i);
                        break;
                    case "Dragonfly Doji":
                    case "Gravestone Doji":
                        result = isDragonfly_or_GravestoneDoji(i, cbBoxPat.Text);
                        break;
                    case "Bearish Marubozu":
                    case "Bullish Marubozu":
                        result = isBearish_or_BullishMarubozu(i, cbBoxPat.Text);
                        break;
                    case "Bearish Harami":
                    case "Bullish Harami":
                        if (i == stockChart.Series["data"].Points.Count - 1) result = 0;
                        else result = isBearish_or_BullishHarami(i, cbBoxPat.Text);
                        break;
                }

                if (result == 1) addRectangleOne(i);
                else if (result == 2) addRectangleMultiple(i);
            }
             
        }

        //function to check if a candlestick has doji pattern
        private int isDojiPattern(int idx)
        {
            var point = stockChart.Series["data"].Points[idx];
            double large = point.YValues[2] > point.YValues[3] ? point.YValues[2] : point.YValues[3];

            //is doji if open-close < 5%
            int result = Math.Abs(point.YValues[2] - point.YValues[3]) <= 0.0005 * large ? 1 : 0;

            return result;
        }

        //function to check if a candlestick has neutral doji pattern
        private int isNeutralDoji(int idx)
        {
            if (isDojiPattern(idx) == 0) return 0;

            var point = stockChart.Series["data"].Points[idx];
            double large = point.YValues[2] > point.YValues[3] ? point.YValues[2] : point.YValues[3];
            double small = point.YValues[2] < point.YValues[3] ? point.YValues[2] : point.YValues[3];

            return (point.YValues[0] - large >= 0.0005 * point.YValues[0] || small - point.YValues[1] >= 0.0005 * small) ? 1 : 0;
        }

        //function to check if a candlestick has long legged doji pattern
        private int isLongLeggedDoji(int idx)
        {
            if (isDojiPattern(idx) == 0) return 0;

            //is long legged doji if high - open/close >= 20% && open/close - low > -20%
            var point = stockChart.Series["data"].Points[idx];
            double large = point.YValues[2] > point.YValues[3] ? point.YValues[2] : point.YValues[3];
            double small = point.YValues[2] < point.YValues[3] ? point.YValues[2] : point.YValues[3];

            return (point.YValues[0] - large >= 0.002 * point.YValues[0] && small - point.YValues[1] >= 0.002 * small) ? 1 : 0;
        }

        //function to check if a candlestick has dragonfly or gravestone doji pattern
        private int isDragonfly_or_GravestoneDoji(int idx, string pattern)
        {
            if (isDojiPattern(idx) == 0) return 0;

            var point = stockChart.Series["data"].Points[idx];
            double large = point.YValues[2] > point.YValues[3] ? point.YValues[2] : point.YValues[3];
            double small = point.YValues[2] < point.YValues[3] ? point.YValues[2] : point.YValues[3];

            if (pattern == "Dragonfly Doji")
            {
                return (point.YValues[0] - large <= 0.0005 * point.YValues[0]) ? 1 : 0;
            } else
            {
                return (small - point.YValues[1] <= 0.0005 * small) ? 1 : 0;
            }
        }

        //function to check if a candlestick has bearish or bullish marubozu pattern
        private int isBearish_or_BullishMarubozu(int idx, string pattern)
        {
            if (isDojiPattern(idx) == 1) return 0;

            var point = stockChart.Series["data"].Points[idx];
            double large = point.YValues[2] > point.YValues[3] ? point.YValues[2] : point.YValues[3];
            double small = point.YValues[2] < point.YValues[3] ? point.YValues[2] : point.YValues[3];

            if (point.YValues[0] - large <= 0.0005 * point.YValues[0] && small - point.YValues[1] <= 0.0005 * small)
            {
                if (pattern == "Bearish Marubozu")
                {
                    return (point.YValues[2] > point.YValues[3]) ? 1 : 0;
                }
                else
                {
                    return (point.YValues[2] < point.YValues[3]) ? 1 : 0;
                }
            } else
            {
                return 0;
            }
        }

        //function to check if a candlestick has bearish or bullish harami pattern
        private int isBearish_or_BullishHarami(int idx, string pattern)
        {
            var prev = stockChart.Series["data"].Points[idx];
            var curr = stockChart.Series["data"].Points[idx + 1];

            double prev_open = prev.YValues[2];
            double prev_close = prev.YValues[3];
            double prev_high = prev.YValues[0];
            double prev_low = prev.YValues[1];
            double curr_open = curr.YValues[2];
            double curr_close = curr.YValues[3];
            double curr_high = curr.YValues[0];
            double curr_low = curr.YValues[1];

            if (isDojiPattern(idx) == 1 || isDojiPattern(idx + 1) == 1)
                return 0;

            if (pattern == "Bearish Harami")
            {
                if (prev_open < prev_close && curr_open - curr_close < prev_close - prev_open && prev_high >= curr_high && prev_low < curr_low)
                {
                    if (prev_open <= curr_close && curr_close < curr_open && curr_open <= prev_close)
                        return 2;
                }
                return 0;
            }

            if (pattern == "Bullish Harami")
            {
                if (prev_open > prev_close && curr_close - curr_open < prev_open - prev_close && prev_high >= curr_high && prev_low < curr_low)
                {
                    if (prev_close <= curr_open && curr_open < curr_close && curr_close <= prev_open) 
                        return 2;
                }
                return 0;
            }
            return 0;
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
            stockChart.ChartAreas["ChartArea1"].AxisY.Maximum = (int) Math.Ceiling(max);
            stockChart.ChartAreas["ChartArea1"].AxisY.Minimum = (int) Math.Floor(min);

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
            cbBoxPat.Items.Add("Bearish Marubozu");
            cbBoxPat.Items.Add("Bullish Marubozu");
            cbBoxPat.Items.Add("Bearish Harami");
            cbBoxPat.Items.Add("Bullish Harami");
        }

        //function to draw candle around 1 candlestick
        private void addRectangleOne(int i)
        {
            var point = stockChart.Series["data"].Points[i];
            double yRange = stockChart.ChartAreas["ChartArea1"].AxisY.Maximum - stockChart.ChartAreas["ChartArea1"].AxisY.Minimum;
            RectangleAnnotation annotation = new RectangleAnnotation();
            annotation.BackColor = Color.FromArgb(128, Color.White);
            annotation.ToolTip = "rectangle annotation";


            annotation.Width = stockChart.Width * 0.06 / stockChart.Series["data"].Points.Count;
            annotation.Height = ((point.YValues[0] - point.YValues[1]) / yRange) * stockChart.Height * 0.255;

            annotation.AnchorOffsetY = -(annotation.Height);
             
            annotation.SetAnchor(point);

            stockChart.Annotations.Add(annotation);
            annotationList.Add(annotation);
        }

        //function to draw rectangle around 2 candlesticks
        private void addRectangleMultiple(int i)
        {
            var p0 = stockChart.Series["data"].Points[i];
            var p1 = stockChart.Series["data"].Points[i + 1];
            RectangleAnnotation annotation = new RectangleAnnotation();
            annotation.BackColor = Color.FromArgb(128, Color.White);
            annotation.ToolTip = "rectangle annotation";


            annotation.Width = 100 / stockChart.Series["data"].Points.Count;
            double yRange = stockChart.ChartAreas["ChartArea1"].AxisY.Maximum - stockChart.ChartAreas["ChartArea1"].AxisY.Minimum + 20;
           
            annotation.Height = ((p0.YValues[0] - p0.YValues[1]) / yRange) * stockChart.Height * 0.5;
             
            annotation.AnchorOffsetY = -(annotation.Height);
            

            if (stockChart.Series["data"].Points.Count <= 3)
            {
                annotation.AnchorOffsetX = stockChart.Series["data"].Points.Count * 3;
               
            }
            else if (stockChart.Series["data"].Points.Count  == 4)
            {
                annotation.AnchorOffsetX = stockChart.Series["data"].Points.Count * 1.75;
            }
            else if (stockChart.Series["data"].Points.Count == 5)
            {
                annotation.AnchorOffsetX = stockChart.Series["data"].Points.Count * 1.1;
            }
            else if (stockChart.Series["data"].Points.Count == 6)
            {
                annotation.AnchorOffsetX = stockChart.Series["data"].Points.Count * 0.9;
            }
            else if (stockChart.Series["data"].Points.Count == 7)
            {
                annotation.AnchorOffsetX = stockChart.Series["data"].Points.Count * 0.65;
            }
            else if (stockChart.Series["data"].Points.Count == 8 || stockChart.Series["data"].Points.Count == 9 )
            {
                annotation.AnchorOffsetX = stockChart.Series["data"].Points.Count * 0.45;
                annotation.Width += 5;
            }
            else if (stockChart.Series["data"].Points.Count == 10)
            {
                annotation.AnchorOffsetX = stockChart.Series["data"].Points.Count * 0.20;
                annotation.Width += 5;
            }
            else if (stockChart.Series["data"].Points.Count > 10 && stockChart.Series["data"].Points.Count < 18)
            {
                annotation.AnchorOffsetX = stockChart.Series["data"].Points.Count * 0.15;
                annotation.Width += 3.3;
            }
            else if (stockChart.Series["data"].Points.Count >= 18 && stockChart.Series["data"].Points.Count < 23)
            {
                annotation.AnchorOffsetX = stockChart.Series["data"].Points.Count * 0.1;
                annotation.Width += 2;
            }
            else if (stockChart.Series["data"].Points.Count >= 23 && stockChart.Series["data"].Points.Count < 30)
            {
                annotation.AnchorOffsetX = stockChart.Series["data"].Points.Count * 0.05;
                annotation.Width += 2;
            }
            else if (stockChart.Series["data"].Points.Count >= 30 && stockChart.Series["data"].Points.Count < 40)
            {
                annotation.AnchorOffsetX = stockChart.Series["data"].Points.Count * 0.025;
                annotation.Width += 2;
            }
            else if (stockChart.Series["data"].Points.Count >= 40 && stockChart.Series["data"].Points.Count < 47)
            {
                annotation.AnchorOffsetX = stockChart.Series["data"].Points.Count * 0.015;
                annotation.Width += 1.7;
            }
            else if (stockChart.Series["data"].Points.Count >= 46 && stockChart.Series["data"].Points.Count < 67)
            {
                annotation.AnchorOffsetX = stockChart.Series["data"].Points.Count * 0.009;
                annotation.Width += 1.7;
            }
            else if (stockChart.Series["data"].Points.Count >= 67 && stockChart.Series["data"].Points.Count < 80)
            {
                annotation.AnchorOffsetX = stockChart.Series["data"].Points.Count * 0.002;
                annotation.Width += 1.6;
            }
            else
            {
                annotation.AnchorOffsetX = stockChart.Series["data"].Points.Count * 0.001;
                annotation.Width += 1.4;
            }
         
            annotation.SetAnchor(p0);

            stockChart.Annotations.Add(annotation);
            annotationList.Add(annotation);
        }

        private void clearRectangle()
        {
            if (annotationList == null) return;

            for (int i = 0; i < annotationList.Count; i++)
            {
                stockChart.Annotations.Remove(annotationList[i]);
            }
        }
    }
}
