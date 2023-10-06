using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser_IP_CW01
{
    public partial class Browser : Form
    {
        public TextBox tb;
        HttpClient client = new HttpClient();
        public async Task communicate()
        {
            string response = await client.GetStringAsync(tb.Text);
        }
        public Browser()
        {
            InitializeComponent();
            tb = textBox1;
        }
        Start start = new Start();
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Browser_Load(object sender, EventArgs e)
        {

        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void ForwardBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void RefreshBtn_Click(object sender, EventArgs e)
        {
            
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start start = new Start();
            start.Show();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string eMessage = "";
                if (String.IsNullOrEmpty(textBox1.Text))
                {
                    eMessage = "Enter a valid URL.";
                    MessageBox.Show(eMessage);
                    textBox1.Focus();
                    return;
                }
                string url = textBox1.Text;
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "http://" + url;
                }
                Start.WebPage page = new Start.WebPage(url);
                start.history.insert(page);
                
            }
        }

    }
}
