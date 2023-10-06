﻿using System;
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
            public WebPage(string url)
            {
                this.url = url;
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
                int index = findHistoryIndex(page.url);
                loadHistory(this);
                //if page was not in history.
                if (index == -1)
                {
                    //if the history was full -> overflow: remove the first page and add the new one to the last.
                    if (lastIndex == 50)
                    {
                        string text = File.ReadAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\history.txt");
                        string[] data = text.Split('\n');
                        for (int i = 0; i < data.Length - 1; i++)
                        {
                            data[i] = data[i + 1];
                        }
                        data[data.Length - 2] =page.url;
                        File.WriteAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\history.txt", "");
                        for(int i = 0; i < data.Length - 1; i++)
                        {
                            writeHistory(data[i]);
                        }
                    }
                    //if it was not full -> add the new page to the end of container.
                    else
                    {
                        pages[lastIndex] = page;
                        lastIndex++;
                        writeHistory(page.url);
                    }
                }
                //if the new page was already in the history.
                else
                {
                    //shift the page to the end
                    string text = File.ReadAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\history.txt");
                    string[] data = text.Split('\n');
                    string temp = data[index];
                    for (int i = index; i < data.Length - 1; i++)
                    {
                        data[i] = data[i + 1];
                    }
                    data[data.Length - 2] = temp;
                    File.WriteAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\history.txt", "");
                    for (int i = 0; i < data.Length - 1; i++)
                    {
                        writeHistory(data[i]);
                    }
                    loadHistory(this);
                }
            }
        }
        public HistoryContainer history = new HistoryContainer();
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
                return result;
            }
            catch
            {
                return null;
            }
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
            Browser browser = new Browser();
            browser.tb.Text = url;
            var awaiter = await callUrl(url);
            //awaiter's result is the HTML code of user's URL.
            //if there was a result -> show!
            if (awaiter != null)
            {
                if (Browser.isFavorite(page.url))
                    browser.dbtn.Visible = true;
                else
                    browser.dbtn.Visible = false;
                history.insert(page);
                browser.rtb.Text = awaiter;
                browser.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("404 - Not found!");
            }
        }

        private async void UrlTxt_KeyDown(object sender, KeyEventArgs e)
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
                Browser browser = new Browser();
                browser.tb.Text = url;
                var awaiter = await callUrl(url);
                if(awaiter != null)
                {
                    if (Browser.isFavorite(page.url))
                        browser.dbtn.Visible = true;
                    else
                        browser.dbtn.Visible = false;
                    history.insert(page);
                    browser.rtb.Text = awaiter; 
                    browser.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("404 - Not found!");
                }
            }
        }

        public static void writeHistory(string url)
        {
            string data = url + "\n";
            File.AppendAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\history.txt", data);
        }
        public static void loadHistory(HistoryContainer history) 
        {
            string text = File.ReadAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\history.txt");
            string[] data = text.Split('\n');
            history.lastIndex = data.Length-1;
            for(int i  = 0; i < data.Length-1 && i<49; i++)
            {
                history.pages[i] = new WebPage(data[i]);
            }
        }
        //find index of a page in history. return -1 if it was not there.
        public static int findHistoryIndex(string url)
        {
            int result = -1;
            string text = File.ReadAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\history.txt");
            string[] data = text.Split('\n');
            for (int i = 0; i < data.Length && data[i] != ""; i++)
            {
                if (data[i].Equals(url))
                    result = i;
            }
            return result;
        }

        private void HistoryBtn_Click(object sender, EventArgs e)
        {
            History h = new History();
            string text = File.ReadAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\history.txt");
            string[] data = text.Split('\n');
            for(int i = 0; i < data.Length - 1; i++)
            {
                h.rtb.Text += (data[i]+"\n");
            }
            h.Show();
            this.Hide();
        }

        private void FavoritsBtn_Click(object sender, EventArgs e)
        {
            string text = File.ReadAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\favorits.txt");
            string[] data = text.Split('\n');
            Favorits f = new Favorits();
            for(int i=0; i < data.Length -1; i++)
            {
                f.rtb.Text += (data[i]+"\n");
            }
            f.Show();
            this.Hide();    
        }

    }
}
