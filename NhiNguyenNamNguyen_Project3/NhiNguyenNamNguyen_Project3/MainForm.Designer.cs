
namespace NhiNguyenNamNguyen_Project3
{
    partial class MainForm
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
            this.Title = new System.Windows.Forms.Label();
            this.Ticker_label = new System.Windows.Forms.Label();
            this.startDate_label = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDate_label = new System.Windows.Forms.Label();
            this.period_label = new System.Windows.Forms.Label();
            this.periodComboBox = new System.Windows.Forms.ComboBox();
            this.startButton = new System.Windows.Forms.Button();
            this.tickerComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Segoe Print", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(68, 60);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(214, 51);
            this.Title.TabIndex = 0;
            this.Title.Text = "Stock Viewer";
            // 
            // Ticker_label
            // 
            this.Ticker_label.AutoSize = true;
            this.Ticker_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ticker_label.Location = new System.Drawing.Point(32, 132);
            this.Ticker_label.Name = "Ticker_label";
            this.Ticker_label.Size = new System.Drawing.Size(55, 20);
            this.Ticker_label.TabIndex = 2;
            this.Ticker_label.Text = "Ticker:";
            // 
            // startDate_label
            // 
            this.startDate_label.AutoSize = true;
            this.startDate_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDate_label.Location = new System.Drawing.Point(32, 205);
            this.startDate_label.Name = "startDate_label";
            this.startDate_label.Size = new System.Drawing.Size(87, 20);
            this.startDate_label.TabIndex = 4;
            this.startDate_label.Text = "Start Date:";
            // 
            // startDatePicker
            // 
            this.startDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDatePicker.Location = new System.Drawing.Point(35, 228);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(289, 26);
            this.startDatePicker.TabIndex = 5;
            // 
            // endDatePicker
            // 
            this.endDatePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDatePicker.Location = new System.Drawing.Point(35, 302);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(289, 26);
            this.endDatePicker.TabIndex = 7;
            // 
            // endDate_label
            // 
            this.endDate_label.AutoSize = true;
            this.endDate_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDate_label.Location = new System.Drawing.Point(32, 279);
            this.endDate_label.Name = "endDate_label";
            this.endDate_label.Size = new System.Drawing.Size(81, 20);
            this.endDate_label.TabIndex = 6;
            this.endDate_label.Text = "End Date:";
            // 
            // period_label
            // 
            this.period_label.AutoSize = true;
            this.period_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.period_label.Location = new System.Drawing.Point(31, 363);
            this.period_label.Name = "period_label";
            this.period_label.Size = new System.Drawing.Size(143, 20);
            this.period_label.TabIndex = 9;
            this.period_label.Text = "Candlestick period:";
            // 
            // periodComboBox
            // 
            this.periodComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.periodComboBox.FormattingEnabled = true;
            this.periodComboBox.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly"});
            this.periodComboBox.Location = new System.Drawing.Point(181, 360);
            this.periodComboBox.Name = "periodComboBox";
            this.periodComboBox.Size = new System.Drawing.Size(143, 28);
            this.periodComboBox.TabIndex = 10;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Sienna;
            this.startButton.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.startButton.Location = new System.Drawing.Point(128, 425);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(94, 44);
            this.startButton.TabIndex = 11;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // tickerComboBox
            // 
            this.tickerComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tickerComboBox.FormattingEnabled = true;
            this.tickerComboBox.Location = new System.Drawing.Point(36, 155);
            this.tickerComboBox.Name = "tickerComboBox";
            this.tickerComboBox.Size = new System.Drawing.Size(288, 24);
            this.tickerComboBox.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Tan;
            this.ClientSize = new System.Drawing.Size(350, 491);
            this.Controls.Add(this.tickerComboBox);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.periodComboBox);
            this.Controls.Add(this.period_label);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.endDate_label);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.startDate_label);
            this.Controls.Add(this.Ticker_label);
            this.Controls.Add(this.Title);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label Ticker_label;
        private System.Windows.Forms.Label startDate_label;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Label endDate_label;
        private System.Windows.Forms.Label period_label;
        private System.Windows.Forms.ComboBox periodComboBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.ComboBox tickerComboBox;
    }
}

