
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.stockTitle = new System.Windows.Forms.Label();
            this.stockName = new System.Windows.Forms.Label();
            this.stockChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.stockChart)).BeginInit();
            this.SuspendLayout();
            // 
            // stockTitle
            // 
            this.stockTitle.AutoSize = true;
            this.stockTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockTitle.Location = new System.Drawing.Point(60, 81);
            this.stockTitle.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.stockTitle.Name = "stockTitle";
            this.stockTitle.Size = new System.Drawing.Size(237, 79);
            this.stockTitle.TabIndex = 0;
            this.stockTitle.Text = "AMZN";
            // 
            // stockName
            // 
            this.stockName.AutoSize = true;
            this.stockName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockName.Location = new System.Drawing.Point(310, 112);
            this.stockName.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.stockName.Name = "stockName";
            this.stockName.Size = new System.Drawing.Size(275, 37);
            this.stockName.TabIndex = 1;
            this.stockName.Text = "Amazon.com, Inc.";
            // 
            // stockChart
            // 
            chartArea1.Name = "ChartArea1";
            this.stockChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.stockChart.Legends.Add(legend1);
            this.stockChart.Location = new System.Drawing.Point(74, 204);
            this.stockChart.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.stockChart.Name = "stockChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.Legend = "Legend1";
            series1.Name = "data";
            series1.YValuesPerPoint = 4;
            this.stockChart.Series.Add(series1);
            this.stockChart.Size = new System.Drawing.Size(1440, 625);
            this.stockChart.TabIndex = 2;
            this.stockChart.Text = "stockChart";
            // 
            // StockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.stockChart);
            this.Controls.Add(this.stockName);
            this.Controls.Add(this.stockTitle);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "StockForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.StockForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.stockChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label stockTitle;
        private System.Windows.Forms.Label stockName;
        private System.Windows.Forms.DataVisualization.Charting.Chart stockChart;
    }
}