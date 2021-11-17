
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Ticker_label = new System.Windows.Forms.Label();
            this.startDate_label = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDate_label = new System.Windows.Forms.Label();
            this.period_label = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(66, 67);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(137, 25);
            this.Title.TabIndex = 0;
            this.Title.Text = "Stock Viewer";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(35, 148);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(72, 20);
            this.textBox1.TabIndex = 1;
            // 
            // Ticker_label
            // 
            this.Ticker_label.AutoSize = true;
            this.Ticker_label.Location = new System.Drawing.Point(32, 132);
            this.Ticker_label.Name = "Ticker_label";
            this.Ticker_label.Size = new System.Drawing.Size(40, 13);
            this.Ticker_label.TabIndex = 2;
            this.Ticker_label.Text = "Ticker:";
            // 
            // startDate_label
            // 
            this.startDate_label.AutoSize = true;
            this.startDate_label.Location = new System.Drawing.Point(32, 192);
            this.startDate_label.Name = "startDate_label";
            this.startDate_label.Size = new System.Drawing.Size(58, 13);
            this.startDate_label.TabIndex = 4;
            this.startDate_label.Text = "Start Date:";
            // 
            // startDatePicker
            // 
            this.startDatePicker.Location = new System.Drawing.Point(35, 208);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(72, 20);
            this.startDatePicker.TabIndex = 5;
            // 
            // endDatePicker
            // 
            this.endDatePicker.Location = new System.Drawing.Point(157, 208);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(72, 20);
            this.endDatePicker.TabIndex = 7;
            // 
            // endDate_label
            // 
            this.endDate_label.AutoSize = true;
            this.endDate_label.Location = new System.Drawing.Point(154, 192);
            this.endDate_label.Name = "endDate_label";
            this.endDate_label.Size = new System.Drawing.Size(55, 13);
            this.endDate_label.TabIndex = 6;
            this.endDate_label.Text = "End Date:";
            // 
            // period_label
            // 
            this.period_label.AutoSize = true;
            this.period_label.Location = new System.Drawing.Point(32, 254);
            this.period_label.Name = "period_label";
            this.period_label.Size = new System.Drawing.Size(97, 13);
            this.period_label.TabIndex = 9;
            this.period_label.Text = "Candlestick period:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly"});
            this.comboBox1.Location = new System.Drawing.Point(35, 270);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(72, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(99, 354);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(59, 25);
            this.startButton.TabIndex = 11;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 450);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.period_label);
            this.Controls.Add(this.endDatePicker);
            this.Controls.Add(this.endDate_label);
            this.Controls.Add(this.startDatePicker);
            this.Controls.Add(this.startDate_label);
            this.Controls.Add(this.Ticker_label);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Title);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Ticker_label;
        private System.Windows.Forms.Label startDate_label;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Label endDate_label;
        private System.Windows.Forms.Label period_label;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button startButton;
    }
}

