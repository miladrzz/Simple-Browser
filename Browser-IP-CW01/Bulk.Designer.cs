namespace Browser_IP_CW01
{
    partial class Bulk
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Bulk));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.HomeBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PathTxt = new System.Windows.Forms.TextBox();
            this.StartBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 43);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(776, 381);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // HomeBtn
            // 
            this.HomeBtn.Location = new System.Drawing.Point(713, 12);
            this.HomeBtn.Name = "HomeBtn";
            this.HomeBtn.Size = new System.Drawing.Size(75, 23);
            this.HomeBtn.TabIndex = 1;
            this.HomeBtn.Text = "Home";
            this.HomeBtn.UseVisualStyleBackColor = true;
            this.HomeBtn.Click += new System.EventHandler(this.HomeBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter your file path ( bulk.txt by default ):";
            // 
            // PathTxt
            // 
            this.PathTxt.Location = new System.Drawing.Point(208, 14);
            this.PathTxt.Name = "PathTxt";
            this.PathTxt.Size = new System.Drawing.Size(367, 20);
            this.PathTxt.TabIndex = 3;
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(617, 12);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(75, 23);
            this.StartBtn.TabIndex = 4;
            this.StartBtn.Text = "Start";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // Bulk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.PathTxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HomeBtn);
            this.Controls.Add(this.richTextBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Bulk";
            this.Text = "Bulk";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button HomeBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PathTxt;
        private System.Windows.Forms.Button StartBtn;
    }
}