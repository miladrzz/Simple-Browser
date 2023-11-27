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
    public partial class Bulk : Form
    {
        public Bulk()
        {
            InitializeComponent();
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Start s = new Start();
            s.Show();
            this.Hide();
        }

        private async void StartBtn_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = string.Empty;
            string path = PathTxt.Text;
            if (PathTxt.Text.Length == 0)
                path = "C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\bulk.txt";
            string d = File.ReadAllText(path);
            string[] data = d.Split('\n');
            for(int i  = 0; i < data.Length; i++)
            {
                int code = 0;
                int bytes = 0;
                string URL = data[i];
                string result = "";
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(data[i]);
                var status = response.StatusCode;
                code = ((int)status);
                byte[] b = await client.GetByteArrayAsync(data[i]);
                bytes = b.Length;
                result = "<" + code.ToString() + "> " +"<" +bytes.ToString() + "> "+"<"+URL+">\n";
                richTextBox1.Text += result;
            }
        }
    }
}
