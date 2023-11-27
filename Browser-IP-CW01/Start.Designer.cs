namespace Browser_IP_CW01
{
    partial class Start
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            this.label1 = new System.Windows.Forms.Label();
            this.UrlTxt = new System.Windows.Forms.TextBox();
            this.GoBtn = new System.Windows.Forms.Button();
            this.HistoryBtn = new System.Windows.Forms.Button();
            this.FavoritsBtn = new System.Windows.Forms.Button();
            this.SHPBtn = new System.Windows.Forms.Button();
            this.HomeBtn = new System.Windows.Forms.Button();
            this.browserBtn = new System.Windows.Forms.Button();
            this.BDLBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter URL:";
            // 
            // UrlTxt
            // 
            this.UrlTxt.Location = new System.Drawing.Point(192, 105);
            this.UrlTxt.Name = "UrlTxt";
            this.UrlTxt.Size = new System.Drawing.Size(382, 20);
            this.UrlTxt.TabIndex = 1;
            this.UrlTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UrlTxt_KeyDown);
            // 
            // GoBtn
            // 
            this.GoBtn.Location = new System.Drawing.Point(621, 102);
            this.GoBtn.Name = "GoBtn";
            this.GoBtn.Size = new System.Drawing.Size(75, 23);
            this.GoBtn.TabIndex = 2;
            this.GoBtn.Text = "Go!";
            this.GoBtn.UseVisualStyleBackColor = true;
            this.GoBtn.Click += new System.EventHandler(this.GoBtn_Click);
            // 
            // HistoryBtn
            // 
            this.HistoryBtn.Location = new System.Drawing.Point(192, 145);
            this.HistoryBtn.Name = "HistoryBtn";
            this.HistoryBtn.Size = new System.Drawing.Size(106, 23);
            this.HistoryBtn.TabIndex = 3;
            this.HistoryBtn.Text = "History";
            this.HistoryBtn.UseVisualStyleBackColor = true;
            this.HistoryBtn.Click += new System.EventHandler(this.HistoryBtn_Click);
            // 
            // FavoritsBtn
            // 
            this.FavoritsBtn.Location = new System.Drawing.Point(468, 145);
            this.FavoritsBtn.Name = "FavoritsBtn";
            this.FavoritsBtn.Size = new System.Drawing.Size(106, 23);
            this.FavoritsBtn.TabIndex = 4;
            this.FavoritsBtn.Text = "Favorits";
            this.FavoritsBtn.UseVisualStyleBackColor = true;
            this.FavoritsBtn.Click += new System.EventHandler(this.FavoritsBtn_Click);
            // 
            // SHPBtn
            // 
            this.SHPBtn.Location = new System.Drawing.Point(334, 200);
            this.SHPBtn.Name = "SHPBtn";
            this.SHPBtn.Size = new System.Drawing.Size(104, 23);
            this.SHPBtn.TabIndex = 5;
            this.SHPBtn.Text = "Set home page";
            this.SHPBtn.UseVisualStyleBackColor = true;
            this.SHPBtn.Click += new System.EventHandler(this.SHPBtn_Click);
            // 
            // HomeBtn
            // 
            this.HomeBtn.Location = new System.Drawing.Point(332, 145);
            this.HomeBtn.Name = "HomeBtn";
            this.HomeBtn.Size = new System.Drawing.Size(106, 23);
            this.HomeBtn.TabIndex = 6;
            this.HomeBtn.Text = "Home";
            this.HomeBtn.UseVisualStyleBackColor = true;
            this.HomeBtn.Click += new System.EventHandler(this.HomeBtn_Click);
            // 
            // browserBtn
            // 
            this.browserBtn.Location = new System.Drawing.Point(192, 200);
            this.browserBtn.Name = "browserBtn";
            this.browserBtn.Size = new System.Drawing.Size(106, 23);
            this.browserBtn.TabIndex = 7;
            this.browserBtn.Text = "Browser";
            this.browserBtn.UseVisualStyleBackColor = true;
            this.browserBtn.Click += new System.EventHandler(this.browserBtn_Click);
            // 
            // BDLBtn
            // 
            this.BDLBtn.Location = new System.Drawing.Point(468, 200);
            this.BDLBtn.Name = "BDLBtn";
            this.BDLBtn.Size = new System.Drawing.Size(106, 23);
            this.BDLBtn.TabIndex = 8;
            this.BDLBtn.Text = "Bulk download";
            this.BDLBtn.UseVisualStyleBackColor = true;
            this.BDLBtn.Click += new System.EventHandler(this.BDLBtn_Click);
            // 
            // Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BDLBtn);
            this.Controls.Add(this.browserBtn);
            this.Controls.Add(this.HomeBtn);
            this.Controls.Add(this.SHPBtn);
            this.Controls.Add(this.FavoritsBtn);
            this.Controls.Add(this.HistoryBtn);
            this.Controls.Add(this.GoBtn);
            this.Controls.Add(this.UrlTxt);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Start";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UrlTxt;
        private System.Windows.Forms.Button GoBtn;
        private System.Windows.Forms.Button HistoryBtn;
        private System.Windows.Forms.Button FavoritsBtn;
        private System.Windows.Forms.Button SHPBtn;
        private System.Windows.Forms.Button HomeBtn;
        private System.Windows.Forms.Button browserBtn;
        private System.Windows.Forms.Button BDLBtn;
    }
}

