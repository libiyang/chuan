using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Management;
using System.Configuration;

namespace GoogleHit
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string strSN = ConfigurationManager.AppSettings["SN"];
            if (!string.IsNullOrEmpty(strSN) && strSN.Length > 32)
            {

                string strDate = strSN.Substring(32);
                strSN = strSN.Substring(0, 32);
                clsDES des = new clsDES();
                strDate = des.DesDecrypt(strDate, "libiyang"); //Convert.ToInt32(strDate, 16).ToString();
                if (int.Parse(DateTime.Now.ToString("yyyyMMdd")) > int.Parse(strDate))
                {
                    MessageBox.Show("已經超過使用期限或序列碼不正確！");
                    Application.Run(new frmSN());
                    return;
                }
            }
            string HDid;
            ManagementClass cimobject1 = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection moc1 = cimobject1.GetInstances();
            foreach (ManagementObject mo in moc1)
            {
                HDid = (string)mo.Properties["Model"].Value;

                if (softMD5(HDid) != strSN)
                {
                    Application.Run(new frmSN());
                }
                else
                {
                    Application.Run(new Form1());
                }
                break;
            }
        }

        public static string softMD5(string str)
        {
            byte[] b = System.Text.Encoding.GetEncoding(1252).GetBytes(str);
            b = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(b);
            string ret = "";
            for (int i = 0; i < b.Length; i++)
                ret += b[i].ToString("x").PadLeft(2, '0');
            return ret;
        }
    }
}
