using ManagementSoftware.DAL.DALPagination;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.GUI.Section.ThongKe;
using ManagementSoftware.Models;
using ManagementSoftware.PLCSetting;
using Syncfusion.XPS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ManagementSoftware.GUI
{
    public partial class BauNong : Form
    {
        public delegate void CallAlert(string msg, FormAlert.enmType type);
        public CallAlert callAlert;

        // ngày để query 
        private DateTime? timeStart = null;
        private DateTime? timeEnd = null;
        // trang hiện tại
        private int page = 1;



        // tổng số trang
        private int TotalPages = 0;
        //Data
        Dictionary<TestBauNong, List<Models.BauNong>> ListResults;



        Thread ThreadGetDataPLC;
        System.Timers.Timer aTimer;
        public BauNong()
        {
            InitializeComponent();

            ThreadGetDataPLC = new Thread(() =>
            {
                aTimer = new System.Timers.Timer();
                aTimer.Elapsed += new ElapsedEventHandler(MyTimer_Tick);
                aTimer.Interval = 500;
                aTimer.Start();
            });
            ThreadGetDataPLC.Start();
        }
        ~BauNong()
        {
            aTimer.Stop();
            aTimer.Dispose();
            ThreadGetDataPLC.Abort();
        }

        void LoadFormThongKe()
        {
            panel2.Enabled = false;
            foreach (Form item in panelThongKe.Controls)
            {
                item.Close();
                item.Dispose();
            }
            panelThongKe.Controls.Clear();


            PaginationBauNong pagination = new PaginationBauNong();
            pagination.Set(page, timeStart, timeEnd);
            this.ListResults = pagination.ListResults;
            this.TotalPages = pagination.TotalPages;
            lbTotalPages.Text = this.TotalPages.ToString();

            buttonPreviousPage.Enabled = this.page > 1;
            buttonNextPage.Enabled = this.page < this.TotalPages;
            buttonPage.Text = this.page.ToString();

            pageNumberGoto.MinValue = 1;
            pageNumberGoto.MaxValue = this.TotalPages != 0 ? this.TotalPages : 1;

            for (int i = ListResults.Count - 1; i >= 0; i--)
            {
                ItemThongKeBauNong form = new ItemThongKeBauNong(ListResults.ElementAt(i).Key, ListResults.ElementAt(i).Value);
                form.TopLevel = false;
                panelThongKe.Controls.Add(form);
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Top;
                form.Show();
            }
            panel2.Enabled = true;
        }

        private void buttonPreviousPage_Click(object sender, EventArgs e)
        {
            if (this.page > 1)
            {
                this.page = this.page - 1;
                LoadFormThongKe();
            }
        }

        private void buttonNextPage_Click(object sender, EventArgs e)
        {
            if (this.page < this.TotalPages)
            {
                this.page = this.page + 1;
                LoadFormThongKe();
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            timeStart = TimeStart.Value;
            timeEnd = TimeEnd.Value;
            LoadFormThongKe();
        }

        private void buttonGoto_Click(object sender, EventArgs e)
        {
            this.page = int.Parse(pageNumberGoto.Text);
            LoadFormThongKe();
        }


















        // Giam sat

        delegate void SetTextControlCallback(Control control, string text);
        private void SetTextControl(Control control, string text)
        {

            if (control.InvokeRequired && control != null)
            {

                SetTextControlCallback d = new SetTextControlCallback(SetTextControl);
                if (control.IsDisposed == false && this.IsDisposed == false)
                {
                    this.Invoke(d, new object[] { control, text });
                }
            }
            else
            {
                control.Text = text;
            }

        }


        private void MyTimer_Tick(object sender, EventArgs e)
        {
            PLCBauNong plcMain = new PLCBauNong();

            plcMain.Start();

            if (plcMain.plc.IsConnected == true && aTimer.Enabled == true)
            {
                plcMain.GetData();
                foreach (Models.BauNong item in plcMain.listBauNong)
                {
                    if (item.BauNongName == TenThietBi.BauNong1)
                    {
                        SetTextControl(DongAC1, item.DongDienAC.ToString());
                        SetTextControl(NhietDo1, item.NhietDo.ToString());
                        SetTextControl(NhietDoNgatCB1, item.NhietDoNgatCBNhiet.ToString());
                        SetTextControl(SoLanTest1, item.SoLanTest.ToString());
                        if (item.CBNhietThanBauNong == true)
                        {
                            SetTextControl(CBNhiet1, "on");
                        }
                        else
                        {
                            SetTextControl(CBNhiet1, "off");
                        }
                    }
                    else if (item.BauNongName == TenThietBi.BauNong2)
                    {
                        SetTextControl(DongAC2, item.DongDienAC.ToString());
                        SetTextControl(NhietDo2, item.NhietDo.ToString());
                        SetTextControl(NhietDoNgatCB2, item.NhietDoNgatCBNhiet.ToString());
                        SetTextControl(SoLanTest2, item.SoLanTest.ToString());
                        if (item.CBNhietThanBauNong == true)
                        {
                            SetTextControl(CBNhiet2, "on");
                        }
                        else
                        {
                            SetTextControl(CBNhiet2, "off");
                        }
                    }
                    else if (item.BauNongName == TenThietBi.BauNong3)
                    {
                        SetTextControl(DongAC3, item.DongDienAC.ToString());
                        SetTextControl(NhietDo3, item.NhietDo.ToString());
                        SetTextControl(NhietDoNgatCB3, item.NhietDoNgatCBNhiet.ToString());
                        SetTextControl(SoLanTest3, item.SoLanTest.ToString());
                        if (item.CBNhietThanBauNong == true)
                        {
                            SetTextControl(CBNhiet3, "on");
                        }
                        else
                        {
                            SetTextControl(CBNhiet3, "off");
                        }
                    }
                    else if (item.BauNongName == TenThietBi.BauNong4)
                    {
                        SetTextControl(DongAC4, item.DongDienAC.ToString());
                        SetTextControl(NhietDo4, item.NhietDo.ToString());
                        SetTextControl(NhietDoNgatCB4, item.NhietDoNgatCBNhiet.ToString());
                        SetTextControl(SoLanTest4, item.SoLanTest.ToString());
                        if (item.CBNhietThanBauNong == true)
                        {
                            SetTextControl(CBNhiet4, "on");
                        }
                        else
                        {
                            SetTextControl(CBNhiet4, "off");
                        }
                    }
                    else if (item.BauNongName == TenThietBi.BauNong5)
                    {
                        SetTextControl(DongAC5, item.DongDienAC.ToString());
                        SetTextControl(NhietDo5, item.NhietDo.ToString());
                        SetTextControl(NhietDoNgatCB5, item.NhietDoNgatCBNhiet.ToString());
                        SetTextControl(SoLanTest5, item.SoLanTest.ToString());
                        if (item.CBNhietThanBauNong == true)
                        {
                            SetTextControl(CBNhiet5, "on");
                        }
                        else
                        {
                            SetTextControl(CBNhiet5, "off");
                        }
                    }
                    else if (item.BauNongName == TenThietBi.BauNong6)
                    {
                        SetTextControl(DongAC6, item.DongDienAC.ToString());
                        SetTextControl(NhietDo6, item.NhietDo.ToString());
                        SetTextControl(NhietDoNgatCB6, item.NhietDoNgatCBNhiet.ToString());
                        SetTextControl(SoLanTest6, item.SoLanTest.ToString());
                        if (item.CBNhietThanBauNong == true)
                        {
                            SetTextControl(CBNhiet6, "on");
                        }
                        else
                        {
                            SetTextControl(CBNhiet6, "off");
                        }
                    }
                    else if (item.BauNongName == TenThietBi.BauNong7)
                    {
                        SetTextControl(DongAC7, item.DongDienAC.ToString());
                        SetTextControl(NhietDo7, item.NhietDo.ToString());
                        SetTextControl(NhietDoNgatCB7, item.NhietDoNgatCBNhiet.ToString());
                        SetTextControl(SoLanTest7, item.SoLanTest.ToString());
                        if (item.CBNhietThanBauNong == true)
                        {
                            SetTextControl(CBNhiet7, "on");
                        }
                        else
                        {
                            SetTextControl(CBNhiet7, "off");
                        }
                    }
                    else if (item.BauNongName == TenThietBi.BauNong8)
                    {
                        SetTextControl(DongAC8, item.DongDienAC.ToString());
                        SetTextControl(NhietDo8, item.NhietDo.ToString());
                        SetTextControl(NhietDoNgatCB8, item.NhietDoNgatCBNhiet.ToString());
                        SetTextControl(SoLanTest8, item.SoLanTest.ToString());
                        if (item.CBNhietThanBauNong == true)
                        {
                            SetTextControl(CBNhiet8, "on");
                        }
                        else
                        {
                            SetTextControl(CBNhiet8, "off");
                        }
                    }
                    else if (item.BauNongName == TenThietBi.BauNong9)
                    {
                        SetTextControl(DongAC9, item.DongDienAC.ToString());
                        SetTextControl(NhietDo9, item.NhietDo.ToString());
                        SetTextControl(NhietDoNgatCB9, item.NhietDoNgatCBNhiet.ToString());
                        SetTextControl(SoLanTest9, item.SoLanTest.ToString());
                        if (item.CBNhietThanBauNong == true)
                        {
                            SetTextControl(CBNhiet9, "on");
                        }
                        else
                        {
                            SetTextControl(CBNhiet9, "off");
                        }
                    }
                    else if (item.BauNongName == TenThietBi.BauNong10)
                    {
                        SetTextControl(DongAC10, item.DongDienAC.ToString());
                        SetTextControl(NhietDo10, item.NhietDo.ToString());
                        SetTextControl(NhietDoNgatCB10, item.NhietDoNgatCBNhiet.ToString());
                        SetTextControl(SoLanTest10, item.SoLanTest.ToString());
                        if (item.CBNhietThanBauNong == true)
                        {
                            SetTextControl(CBNhiet10, "on");
                        }
                        else
                        {
                            SetTextControl(CBNhiet10, "off");
                        }
                    }

                }
            }

            plcMain.Stop();
        }

        private void BauNong_FormClosing(object sender, FormClosingEventArgs e)
        {
            aTimer.Stop();
            aTimer.Dispose();
        }
    }
}
