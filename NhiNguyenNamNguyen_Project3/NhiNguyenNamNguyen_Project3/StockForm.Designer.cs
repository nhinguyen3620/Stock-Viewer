
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
            this.cbBoxPat = new System.Windows.Forms.ComboBox();
            this.patternLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.stockChart)).BeginInit();
            this.SuspendLayout();
            // 
            // stockTitle
            // 
            this.stockTitle.AutoSize = true;
            this.stockTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockTitle.Location = new System.Drawing.Point(30, 42);
            this.stockTitle.Name = "stockTitle";
            this.stockTitle.Size = new System.Drawing.Size(119, 39);
            this.stockTitle.TabIndex = 0;
            this.stockTitle.Text = "AMZN";
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
            chartArea1.Name = "ChartArea1";
            this.stockChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.stockChart.Legends.Add(legend1);
            this.stockChart.Location = new System.Drawing.Point(37, 106);
            this.stockChart.Name = "stockChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.Legend = "Legend1";
            series1.Name = "data";
            series1.YValuesPerPoint = 4;
            this.stockChart.Series.Add(series1);
            this.stockChart.Size = new System.Drawing.Size(720, 325);
            this.stockChart.TabIndex = 2;
            this.stockChart.Text = "stockChart";
            // 
            // cbBoxPat
            // 
            this.cbBoxPat.FormattingEnabled = true;
            this.cbBoxPat.Location = new System.Drawing.Point(561, 61);
            this.cbBoxPat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbBoxPat.Name = "cbBoxPat";
            this.cbBoxPat.Size = new System.Drawing.Size(166, 21);
            this.cbBoxPat.TabIndex = 3;
            this.cbBoxPat.SelectedIndexChanged += new System.EventHandler(this.cbBoxPat_SelectedIndexChanged);
            // 
            // patternLabel
            // 
            this.patternLabel.AutoSize = true;
            this.patternLabel.Location = new System.Drawing.Point(558, 46);
            this.patternLabel.Name = "patternLabel";
            this.patternLabel.Size = new System.Drawing.Size(44, 13);
            this.patternLabel.TabIndex = 4;
            this.patternLabel.Text = "Pattern:";
            // 
            // StockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 450);
            this.Controls.Add(this.patternLabel);
            this.Controls.Add(this.cbBoxPat);
            this.Controls.Add(this.stockChart);
            this.Controls.Add(this.stockName);
            this.Controls.Add(this.stockTitle);
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
        private System.Windows.Forms.ComboBox cbBoxPat;
        private System.Windows.Forms.Label patternLabel;
    }
}