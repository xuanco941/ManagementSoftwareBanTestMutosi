using ManagementSoftware.DAL.DALPagination;
using ManagementSoftware.GUI.Section;
using ManagementSoftware.GUI.Section.ThongKe;
using ManagementSoftware.Models;
using ManagementSoftware.PLCSetting;
using PROFINET_STEP_7.Profinet;
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
    public partial class Nguon : Form
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
        Dictionary<TestNguon, List<Models.Nguon>> ListResults;
        Thread ThreadGetDataPLC;
        System.Timers.Timer aTimer;
        public Nguon()
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
        ~Nguon()
        {
            aTimer.Stop();
            aTimer.Dispose();
            ThreadGetDataPLC.Abort();
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

        private void LoadFormThongKe()
        {
            panel2.Enabled = false;
            foreach (Form item in panelThongKe.Controls)
            {
                item.Close();
                item.Dispose();
            }
            panelThongKe.Controls.Clear();


            PaginationNguon pagination = new PaginationNguon();
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
                ItemThongKeNguon form = new ItemThongKeNguon(ListResults.ElementAt(i).Key, ListResults.ElementAt(i).Value);
                form.TopLevel = false;
                panelThongKe.Controls.Add(form);
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Top;
                form.Show();
            }
            panel2.Enabled = true;

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


        private void MyTimer_Tick(object sender, EventArgs eb)
        {
            PLCNguon plcMain = new PLCNguon();
            plcMain.Start();


            if (plcMain.plc.IsConnected == true)
            {
                plcMain.GetData();
                foreach (Models.Nguon e in plcMain.listNguon)
                {
                    if (e.NguonName == TenThietBi.Nguon1)
                    {
                        DongDC1.Text = e.DongDC.ToString() + " A";
                        DienApDC1.Text = e.DienApDC.ToString() + " V";
                        CongSuat1.Text = e.CongSuat.ToString() + " W";
                        timeTest1.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest1.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon2)
                    {
                        DongDC2.Text = e.DongDC.ToString() + " A";
                        DienApDC2.Text = e.DienApDC.ToString() + " V";
                        CongSuat2.Text = e.CongSuat.ToString() + " W";
                        timeTest2.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest2.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon3)
                    {
                        DongDC3.Text = e.DongDC.ToString() + " A";
                        DienApDC3.Text = e.DienApDC.ToString() + " V";
                        CongSuat3.Text = e.CongSuat.ToString() + " W";
                        timeTest3.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest3.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon4)
                    {
                        DongDC4.Text = e.DongDC.ToString() + " A";
                        DienApDC4.Text = e.DienApDC.ToString() + " V";
                        CongSuat4.Text = e.CongSuat.ToString() + " W";
                        timeTest4.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest4.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon5)
                    {
                        DongDC5.Text = e.DongDC.ToString() + " A";
                        DienApDC5.Text = e.DienApDC.ToString() + " V";
                        CongSuat5.Text = e.CongSuat.ToString() + " W";
                        timeTest5.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest5.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon6)
                    {
                        DongDC6.Text = e.DongDC.ToString() + " A";
                        DienApDC6.Text = e.DienApDC.ToString() + " V";
                        CongSuat6.Text = e.CongSuat.ToString() + " W";
                        timeTest6.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest6.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon7)
                    {
                        DongDC7.Text = e.DongDC.ToString() + " A";
                        DienApDC7.Text = e.DienApDC.ToString() + " V";
                        CongSuat7.Text = e.CongSuat.ToString() + " W";
                        timeTest7.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest7.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon8)
                    {
                        DongDC8.Text = e.DongDC.ToString() + " A";
                        DienApDC8.Text = e.DienApDC.ToString() + " V";
                        CongSuat8.Text = e.CongSuat.ToString() + " W";
                        timeTest8.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest8.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon9)
                    {
                        DongDC9.Text = e.DongDC.ToString() + " A";
                        DienApDC9.Text = e.DienApDC.ToString() + " V";
                        CongSuat9.Text = e.CongSuat.ToString() + " W";
                        timeTest9.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest9.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon10)
                    {
                        DongDC10.Text = e.DongDC.ToString() + " A";
                        DienApDC10.Text = e.DienApDC.ToString() + " V";
                        CongSuat10.Text = e.CongSuat.ToString() + " W";
                        timeTest10.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest10.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon11)
                    {
                        DongDC11.Text = e.DongDC.ToString() + " A";
                        DienApDC11.Text = e.DienApDC.ToString() + " V";
                        CongSuat11.Text = e.CongSuat.ToString() + " W";
                        timeTest11.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest11.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon12)
                    {
                        DongDC12.Text = e.DongDC.ToString() + " A";
                        DienApDC12.Text = e.DienApDC.ToString() + " V";
                        CongSuat12.Text = e.CongSuat.ToString() + " W";
                        timeTest12.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest12.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon13)
                    {
                        DongDC13.Text = e.DongDC.ToString() + " A";
                        DienApDC13.Text = e.DienApDC.ToString() + " V";
                        CongSuat13.Text = e.CongSuat.ToString() + " W";
                        timeTest13.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest13.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon14)
                    {
                        DongDC14.Text = e.DongDC.ToString() + " A";
                        DienApDC14.Text = e.DienApDC.ToString() + " V";
                        CongSuat14.Text = e.CongSuat.ToString() + " W";
                        timeTest14.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest14.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon15)
                    {
                        DongDC15.Text = e.DongDC.ToString() + " A";
                        DienApDC15.Text = e.DienApDC.ToString() + " V";
                        CongSuat15.Text = e.CongSuat.ToString() + " W";
                        timeTest15.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest15.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon16)
                    {
                        DongDC16.Text = e.DongDC.ToString() + " A";
                        DienApDC16.Text = e.DienApDC.ToString() + " V";
                        CongSuat16.Text = e.CongSuat.ToString() + " W";
                        timeTest16.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest16.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon17)
                    {
                        DongDC17.Text = e.DongDC.ToString() + " A";
                        DienApDC17.Text = e.DienApDC.ToString() + " V";
                        CongSuat17.Text = e.CongSuat.ToString() + " W";
                        timeTest17.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest17.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon18)
                    {
                        DongDC18.Text = e.DongDC.ToString() + " A";
                        DienApDC18.Text = e.DienApDC.ToString() + " V";
                        CongSuat18.Text = e.CongSuat.ToString() + " W";
                        timeTest18.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest18.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon19)
                    {
                        DongDC19.Text = e.DongDC.ToString() + " A";
                        DienApDC19.Text = e.DienApDC.ToString() + " V";
                        CongSuat19.Text = e.CongSuat.ToString() + " W";
                        timeTest19.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest19.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon20)
                    {
                        DongDC20.Text = e.DongDC.ToString() + " A";
                        DienApDC20.Text = e.DienApDC.ToString() + " V";
                        CongSuat20.Text = e.CongSuat.ToString() + " W";
                        timeTest20.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest20.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon21)
                    {
                        DongDC21.Text = e.DongDC.ToString() + " A";
                        DienApDC21.Text = e.DienApDC.ToString() + " V";
                        CongSuat21.Text = e.CongSuat.ToString() + " W";
                        timeTest21.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest21.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon22)
                    {
                        DongDC22.Text = e.DongDC.ToString() + " A";
                        DienApDC22.Text = e.DienApDC.ToString() + " V";
                        CongSuat22.Text = e.CongSuat.ToString() + " W";
                        timeTest22.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest22.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon23)
                    {
                        DongDC23.Text = e.DongDC.ToString() + " A";
                        DienApDC23.Text = e.DienApDC.ToString() + " V";
                        CongSuat23.Text = e.CongSuat.ToString() + " W";
                        timeTest23.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest23.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon24)
                    {
                        DongDC24.Text = e.DongDC.ToString() + " A";
                        DienApDC24.Text = e.DienApDC.ToString() + " V";
                        CongSuat24.Text = e.CongSuat.ToString() + " W";
                        timeTest24.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest24.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon25)
                    {
                        DongDC25.Text = e.DongDC.ToString() + " A";
                        DienApDC25.Text = e.DienApDC.ToString() + " V";
                        CongSuat25.Text = e.CongSuat.ToString() + " W";
                        timeTest25.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest25.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon26)
                    {
                        DongDC26.Text = e.DongDC.ToString() + " A";
                        DienApDC26.Text = e.DienApDC.ToString() + " V";
                        CongSuat26.Text = e.CongSuat.ToString() + " W";
                        timeTest26.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest26.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon27)
                    {
                        DongDC27.Text = e.DongDC.ToString() + " A";
                        DienApDC27.Text = e.DienApDC.ToString() + " V";
                        CongSuat27.Text = e.CongSuat.ToString() + " W";
                        timeTest27.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest27.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon28)
                    {
                        DongDC28.Text = e.DongDC.ToString() + " A";
                        DienApDC28.Text = e.DienApDC.ToString() + " V";
                        CongSuat28.Text = e.CongSuat.ToString() + " W";
                        timeTest28.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest28.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon29)
                    {
                        DongDC29.Text = e.DongDC.ToString() + " A";
                        DienApDC29.Text = e.DienApDC.ToString() + " V";
                        CongSuat29.Text = e.CongSuat.ToString() + " W";
                        timeTest29.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest29.Text = e.SoLanTest.ToString();
                    }
                    else if (e.NguonName == TenThietBi.Nguon30)
                    {
                        DongDC30.Text = e.DongDC.ToString() + " A";
                        DienApDC30.Text = e.DienApDC.ToString() + " V";
                        CongSuat30.Text = e.CongSuat.ToString() + " W";
                        timeTest30.Text = e.ThoiGianTest.ToString() + " giây";
                        SoLanTest30.Text = e.SoLanTest.ToString();
                    }
                }
            }

            plcMain.Stop();
        }

        private void Nguon_FormClosing(object sender, FormClosingEventArgs e)
        {
            aTimer.Stop();
            aTimer.Dispose();
        }
    }

    
}
