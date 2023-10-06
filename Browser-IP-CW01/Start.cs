using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Http;

namespace Browser_IP_CW01
{
    public partial class Start : Form
    {
        //a class of web page that contains its attributes.
        public class WebPage
        {
            //each page has a url.
            public string url;
            //a boolean to set a page to user's favorits
            public bool isFavorite;
            public WebPage(string url)
            {
                this.url = url;
                isFavorite = false;
            }
        }
        //a container that holds data related to user's history.
        public class HistoryContainer
        {
            public WebPage[] pages;
            public int lastIndex;
            public HistoryContainer()
            {
                pages = new WebPage[50];
                lastIndex = 0;
            }
            //add a page to history.
            public void insert(WebPage page)
            {
                int index = findIndex(page);
                //if page was not in history.
                if (index == -1)
                {
                    //if the history was full -> overflow: remove the first page and add the new one to the last.
                    if (lastIndex == 49)
                    {
                        for (int i = 0; i <= 48; i++)
                        {
                            pages[i] = pages[i + 1];
                        }
                        pages[49] = page;
                    }
                    //if it was not full -> add the new page to the end of container.
                    else
                    {
                        pages[lastIndex] = page;
                        lastIndex++;
                    }
                }
                //if the new page was already in the history.
                else
                {
                    //shift the page to the end
                    for (int i = index; i < lastIndex; i++)
                    {
                        pages[i] = pages[i + 1];
                    }
                    pages[49] = page;
                }
            }
           /* public void writeOnFile(string url)
            {
                string data = url + "\n";
                File.AppendAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01/History.txt", data);
            } */
            //find index of a page in history. return -1 if it was not there.
            public int findIndex(WebPage page)
            {
                int result = -1;
                for (int i = 0; i < pages.Length; i++)
                {
                    if (pages[i] == page)
                    {
                        result = i;
                    }
                }
                return result;
            }
        }
        public HistoryContainer history = new HistoryContainer();
        public async Task<string> callUrl(string url)
        {
            HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);
            return response;
        }
        public Start()
        {
            InitializeComponent();
        }
        //it has to await for response -> it must be async.
        private async void GoBtn_Click(object sender, EventArgs e)
        {
            string eMessage = "";
            if (String.IsNullOrEmpty(UrlTxt.Text))
            {
                eMessage = "Enter a valid URL.";
                MessageBox.Show(eMessage);
                UrlTxt.Focus();
                return;
            }
            string url = UrlTxt.Text;
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "http://" + url;
            }
            WebPage page = new WebPage(url);
            history.insert(page);
            Browser browser = new Browser();
            browser.tb.Text = url;
            var awaiter = callUrl(url);
            //awaiter's result is the HTML code of user's URL.
            //if there was a result -> show!
            if (awaiter.Result != "")
            {
                browser.Show();
                this.Hide();
            }
        }

        private void UrlTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string eMessage = "";
                if (String.IsNullOrEmpty(UrlTxt.Text))
                {
                    eMessage = "Enter a valid URL.";
                    MessageBox.Show(eMessage);
                    UrlTxt.Focus();
                    return;
                }
                string url = UrlTxt.Text;
                if (!url.StartsWith("http://") && !url.StartsWith("https://"))
                {
                    url = "http://" + url;
                }
                WebPage page = new WebPage(url);
                history.insert(page);
                Browser browser = new Browser();
                browser.wb.Navigate(url);
                browser.tb.Text = url;
                browser.Show();
                this.Hide();
            }
        }
    }
}
