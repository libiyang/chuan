namespace YahooHit
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.wbYahoo = new System.Windows.Forms.WebBrowser();
            this.wbBlog = new System.Windows.Forms.WebBrowser();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.開始搜尋ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系統設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.關鍵字設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aDSL設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wbBlogDetail = new System.Windows.Forms.WebBrowser();
            this.其它設定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // wbYahoo
            // 
            this.wbYahoo.Location = new System.Drawing.Point(11, 37);
            this.wbYahoo.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbYahoo.Name = "wbYahoo";
            this.wbYahoo.ScriptErrorsSuppressed = true;
            this.wbYahoo.Size = new System.Drawing.Size(528, 525);
            this.wbYahoo.TabIndex = 0;
            // 
            // wbBlog
            // 
            this.wbBlog.Location = new System.Drawing.Point(545, 37);
            this.wbBlog.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbBlog.Name = "wbBlog";
            this.wbBlog.ScriptErrorsSuppressed = true;
            this.wbBlog.Size = new System.Drawing.Size(523, 263);
            this.wbBlog.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.開始搜尋ToolStripMenuItem,
            this.系統設定ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1073, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 開始搜尋ToolStripMenuItem
            // 
            this.開始搜尋ToolStripMenuItem.Name = "開始搜尋ToolStripMenuItem";
            this.開始搜尋ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.開始搜尋ToolStripMenuItem.Text = "開始搜尋";
            this.開始搜尋ToolStripMenuItem.Click += new System.EventHandler(this.開始搜尋ToolStripMenuItem_Click);
            // 
            // 系統設定ToolStripMenuItem
            // 
            this.系統設定ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.關鍵字設定ToolStripMenuItem,
            this.aDSL設定ToolStripMenuItem,
            this.其它設定ToolStripMenuItem});
            this.系統設定ToolStripMenuItem.Name = "系統設定ToolStripMenuItem";
            this.系統設定ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.系統設定ToolStripMenuItem.Text = "系統設定";
            // 
            // 關鍵字設定ToolStripMenuItem
            // 
            this.關鍵字設定ToolStripMenuItem.Name = "關鍵字設定ToolStripMenuItem";
            this.關鍵字設定ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.關鍵字設定ToolStripMenuItem.Text = "關鍵字設定";
            this.關鍵字設定ToolStripMenuItem.Click += new System.EventHandler(this.關鍵字設定ToolStripMenuItem_Click);
            // 
            // aDSL設定ToolStripMenuItem
            // 
            this.aDSL設定ToolStripMenuItem.Name = "aDSL設定ToolStripMenuItem";
            this.aDSL設定ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aDSL設定ToolStripMenuItem.Text = "ADSL設定";
            this.aDSL設定ToolStripMenuItem.Click += new System.EventHandler(this.aDSL設定ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // wbBlogDetail
            // 
            this.wbBlogDetail.Location = new System.Drawing.Point(545, 306);
            this.wbBlogDetail.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbBlogDetail.Name = "wbBlogDetail";
            this.wbBlogDetail.ScriptErrorsSuppressed = true;
            this.wbBlogDetail.Size = new System.Drawing.Size(523, 256);
            this.wbBlogDetail.TabIndex = 3;
            // 
            // 其它設定ToolStripMenuItem
            // 
            this.其它設定ToolStripMenuItem.Name = "其它設定ToolStripMenuItem";
            this.其它設定ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.其它設定ToolStripMenuItem.Text = "其它設定";
            this.其它設定ToolStripMenuItem.Click += new System.EventHandler(this.其它設定ToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 574);
            this.Controls.Add(this.wbBlogDetail);
            this.Controls.Add(this.wbBlog);
            this.Controls.Add(this.wbYahoo);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yahoo點擊";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser wbYahoo;
        private System.Windows.Forms.WebBrowser wbBlog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 系統設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 關鍵字設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aDSL設定ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.WebBrowser wbBlogDetail;
        private System.Windows.Forms.ToolStripMenuItem 開始搜尋ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 其它設定ToolStripMenuItem;
    }
}

