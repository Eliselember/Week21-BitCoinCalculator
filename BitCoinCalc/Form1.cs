using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitCoinCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getRatesBtn_Click(object sender, EventArgs e)
        {
            if(currencyMenu.SelectedItem.ToString() == "EUR")
            {
                resultLbl.Visible = true;
                result.Visible = true;

                BitCoinRate resultRate = GetRates();
                int userCoins = Int32.Parse(amountOfBt.Text); //the amount of user's bitcoins

                float currentRate = resultRate.bpi.EUR.rate_float; //current bitcoin rate in EUR
                float btcResult = userCoins * currentRate;
                result.Text = $"{btcResult} {resultRate.bpi.EUR.code}";
            }
            else if (currencyMenu.SelectedItem.ToString() == "USD")
            {
                resultLbl.Visible = true;
                result.Visible = true;

                BitCoinRates resultRates = GetRates();
                int userCoins = Int32.Parse(amountOfBtn.Text);
                float currentRate = resultRates.bpi.USD.rate_float;
                float btcResult = userCoins * currentRate;
                result.Text = $"{btcResult} {resultRates.bpi.USD.code}";

            }
            else if (currencyMenu.SelectedItem.ToString() == "GBP")
            {
                resultLbl.Visible = true;
                result.Visible = true;

                BitCoinRates resultRates = GetRates();
                int userCoins = Int32.Parse(amountOfBtn.Text);
                float currentRate = resultRates.bpi.GBP.rate_float;
                float btcResult = userCoins * currentRate;
                result.Text = $"{btcResult} {resultRates.bpi.GBP.code}";

            }
        }

        public static BitCoinRate GetRates()
        {
            string url = "https://api.coindesk.com/v1/bpi/currentprice.json";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            BitCoinRate bitCoin;

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();

            using (var responseReader = new StreamReader(webStream))
            {
                var response = responseReader.ReadToEnd();
                bitCoin = JsonConvert.DeserializeObject<BitCoinRate>(response);
            }

            return bitCoin;
        }
    }

}
