using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YahooFinanceApi;

namespace NhiNguyenNamNguyen_Project3
{
    public partial class StockForm : Form
    {
        public StockForm()
        {
            InitializeComponent();

            Console.WriteLine(MainForm.tickerValue);
            Console.WriteLine(MainForm.startDate);
            Console.WriteLine(MainForm.endDate);
            Console.WriteLine(MainForm.period);
        }

        async private void StockForm_Load(object sender, EventArgs e)
        {
            // You should be able to query data from various markets including US, HK, TW
            // The startTime & endTime here defaults to EST timezone
            //var history = await Yahoo.GetHistoricalAsync("AAPL", new DateTime(2016, 1, 1), new DateTime(2016, 7, 1), Period.Daily);

           // foreach (var candle in history)
            //{
            //    Console.WriteLine($"DateTime: {candle.DateTime}, Open: {candle.Open}, High: {candle.High}, Low: {candle.Low}, Close: {candle.Close}, Volume: {candle.Volume}, AdjustedClose: {candle.AdjustedClose}");
            //}
        }
    }
}
