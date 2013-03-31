﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Web;
using System.Collections.ObjectModel;
using DotRas;
using System.Net;
using System.Configuration;

namespace YahooHit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            SHDocVw.WebBrowser wb = this.wbYahoo.ActiveXInstance as SHDocVw.WebBrowser;
            //wb.BeforeNavigate2 += new SHDocVw.DWebBrowserEvents2_BeforeNavigate2EventHandler(wb_BeforeNavigate2);
            wb.NewWindow2 += new SHDocVw.DWebBrowserEvents2_NewWindow2EventHandler(wb_NewWindow2);
            wb.NewWindow3 += new SHDocVw.DWebBrowserEvents2_NewWindow3EventHandler(wb_NewWindow3);
        }

        void wb_NewWindow3(ref object ppDisp, ref bool Cancel, uint dwFlags, string bstrUrlContext, string bstrUrl)
        {
            Navigate(wbBlog, bstrUrl.ToString());
            Cancel = true;
        }

        void wb_NewWindow2(ref object ppDisp, ref bool Cancel)
        {
            Cancel = true;
        }

        void wb_BeforeNavigate2(object pDisp, ref object URL, ref object Flags, ref object TargetFrameName, ref object PostData, ref object Headers, ref bool Cancel)
        {
            if (URL.ToString() == "about:blank" || URL.ToString().IndexOf("http://tw.search.yahoo.com/") >= -1 || URL.ToString() == "http://tw.search.yahoo.com/")
            {
            }
            else
            {
                try
                {
                    wbBlog.Document.Cookie = wbYahoo.Document.Cookie;
                }
                catch
                { }
                Navigate(wbBlog, URL.ToString());
                Cancel = true;
            }
        }

        string strAd_EntryName = "AD";
        string strAd_userName = "gzDSL51414234";
        string strAd_pwd = "LKRRSGUX";
        bool bDialCompleted = false;

        private void RunKeyword()
        {
            DB_Access db = new DB_Access();
            DataTable table = db.Query("select * from keywords ORDER BY right(cstr(rnd(-int(rnd(-timer())*100+ID)))*1000*Now(),2)");

            int xhTime = 100;
            try
            {
                xhTime = int.Parse(ConfigurationManager.AppSettings["xhTime"].ToString());
            }
            catch
            { 
            }

            while (xhTime > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    string url_main = row["keywords"].ToString();
                    string urls = row["urls"].ToString();

                    refreshTimer_OnRefresh(url_main, urls);

                    //ReadOnlyCollection<RasConnection> conList = RasConnection.GetActiveConnections();
                    //foreach (RasConnection con in conList)
                    //{
                    //    con.HangUp();
                    //}
                    //Wait();
                    //try
                    //{
                    //    Dialer();
                    //}
                    //catch
                    //{
                    //    Dialer();
                    //}
                }
                xhTime--;
            }
            MessageBox.Show("循環操作成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void Dialer()
        {
            RasDialer dialer = new RasDialer();
            dialer.EntryName = strAd_EntryName;
            dialer.Credentials = new NetworkCredential(strAd_userName, strAd_pwd);
            dialer.PhoneBookPath = RasPhoneBook.GetPhoneBookPath(RasPhoneBookType.AllUsers);
            dialer.Timeout = 1000 * 60;
            dialer.StateChanged += new EventHandler<StateChangedEventArgs>(dialer_StateChanged);
            bDialCompleted = false;
            dialer.DialAsync();

            for (int i = 0; i <= 60; i++)
            {
                Thread.Sleep(500);
                if (bDialCompleted)
                {
                    Application.DoEvents();
                    Thread.Sleep(1000);
                    Application.DoEvents();
                    Thread.Sleep(1000);
                    Application.DoEvents();
                    break;
                }
                else
                {
                    Application.DoEvents();
                }
            }
        }

        void dialer_StateChanged(object sender, StateChangedEventArgs e)
        {
            if (e.State == RasConnectionState.Connected)
            {
                bDialCompleted = true;
            }
        }

        private void ClearCookie()
        {
            Controls.Remove(this.wbYahoo);
            Controls.Remove(this.wbBlog);

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
            this.wbBlog.Size = new System.Drawing.Size(523, 525);
            this.wbBlog.TabIndex = 0;
            // 
            // wbBlogDetail
            // 
            //this.wbBlogDetail.Location = new System.Drawing.Point(545, 306);
            //this.wbBlogDetail.MinimumSize = new System.Drawing.Size(20, 20);
            //this.wbBlogDetail.Name = "wbBlogDetail";
            //this.wbBlogDetail.ScriptErrorsSuppressed = true;
            //this.wbBlogDetail.Size = new System.Drawing.Size(523, 256);
            //this.wbBlogDetail.TabIndex = 3;

            SHDocVw.WebBrowser wb = this.wbYahoo.ActiveXInstance as SHDocVw.WebBrowser;
            //wb.BeforeNavigate2 += new SHDocVw.DWebBrowserEvents2_BeforeNavigate2EventHandler(wb_BeforeNavigate2);
            wb.NewWindow2 += new SHDocVw.DWebBrowserEvents2_NewWindow2EventHandler(wb_NewWindow2);
            wb.NewWindow3 += new SHDocVw.DWebBrowserEvents2_NewWindow3EventHandler(wb_NewWindow3);

            SHDocVw.WebBrowser wb2 = this.wbBlog.ActiveXInstance as SHDocVw.WebBrowser;
            wb2.NewWindow2 += new SHDocVw.DWebBrowserEvents2_NewWindow2EventHandler(wb2_NewWindow2);
            //wb2.NewWindow3 += new SHDocVw.DWebBrowserEvents2_NewWindow3EventHandler(wb2_NewWindow3);

            //SHDocVw.WebBrowser wb3 = this.wbBlogDetail.ActiveXInstance as SHDocVw.WebBrowser;
            //wb3.NewWindow2 += new SHDocVw.DWebBrowserEvents2_NewWindow2EventHandler(wb3_NewWindow2);

            Controls.Add(this.wbYahoo);
            Controls.Add(this.wbBlog);
            //Controls.Add(this.wbBlogDetail);
        }

        //void wb2_BeforeNavigate2(object pDisp, ref object URL, ref object Flags, ref object TargetFrameName, ref object PostData, ref object Headers, ref bool Cancel)
        //{
        //    Navigate(wbBlogDetail, URL.ToString());
        //    Cancel = true;
        //}

        //void wb2_NewWindow3(ref object ppDisp, ref bool Cancel, uint dwFlags, string bstrUrlContext, string bstrUrl)
        //{
        //    Navigate(wbBlogDetail, bstrUrl.ToString());
        //    Cancel = true;
        //}

        void wb2_NewWindow2(ref object ppDisp, ref bool Cancel)
        {
            Cancel = true;
        }

        void wb3_NewWindow2(ref object ppDisp, ref bool Cancel)
        {
            Cancel = true;
        }
        private void refreshTimer_OnRefresh(string strMainLink, string strLinks)
        {
            try
            {
                int sleep = new Random(2).Next(5);

                this.ClearCookie();
                this.Navigate(this.wbYahoo, strMainLink);

                Application.DoEvents();
                this.Wait();
                for (int i = 0; i <= 30; i++)
                {
                    Thread.Sleep(500);
                    if (wbYahoo.ReadyState != WebBrowserReadyState.Complete || wbYahoo.Url.ToString() == strMainLink)
                    {
                        Application.DoEvents();
                    }
                    else
                    {
                        break;
                    }
                }
                this.ScrollToBottom(this.wbYahoo);

                List<string> lstUrls = new List<string>();
                string[] links = strLinks.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string link in links)
                {
                    lstUrls.Add(link);
                }

                //搜索結果頁面 翻頁
                try
                {
                    #region 匹配搜索結果頁面
                    for (int j = 0; j < wbYahoo.Document.Links.Count; j++)
                    {
                        //搜索結果部分 Begin
                        string url = wbYahoo.Document.Links[j].GetAttribute("href");
                        if (lstUrls.Contains(url))
                        {
                            //點擊搜索結果
                            wbYahoo.Document.Links[j].InvokeMember("click");
                            Application.DoEvents();
                            for (int i = 0; i <= 30; i++)
                            {
                                Thread.Sleep(500);
                                if (wbBlog.ReadyState != WebBrowserReadyState.Complete)
                                {
                                    Application.DoEvents();
                                }
                                else
                                {
                                    break;
                                }
                            }
                            this.ScrollToBottom(this.wbBlog);

                            Navigate(wbBlog, "about:blank");
                        }
                        //搜索結果部分 End

                    }
                    #endregion
                }
                catch (Exception ex)
                {
                }
                Navigate(wbYahoo, "about:blank");

                //搜索結果頁面 翻頁 End

            }
            catch (Exception ex)
            {
            }
        }

        private List<string> GetRandomPageUrl(HtmlElementCollection links)
        {
            List<string> urls = new List<string>();
            foreach (HtmlElement a in links)
            {
                string href = a.GetAttribute("href");
                if (href.Contains("s?wd=") && href.Contains("pn="))
                {
                    urls.Add(href);
                }
            }
            if (urls.Count > 0)
            {
                int num = 0;
                if (urls.Count >= 5)
                {
                    num = new Random().Next(0, 4);
                }
                else
                {
                    num = new Random().Next(0, urls.Count - 1);
                }
                return urls.Take<string>((num + 1)).Skip<string>(1).ToList<string>();
            }
            return new List<string>();
        }

        private string GetRandomUrl(HtmlElementCollection links)
        {
            List<string> urls = new List<string>();
            int skip = 0;
            if (links.Count > 0x12)
            {
                skip = 0x12;
            }
            foreach (HtmlElement a in links)
            {
                if (skip > 0)
                {
                    skip--;
                }
                else
                {
                    string href = a.GetAttribute("href");
                    if ((href.StartsWith("http") && (a.InnerHtml != null)) && a.InnerHtml.Contains("<EM>"))
                    {
                        urls.Add(href);
                    }
                }
            }
            if (urls.Count > 0)
            {
                int num = new Random().Next(0, urls.Count - 1);
                return urls[num];
            }
            return "";
        }

        private void Navigate(WebBrowser wbr, string url)
        {
            wbr.Navigate(url);
            for (int i = 0; i <= 60; i++)
            {
                Thread.Sleep(500);
                if (wbr.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }
                else
                {
                    break;
                }
            }
        }
        private void ScrollToBottom(WebBrowser wbx)
        {
            try
            {
                int y = int.Parse(wbx.Document.Body.GetAttribute("ScrollHeight"));
                wbx.Document.Window.ScrollTo(0, y);
                Thread.Sleep(500);
                Application.DoEvents();
            }
            catch
            {
            }
        }
        private void Wait()
        {
            int delay = new Random(3).Next(6);
            DateTime now = DateTime.Now;
            DateTime endTime = DateTime.Now;
            int num = GetElapsedTimeInSeconds(now, endTime);
            Application.DoEvents();
            while (num < delay)
            {
                Application.DoEvents();
                num = GetElapsedTimeInSeconds(now, DateTime.Now);
            }
        }
        private static int GetElapsedTimeInSeconds(DateTime startTime, DateTime endTime)
        {
            TimeSpan ts = (TimeSpan)(endTime - startTime);
            return Convert.ToInt32(ts.TotalSeconds);
        }

        private void 關鍵字設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKeywords frm = new frmKeywords();
            frm.ShowDialog();
        }

        private void aDSL設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmADSL frm = new frmADSL();
            frm.ShowDialog();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
            this.Close();
        }

        private void 開始搜尋ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DB_Access db = new DB_Access();
            DataTable dt = db.Query("select * from adsl");

            if (dt != null && dt.Rows.Count > 0)
            {
                strAd_EntryName = dt.Rows[0]["EntryName"].ToString();
                strAd_userName = dt.Rows[0]["userName"].ToString();
                strAd_pwd = dt.Rows[0]["pwd"].ToString();
            }

            RunKeyword();
        }

        private void 其它設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSetting frm = new frmSetting();
            frm.ShowDialog();
        }
    }
}
