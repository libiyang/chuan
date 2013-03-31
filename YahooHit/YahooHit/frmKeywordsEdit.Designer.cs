namespace YahooHit
{
    partial class frmKeywordsEdit
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
            this.btn_Exits = new System.Windows.Forms.Button();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.txtKeywords = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUrls = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Exits
            // 
            this.btn_Exits.Location = new System.Drawing.Point(356, 250);
            this.btn_Exits.Name = "btn_Exits";
            this.btn_Exits.Size = new System.Drawing.Size(97, 55);
            this.btn_Exits.TabIndex = 25;
            this.btn_Exits.Text = "退出";
            this.btn_Exits.UseVisualStyleBackColor = true;
            this.btn_Exits.Click += new System.EventHandler(this.btn_Exits_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.Location = new System.Drawing.Point(188, 250);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(97, 55);
            this.btn_Edit.TabIndex = 24;
            this.btn_Edit.Text = "保存";
            this.btn_Edit.UseVisualStyleBackColor = true;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // txtKeywords
            // 
            this.txtKeywords.Location = new System.Drawing.Point(74, 18);
            this.txtKeywords.Name = "txtKeywords";
            this.txtKeywords.Size = new System.Drawing.Size(554, 21);
            this.txtKeywords.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 23;
            this.label1.Text = "關鍵字：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "連結：";
            // 
            // txtUrls
            // 
            this.txtUrls.Location = new System.Drawing.Point(74, 45);
            this.txtUrls.Multiline = true;
            this.txtUrls.Name = "txtUrls";
            this.txtUrls.Size = new System.Drawing.Size(554, 169);
            this.txtUrls.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "(多個連結用英文逗號 , 隔開)";
            // 
            // frmKeywordsEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 340);
            this.Controls.Add(this.btn_Exits);
            this.Controls.Add(this.btn_Edit);
            this.Controls.Add(this.txtUrls);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtKeywords);
            this.Controls.Add(this.label1);
            this.Name = "frmKeywordsEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "關鍵字管理";
            this.Load += new System.EventHandler(this.frmKeywordsEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Exits;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.TextBox txtKeywords;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUrls;
        private System.Windows.Forms.Label label3;
    }
}