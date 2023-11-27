using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser_IP_CW01
{
    public partial class SetHome : Form
    {
        public SetHome()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            string homeUrl = textBox1.Text;
            string temp = "";
            if (!homeUrl.StartsWith("http://") && !homeUrl.StartsWith("https://"))
                temp = "http://" + homeUrl;
            homeUrl = temp;
            string text = File.ReadAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\home.txt");
            if (homeUrl == text)
            {
                MessageBox.Show("This URL is already your home page!");
            }
            else
            {
                File.WriteAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\home.txt", "");
                File.WriteAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\home.txt", homeUrl);
                MessageBox.Show("New home page set!");
            }
        }

        private void GBBtn_Click(object sender, EventArgs e)
        {
            Start s  = new Start();
            s.Show();
            this.Hide();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                string homeUrl = textBox1.Text;
                string temp = "";
                if (!homeUrl.StartsWith("http://") && !homeUrl.StartsWith("https://"))
                    temp = "http://www." + homeUrl;
                homeUrl = temp;
                string text = File.ReadAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\home.txt");
                if (homeUrl == text)
                {
                    MessageBox.Show("This URL is already your home page!");
                }
                else
                {
                    File.WriteAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\home.txt", "");
                    File.WriteAllText("C:\\Users\\milad\\source\\repos\\Browser-IP-CW01\\Browser-IP-CW01\\home.txt", homeUrl);
                    MessageBox.Show("New home page set!");
                }
            }
        }
    }
}
