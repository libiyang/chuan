using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using DotRas;
using System.Net;
using System.Runtime.InteropServices;

namespace YahooHit
{
    public partial class frmADSL : Form
    {
        public frmADSL()
        {
            InitializeComponent();
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct RasEntryName      //define the struct to receive the entry name
        {
            public int dwSize;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256 + 1)]
            public string szEntryName;
#if WINVER5
  public int dwFlags;
  [MarshalAs(UnmanagedType.ByValTStr,SizeConst=260+1)]
  public string szPhonebookPath;
#endif
        }

        [DllImport("rasapi32.dll", CharSet = CharSet.Auto)]
        public extern static uint RasEnumEntries(
            string reserved,              // reserved, must be NULL
            string lpszPhonebook,         // pointer to full path and file name of phone-book file
            [In, Out]RasEntryName[] lprasentryname, // buffer to receive phone-book entries
            ref int lpcb,                  // size in bytes of buffer
            out int lpcEntries             // number of entries written to buffer
            );

        private void frmADSL_Load(object sender, EventArgs e)
        {
            int lpNames = 1;
            int entryNameSize = 0;
            int lpSize = 0;
            RasEntryName[] names = null;

            entryNameSize = Marshal.SizeOf(typeof(RasEntryName));
            lpSize = lpNames * entryNameSize;

            names = new RasEntryName[lpNames];
            names[0].dwSize = entryNameSize;

            uint retval = RasEnumEntries(null, null, names, ref lpSize, out lpNames);

            //if we have more than one connection, we need to do it again
            if (lpNames > 1)
            {
                names = new RasEntryName[lpNames];
                for (int i = 0; i < names.Length; i++)
                {
                    names[i].dwSize = entryNameSize;
                }
                retval = RasEnumEntries(null, null, names, ref lpSize, out lpNames);
            }

            if (lpNames > 0)
            {
                for (int i = 0; i < names.Length; i++)
                {
                    comboBox1.Items.Add(names[i].szEntryName);
                }
            }
            DB_Access db = new DB_Access();
            DataTable dt = db.Query("select * from adsl");

            if (dt != null && dt.Rows.Count > 0)
            {
                comboBox1.SelectedItem = dt.Rows[0]["EntryName"].ToString();
                txtName.Text = dt.Rows[0]["userName"].ToString();
                txtPWD.Text = dt.Rows[0]["pwd"].ToString();
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "" || txtPWD.Text.Trim() == "" || comboBox1.SelectedItem.ToString() == "")
            {
                MessageBox.Show("不能為空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DB_Access db = new DB_Access();

            int retval = db.UpdateADSL(comboBox1.SelectedItem.ToString(), txtName.Text.Trim(), txtPWD.Text.Trim());
            if (retval > 0)
            {
                MessageBox.Show("操作成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("操作失敗", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //ReadOnlyCollection<RasConnection> conList = RasConnection.GetActiveConnections();
            //foreach (RasConnection con in conList)
            //{
            //    con.HangUp();
            //}
        }

        private void btn_Exits_Click(object sender, EventArgs e)
        {
            this.Close();
            //RasDialer dialer = new RasDialer();
            //dialer.EntryName = comboBox1.SelectedItem.ToString();
            //dialer.Credentials = new NetworkCredential(txtName.Text.Trim(), txtPWD.Text.Trim());
            //dialer.PhoneBookPath = RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.AllUsers);
            //dialer.Timeout = 0x2710;
            //dialer.Dial();

        }
    }
}
