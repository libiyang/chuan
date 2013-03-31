using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace GoogleHit
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            txtPWD.Text = ConfigurationManager.AppSettings["xhTime"];
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            ConfigurationManager.AppSettings["xhTime"] = txtPWD.Text;
            MessageBox.Show("操作成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_Exits_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
