using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser_IP_CW01
{
    public partial class History : Form
    {
        public async Task<string> callUrl(string url)
        {
            try
            {
                string result = "";
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(url);
                var status = response.StatusCode;
                if (status == HttpStatusCode.BadRequest)
                {
                    MessageBox.Show("400 - Bad request!");
                }
                if (status == HttpStatusCode.Forbidden)
                {
                    MessageBox.Show("403 - Forbidden!");
                }
                if (status == HttpStatusCode.NotFound)
                {
                    MessageBox.Show("404 - Not found!");
                }
                using (var sr = new StreamReader(await response.Content.ReadAsStreamAsync(), Encoding.GetEncoding("iso-8859-1")))
                {
                    result = sr.ReadToEnd();
                }
                return result;
            }
            catch
            {
                return null;
            }
        }
        public RichTextBox rtb;
        public History()
        {
            InitializeComponent();
            rtb = richTextBox1;

        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Start start = new Start();
            start.Show();
            this.Hide();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            File.WriteAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\history.txt", "");
            MessageBox.Show("History cleared.");
            richTextBox1.Text = "";
        }

        private async void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            string url = e.LinkText.ToString();
            Browser browser = new Browser();
            Start.WebPage page = new Start.WebPage(url);
            browser.tb.Text = url;
            Start start = new Start();
            var awaiter = await callUrl(url);
            if (awaiter != null)
            {
                if (Browser.isFavorite(url))
                    browser.dbtn.Visible = true;
                else
                    browser.dbtn.Visible = false;
                start.history.insert(page);
                browser.rtb.Text = awaiter;
                string homePageUrl = File.ReadAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\home.txt");
                if (homePageUrl.Equals(browser.tb.Text))
                    browser.shb.Text = "dehome";
                else
                    browser.shb.Text = "Set home";
                browser.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Not found!");
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
