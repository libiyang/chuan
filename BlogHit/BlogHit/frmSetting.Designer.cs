namespace YahooHit
{
    partial class frmSetting
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
            this.label8 = new System.Windows.Forms.Label();
            this.txtPWD = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Exits
            // 
            this.btn_Exits.Location = new System.Drawing.Point(283, 130);
            this.btn_Exits.Name = "btn_Exits";
            this.btn_Exits.Size = new System.Drawing.Size(97, 55);
            this.btn_Exits.TabIndex = 31;
            this.btn_Exits.Text = "退出";
            this.btn_Exits.UseVisualStyleBackColor = true;
            this.btn_Exits.Click += new System.EventHandler(this.btn_Exits_Click);
            // 
            // btn_Edit
            // 
            this.btn_Edit.Location = new System.Drawing.Point(115, 130);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(97, 55);
            this.btn_Edit.TabIndex = 30;
            this.btn_Edit.Text = "保存";
            this.btn_Edit.UseVisualStyleBackColor = true;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(137, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 28;
            this.label8.Text = "循環次數：";
            // 
            // txtPWD
            // 
            this.txtPWD.Location = new System.Drawing.Point(208, 63);
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.Size = new System.Drawing.Size(130, 21);
            this.txtPWD.TabIndex = 29;
            this.txtPWD.Text = "100";
            this.txtPWD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 279);
            this.Controls.Add(this.btn_Exits);
            this.Controls.Add(this.btn_Edit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPWD);
            this.Name = "frmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "系統設定";
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Exits;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPWD;
    }
}