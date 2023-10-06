using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser_IP_CW01
{
    public partial class Browser : Form
    {
        public TextBox tb;
        public RichTextBox rtb;
        public Button dbtn;
        public async Task<string> callUrl(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                string result = "";
                var response = await client.GetStreamAsync(url);
                using (var res = new StreamReader(response, Encoding.GetEncoding("iso-8859-1")))
                {
                    result += res.ReadToEnd();
                }
                if (isFavorite(url))
                {
                    DBtn.Visible = true;
                }
                else
                {
                    DBtn.Visible = false;
                }
                return result;
            }
            catch
            {
                return null;
            }
        }
        public Browser()
        {
            InitializeComponent();
            tb = textBox1;
            rtb = richTextBox1;
            dbtn = DBtn;
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

        private async void BackBtn_Click(object sender, EventArgs e)
        {
            Start.loadHistory(start.history);
            int index = Start.findHistoryIndex(textBox1.Text);
            if (index == 0)
                MessageBox.Show("This is the first page!");
            else
            {
                Start.WebPage backpage = new Start.WebPage("");
                backpage.url = start.history.pages[index-1].url;
                var awaiter = await callUrl(backpage.url);
                richTextBox1.Text = awaiter;
                textBox1.Text = backpage.url;
            }
        }

        private async void ForwardBtn_Click(object sender, EventArgs e)
        {
            Start.loadHistory(start.history);
            int index = Start.findHistoryIndex(textBox1.Text);
            if (index == start.history.lastIndex-1)
                MessageBox.Show("This is the last page!");
            else
            {
                Start.WebPage forwardpage = new Start.WebPage("");
                forwardpage.url = start.history.pages[index + 1].url;
                var awaiter = await callUrl(forwardpage.url);
                richTextBox1.Text = awaiter;
                textBox1.Text = forwardpage.url;
            }
        }

        private async void RefreshBtn_Click(object sender, EventArgs e)
        {
            Start.WebPage currpage = new Start.WebPage(textBox1.Text);
            var awaiter = await callUrl(currpage.url);
            richTextBox1.Text = awaiter;
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start start = new Start();
            start.Show();
        }

        private async void textBox1_KeyDown(object sender, KeyEventArgs e)
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
                var awaiter = await callUrl(page.url);
                if(awaiter != null) 
                {
                    start.history.insert(page);
                    richTextBox1.Text = awaiter;
                    textBox1.Text = page.url;
                }
                else
                {
                    MessageBox.Show("404 - Not found!");
                }
            }
        }

        private void FavoriteBtn_Click(object sender, EventArgs e)
        {
            string text = File.ReadAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\favorits.txt");
            string[] favorites = text.Split('\n');
            bool isThere = false;
            for(int i = 0; i < favorites.Length-1; i++)
            {
                if (favorites[i].Equals(textBox1.Text)==true)
                    isThere = true;
            }
            if (isThere) 
            {
                MessageBox.Show("This page is already in your favorits!");
            }
            else
            {
                string data = textBox1.Text + "\n";
                File.AppendAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\favorits.txt", data);
                MessageBox.Show("Page set as favorite!");
                DBtn.Visible = true;
            }
        }
        private void DBtn_Click(object sender, EventArgs e)
        {
            removeFavorite(textBox1.Text);
            MessageBox.Show("This URL has been removed from your favorites!");
            DBtn.Visible = false;
        }
        public static bool isFavorite(string url)
        {
            bool result = false;
            string text = File.ReadAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\favorits.txt");
            string[] data = text.Split('\n');
            for (int i = 0; i < data.Length - 1; i++)
            {
                if (data[i].Equals(url))
                    result = true;
            }
            return result;
        }
        public static void removeFavorite(string url)
        {
            int index = -1;
            if (isFavorite(url))
            {
                string text = File.ReadAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\favorits.txt");
                string[] data = text.Split('\n');
                for (int i = 0; i < data.Length - 1; i++)
                {
                    if (data[i].Equals(url))
                    {
                        index = i;
                        break;
                    }
                }
                for (int i = index; i < data.Length - 1; i++)
                {
                    data[i] = data[i + 1];
                }
                File.WriteAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\favorits.txt", "");
                for (int i = 0; i < data.Length - 1; i++)
                {
                    if (data[i].Equals(""))
                    {
                        File.AppendAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\favorits.txt", data[i]);
                        break;
                    }
                    else
                    {
                        File.AppendAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\favorits.txt", data[i] + "\n");
                    }
                }
                if (data[0] == "")
                    File.AppendAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\favorits.txt", "");
            }
        }
    }
}
