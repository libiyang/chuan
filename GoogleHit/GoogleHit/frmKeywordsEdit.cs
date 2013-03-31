using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoogleHit
{
    public partial class frmKeywordsEdit : Form
    {
        public frmKeywordsEdit()
        {
            InitializeComponent();
        }
        public int Id = 0;

        private void frmKeywordsEdit_Load(object sender, EventArgs e)
        {
            if (Id > 0)
            {
                DB_Access db = new DB_Access();
                DataTable dt = db.Query("select * from keywords where id=" + Id);

                if (dt != null && dt.Rows.Count > 0)
                {
                    txtKeywords.Text = dt.Rows[0]["Keywords"].ToString();
                    txtUrls.Text = dt.Rows[0]["Urls"].ToString();
                }
            }
            else
            {
                txtKeywords.Text = "";
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (txtKeywords.Text.Trim() == "")
            {
                MessageBox.Show("網關鍵字不能為空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (txtUrls.Text.Trim() == "")
            {
                MessageBox.Show("網址不能為空", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DB_Access db = new DB_Access();

            int retval = 0;
            if (Id == 0)
            {
                retval = db.InsertKeywords(txtKeywords.Text.Trim(),txtUrls.Text.Trim());
            }
            else
            {
                retval = db.UpdateKeywords(Id, txtKeywords.Text.Trim(),txtUrls.Text.Trim());
            }
            if (retval > 0)
            {
                if (Id == 0)
                {
                    txtKeywords.Text = "";
                    txtUrls.Text = "";
                }
                MessageBox.Show("操作成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("操作失敗", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Exits_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
