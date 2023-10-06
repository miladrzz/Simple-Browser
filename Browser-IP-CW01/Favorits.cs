using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Browser_IP_CW01
{
    public partial class Favorits : Form
    {
        public RichTextBox rtb;
        public Favorits()
        {
            InitializeComponent();
            rtb = richTextBox1;
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Start s = new Start();
            s.Show();
            this.Hide();
        }
    }
}
