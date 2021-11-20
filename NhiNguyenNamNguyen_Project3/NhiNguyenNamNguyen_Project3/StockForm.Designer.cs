
namespace NhiNguyenNamNguyen_Project3
{
    partial class StockForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.StockTitle = new System.Windows.Forms.Label();
            this.stockName = new System.Windows.Forms.Label();
            this.stockChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.stockChart)).BeginInit();
            this.SuspendLayout();
            // 
            // StockTitle
            // 
            this.StockTitle.AutoSize = true;
            this.StockTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StockTitle.Location = new System.Drawing.Point(30, 42);
            this.StockTitle.Name = "StockTitle";
            this.StockTitle.Size = new System.Drawing.Size(119, 39);
            this.StockTitle.TabIndex = 0;
            this.StockTitle.Text = "AMZN";
            // 
            // stockName
            // 
            this.stockName.AutoSize = true;
            this.stockName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockName.Location = new System.Drawing.Point(155, 58);
            this.stockName.Name = "stockName";
            this.stockName.Size = new System.Drawing.Size(136, 20);
            this.stockName.TabIndex = 1;
            this.stockName.Text = "Amazon.com, Inc.";
            // 
            // stockChart
            // 
            chartArea3.Name = "ChartArea1";
            this.stockChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.stockChart.Legends.Add(legend3);
            this.stockChart.Location = new System.Drawing.Point(37, 106);
            this.stockChart.Name = "stockChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series3.YValuesPerPoint = 4;
            this.stockChart.Series.Add(series3);
            this.stockChart.Size = new System.Drawing.Size(720, 325);
            this.stockChart.TabIndex = 2;
            this.stockChart.Text = "stockChart";
            // 
            // StockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.stockChart);
            this.Controls.Add(this.stockName);
            this.Controls.Add(this.StockTitle);
            this.Name = "StockForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.StockForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stockChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label StockTitle;
        private System.Windows.Forms.Label stockName;
        private System.Windows.Forms.DataVisualization.Charting.Chart stockChart;
    }
}