using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YahooHit
{
    public partial class frmKeywords : Form
    {
        public frmKeywords()
        {
            InitializeComponent();
        }

        private void BindData()
        {
            DB_Access db = new DB_Access();
            DataTable table = db.Query("select * from keywords");
            dataGridView1.DataSource = table;
        }

        private void frmKeywords_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            frmKeywordsEdit frm = new frmKeywordsEdit();
            frm.ShowDialog();
            BindData();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            int iConsumerItems = dataGridView1.CurrentCell.RowIndex;
            if (iConsumerItems < 0)
            {
                MessageBox.Show("請先選擇", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmKeywordsEdit frm = new frmKeywordsEdit();
            frm.Id = (int)dataGridView1.Rows[iConsumerItems].Cells[0].Value;
            frm.ShowDialog();

            BindData();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            int iConsumerItems = dataGridView1.CurrentCell.RowIndex;
            if (iConsumerItems < 0)
            {
                MessageBox.Show("請先選擇", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("確定刪除嗎？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DB_Access db = new DB_Access();
                int id = (int)dataGridView1.Rows[iConsumerItems].Cells[0].Value;
                int retval = db.Execute("delete from keywords where id=" + id);

                DataTable table = db.Query("select * from keywords");
                dataGridView1.DataSource = table;
            }
        }

        private void btn_Exits_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
