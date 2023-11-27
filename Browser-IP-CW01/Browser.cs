using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Browser_IP_CW01
{
    public partial class Browser : Form
    {
        public TextBox tb;
        public RichTextBox rtb;
        public Button dbtn;
        public Button shb;

        // for input dialog box.
        public Label textLabel = new Label() { Left = 50, Top = 20, Text = "Name:" };
        public TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
        public Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
        public bool nameEntered = false;
        public string name = "";

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
                string homePageUrl =  File.ReadAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\home.txt");
                if (homePageUrl.Equals(textBox1.Text))
                    SetHPage.Text = "Dehome";
                else
                    SetHPage.Text = "Set home";
                string favorites = File.ReadAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\favorits.txt");
                string[] fpages = favorites.Split('\n');
                if(fpages.Contains(textBox1.Text))
                    DBtn.Visible = true;
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
            shb = SetHPage;
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
            confirmation.Click += new System.EventHandler(confirmation_Click);
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
                if (awaiter != "")
                {
                    richTextBox1.Text = awaiter;
                    textBox1.Text = backpage.url;
                    if (Start.isHome(backpage.url))
                        SetHPage.Text = "Dehome";
                    else SetHPage.Text = "Set home";
                }
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
                if(awaiter != null)
                {
                    richTextBox1.Text = awaiter;
                    textBox1.Text = forwardpage.url;
                    if (Start.isHome(forwardpage.url))
                        SetHPage.Text = "Dehome";
                    else SetHPage.Text = "Set home";
                }
            }
        }

        private async void RefreshBtn_Click(object sender, EventArgs e)
        {
            Start.WebPage currpage = new Start.WebPage(textBox1.Text);
            var awaiter = await callUrl(currpage.url);
            if (awaiter != null)
            {
                richTextBox1.Text = awaiter;
                textBox1.Text = currpage.url;
            }
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Start start = new Start();
            start.Show();
        }

        private async void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
                    url = "http://www." + url;
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
                    MessageBox.Show("Not found!");
                }
            }
        }
        private void confirmation_Click(object sender  , EventArgs e)
        {
            name = textBox.Text;
            nameEntered = true;
        }
        private void FavoriteBtn_Click(object sender, EventArgs e)
        {
            string text = File.ReadAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\favorits.txt");
            string[] favorites = text.Split('\n');
            if (isFavorite(textBox1.Text)) 
            {
                MessageBox.Show("This page is already in your favorits!");
            }
            else
            {
                string data = textBox1.Text + "\n";
                File.AppendAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\favorits.txt", data);
                MessageBox.Show("Page set as favorite!");
                textBox.Text = string.Empty;
                DBtn.Visible = true;
            }
        }
        private void DBtn_Click(object sender, EventArgs e)
        {
            if(isFavorite(textBox1.Text))
            {
                removeFavorite(textBox1.Text);
                MessageBox.Show("This URL has been removed from your favorites!");
                DBtn.Visible = false;
            }
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
                for (int i = index; i < data.Length - 1 && index!=-1; i++)
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

        private void SetHPage_Click(object sender, EventArgs e)
        {
            string text = File.ReadAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\home.txt");
            if (text.Equals(""))
            {
                File.WriteAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\home.txt", textBox1.Text);
                MessageBox.Show("New home page set!");
                SetHPage.Text = "Dehome";
            }
            else
            {
                if (text.Equals(textBox1.Text))
                {
                    MessageBox.Show("This page is not the home anymore!");
                    File.WriteAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\home.txt", "");
                    SetHPage.Text = "Set home";
                }
                else
                {
                    File.WriteAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\home.txt", "");
                    File.WriteAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\home.txt", textBox1.Text);
                    MessageBox.Show("New home page set!");
                    SetHPage.Text = "Dehome";
                }
            }
        }

        private async void GoHomeBtn_Click(object sender, EventArgs e)
        {
            string text = File.ReadAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\home.txt");
            Start.WebPage homepage = new Start.WebPage(text);
            var awaiter = await callUrl(homepage.url);
            if (awaiter != null)
            {
                richTextBox1.Text = awaiter;
                textBox1.Text = homepage.url;
            }
        }
    }
}
