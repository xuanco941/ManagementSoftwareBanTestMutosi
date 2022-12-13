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

            if (PLCNguon.plc.IsConnected == true)
            {
                ThreadGetDataPLC = new Thread(() =>
                {
                    aTimer = new System.Timers.Timer();
                    aTimer.Elapsed += new ElapsedEventHandler(MyTimer_Tick);
                    aTimer.Interval = 500;
                    aTimer.Start();
                });
                ThreadGetDataPLC.Start();
            }
            LoadFormThongKe();

        }
        ~Nguon()
        {
            if (aTimer != null)
            {
                aTimer.Stop();
                aTimer.Dispose();
            }
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

            if (control.InvokeRequired)
            {

                SetTextControlCallback d = new SetTextControlCallback(SetTextControl);

                this.Invoke(d, new object[] { control, text });
            }
            else
            {
                control.Text = text;
            }

        }


        private void MyTimer_Tick(object sender, EventArgs eb)
        {

            PLCNguon.GetData();
            foreach (Models.Nguon e in PLCNguon.listNguon.ToList())
            {
                if (e.NguonName == TenThietBi.Nguon1)
                {
                    SetTextControl(DongDC1, e.DongDC.ToString() + " A");
                    SetTextControl(DienApDC1, e.DienApDC.ToString() + " V");
                    SetTextControl(CongSuat1, e.CongSuat.ToString() + " W");
                    SetTextControl(timeTest1, e.ThoiGianTest.ToString() + " giây");
                    SetTextControl(SoLanTest1, e.SoLanTest.ToString());


                    //DongDC1.Invoke(new Action(() =>
                    //{
                    //    DongDC1.Text = e.DongDC.ToString() + " A";
                    //}));
                    //DienApDC1.Invoke(new Action(() =>
                    //{
                    //    DienApDC1.Text = e.DienApDC.ToString() + " V";
                    //}));
                    //CongSuat1.Invoke(new Action(() =>
                    //{
                    //    CongSuat1.Text = e.CongSuat.ToString() + " W";
                    //}));
                    //timeTest1.Invoke(new Action(() =>
                    //{
                    //    timeTest1.Text = e.ThoiGianTest.ToString() + " giây";
                    //}));
                    //SoLanTest1.Invoke(new Action(() =>
                    //{
                    //    SoLanTest1.Text = e.SoLanTest.ToString();
                    //}));
                }
                else if (e.NguonName == TenThietBi.Nguon2)
                {
                    DongDC2.Invoke(new Action(() =>
                    {
                        DongDC2.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC2.Invoke(new Action(() =>
                    {
                        DienApDC2.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat2.Invoke(new Action(() =>
                    {
                        CongSuat2.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest2.Invoke(new Action(() =>
                    {
                        timeTest2.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest2.Invoke(new Action(() =>
                    {
                        SoLanTest2.Text = e.SoLanTest.ToString();
                    }));

                }
                else if (e.NguonName == TenThietBi.Nguon3)
                {
                    DongDC3.Invoke(new Action(() =>
                    {
                        DongDC3.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC3.Invoke(new Action(() =>
                    {
                        DienApDC3.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat3.Invoke(new Action(() =>
                    {
                        CongSuat3.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest3.Invoke(new Action(() =>
                    {
                        timeTest3.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest3.Invoke(new Action(() =>
                    {
                        SoLanTest3.Text = e.SoLanTest.ToString();
                    }));

                }
                else if (e.NguonName == TenThietBi.Nguon4)
                {
                    DongDC4.Invoke(new Action(() =>
                    {
                        DongDC4.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC4.Invoke(new Action(() =>
                    {
                        DienApDC4.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat4.Invoke(new Action(() =>
                    {
                        CongSuat4.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest4.Invoke(new Action(() =>
                    {
                        timeTest4.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest4.Invoke(new Action(() =>
                    {
                        SoLanTest4.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon5)
                {
                    DongDC5.Invoke(new Action(() =>
                    {
                        DongDC5.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC5.Invoke(new Action(() =>
                    {
                        DienApDC5.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat5.Invoke(new Action(() =>
                    {
                        CongSuat5.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest5.Invoke(new Action(() =>
                    {
                        timeTest5.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest5.Invoke(new Action(() =>
                    {
                        SoLanTest5.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon6)
                {
                    DongDC6.Invoke(new Action(() =>
                    {
                        DongDC6.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC6.Invoke(new Action(() =>
                    {
                        DienApDC6.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat6.Invoke(new Action(() =>
                    {
                        CongSuat6.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest6.Invoke(new Action(() =>
                    {
                        timeTest6.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest6.Invoke(new Action(() =>
                    {
                        SoLanTest6.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon7)
                {
                    DongDC7.Invoke(new Action(() =>
                    {
                        DongDC7.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC7.Invoke(new Action(() =>
                    {
                        DienApDC7.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat7.Invoke(new Action(() =>
                    {
                        CongSuat7.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest7.Invoke(new Action(() =>
                    {
                        timeTest7.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest7.Invoke(new Action(() =>
                    {
                        SoLanTest7.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon8)
                {
                    DongDC8.Invoke(new Action(() =>
                    {
                        DongDC8.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC8.Invoke(new Action(() =>
                    {
                        DienApDC8.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat8.Invoke(new Action(() =>
                    {
                        CongSuat8.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest8.Invoke(new Action(() =>
                    {
                        timeTest8.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest8.Invoke(new Action(() =>
                    {
                        SoLanTest8.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon9)
                {
                    DongDC9.Invoke(new Action(() =>
                    {
                        DongDC9.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC9.Invoke(new Action(() =>
                    {
                        DienApDC9.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat9.Invoke(new Action(() =>
                    {
                        CongSuat9.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest9.Invoke(new Action(() =>
                    {
                        timeTest9.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest9.Invoke(new Action(() =>
                    {
                        SoLanTest9.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon10)
                {
                    DongDC10.Invoke(new Action(() =>
                    {
                        DongDC10.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC10.Invoke(new Action(() =>
                    {
                        DienApDC10.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat10.Invoke(new Action(() =>
                    {
                        CongSuat10.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest10.Invoke(new Action(() =>
                    {
                        timeTest10.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest10.Invoke(new Action(() =>
                    {
                        SoLanTest10.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon11)
                {
                    DongDC11.Invoke(new Action(() =>
                    {
                        DongDC11.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC11.Invoke(new Action(() =>
                    {
                        DienApDC11.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat11.Invoke(new Action(() =>
                    {
                        CongSuat11.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest11.Invoke(new Action(() =>
                    {
                        timeTest11.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest11.Invoke(new Action(() =>
                    {
                        SoLanTest11.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon12)
                {
                    DongDC12.Invoke(new Action(() =>
                    {
                        DongDC12.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC12.Invoke(new Action(() =>
                    {
                        DienApDC12.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat12.Invoke(new Action(() =>
                    {
                        CongSuat12.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest12.Invoke(new Action(() =>
                    {
                        timeTest12.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest12.Invoke(new Action(() =>
                    {
                        SoLanTest12.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon13)
                {
                    DongDC13.Invoke(new Action(() =>
                    {
                        DongDC13.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC13.Invoke(new Action(() =>
                    {
                        DienApDC13.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat13.Invoke(new Action(() =>
                    {
                        CongSuat13.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest13.Invoke(new Action(() =>
                    {
                        timeTest13.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest13.Invoke(new Action(() =>
                    {
                        SoLanTest13.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon14)
                {
                    DongDC14.Invoke(new Action(() =>
                    {
                        DongDC14.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC14.Invoke(new Action(() =>
                    {
                        DienApDC14.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat14.Invoke(new Action(() =>
                    {
                        CongSuat14.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest14.Invoke(new Action(() =>
                    {
                        timeTest14.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest14.Invoke(new Action(() =>
                    {
                        SoLanTest14.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon15)
                {
                    DongDC15.Invoke(new Action(() =>
                    {
                        DongDC15.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC15.Invoke(new Action(() =>
                    {
                        DienApDC15.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat15.Invoke(new Action(() =>
                    {
                        CongSuat15.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest15.Invoke(new Action(() =>
                    {
                        timeTest15.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest15.Invoke(new Action(() =>
                    {
                        SoLanTest15.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon16)
                {
                    DongDC16.Invoke(new Action(() =>
                    {
                        DongDC16.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC16.Invoke(new Action(() =>
                    {
                        DienApDC16.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat16.Invoke(new Action(() =>
                    {
                        CongSuat16.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest16.Invoke(new Action(() =>
                    {
                        timeTest16.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest16.Invoke(new Action(() =>
                    {
                        SoLanTest16.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon17)
                {
                    DongDC17.Invoke(new Action(() =>
                    {
                        DongDC17.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC17.Invoke(new Action(() =>
                    {
                        DienApDC17.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat17.Invoke(new Action(() =>
                    {
                        CongSuat17.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest17.Invoke(new Action(() =>
                    {
                        timeTest17.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest17.Invoke(new Action(() =>
                    {
                        SoLanTest17.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon18)
                {
                    DongDC18.Invoke(new Action(() =>
                    {
                        DongDC18.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC18.Invoke(new Action(() =>
                    {
                        DienApDC18.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat18.Invoke(new Action(() =>
                    {
                        CongSuat18.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest18.Invoke(new Action(() =>
                    {
                        timeTest18.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest18.Invoke(new Action(() =>
                    {
                        SoLanTest18.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon19)
                {
                    DongDC19.Invoke(new Action(() =>
                    {
                        DongDC19.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC19.Invoke(new Action(() =>
                    {
                        DienApDC19.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat19.Invoke(new Action(() =>
                    {
                        CongSuat19.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest19.Invoke(new Action(() =>
                    {
                        timeTest19.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest19.Invoke(new Action(() =>
                    {
                        SoLanTest19.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon20)
                {
                    DongDC20.Invoke(new Action(() =>
                    {
                        DongDC20.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC20.Invoke(new Action(() =>
                    {
                        DienApDC20.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat20.Invoke(new Action(() =>
                    {
                        CongSuat20.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest20.Invoke(new Action(() =>
                    {
                        timeTest20.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest20.Invoke(new Action(() =>
                    {
                        SoLanTest20.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon21)
                {
                    DongDC21.Invoke(new Action(() =>
                    {
                        DongDC21.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC21.Invoke(new Action(() =>
                    {
                        DienApDC21.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat21.Invoke(new Action(() =>
                    {
                        CongSuat21.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest21.Invoke(new Action(() =>
                    {
                        timeTest21.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest21.Invoke(new Action(() =>
                    {
                        SoLanTest21.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon22)
                {
                    DongDC22.Invoke(new Action(() =>
                    {
                        DongDC22.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC22.Invoke(new Action(() =>
                    {
                        DienApDC22.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat22.Invoke(new Action(() =>
                    {
                        CongSuat22.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest22.Invoke(new Action(() =>
                    {
                        timeTest22.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest22.Invoke(new Action(() =>
                    {
                        SoLanTest22.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon23)
                {
                    DongDC23.Invoke(new Action(() =>
                    {
                        DongDC23.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC23.Invoke(new Action(() =>
                    {
                        DienApDC23.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat23.Invoke(new Action(() =>
                    {
                        CongSuat23.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest23.Invoke(new Action(() =>
                    {
                        timeTest23.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest23.Invoke(new Action(() =>
                    {
                        SoLanTest23.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon24)
                {
                    DongDC24.Invoke(new Action(() =>
                    {
                        DongDC24.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC24.Invoke(new Action(() =>
                    {
                        DienApDC24.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat24.Invoke(new Action(() =>
                    {
                        CongSuat24.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest24.Invoke(new Action(() =>
                    {
                        timeTest24.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest24.Invoke(new Action(() =>
                    {
                        SoLanTest24.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon25)
                {
                    DongDC25.Invoke(new Action(() =>
                    {
                        DongDC25.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC25.Invoke(new Action(() =>
                    {
                        DienApDC25.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat25.Invoke(new Action(() =>
                    {
                        CongSuat25.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest25.Invoke(new Action(() =>
                    {
                        timeTest25.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest25.Invoke(new Action(() =>
                    {
                        SoLanTest25.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon26)
                {
                    DongDC26.Invoke(new Action(() =>
                    {
                        DongDC26.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC26.Invoke(new Action(() =>
                    {
                        DienApDC26.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat26.Invoke(new Action(() =>
                    {
                        CongSuat26.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest26.Invoke(new Action(() =>
                    {
                        timeTest26.Text = e.ThoiGianTest.ToString() +" giây";
                    }));
                    SoLanTest26.Invoke(new Action(() =>
                    {
                        SoLanTest26.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon27)
                {
                    DongDC27.Invoke(new Action(() =>
                    {
                        DongDC27.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC27.Invoke(new Action(() =>
                    {
                        DienApDC27.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat27.Invoke(new Action(() =>
                    {
                        CongSuat27.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest27.Invoke(new Action(() =>
                    {
                        timeTest27.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest27.Invoke(new Action(() =>
                    {
                        SoLanTest27.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon28)
                {
                    DongDC28.Invoke(new Action(() =>
                    {
                        DongDC28.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC28.Invoke(new Action(() =>
                    {
                        DienApDC28.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat28.Invoke(new Action(() =>
                    {
                        CongSuat28.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest28.Invoke(new Action(() =>
                    {
                        timeTest28.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest28.Invoke(new Action(() =>
                    {
                        SoLanTest28.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon29)
                {
                    DongDC29.Invoke(new Action(() =>
                    {
                        DongDC29.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC29.Invoke(new Action(() =>
                    {
                        DienApDC29.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat29.Invoke(new Action(() =>
                    {
                        CongSuat29.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest29.Invoke(new Action(() =>
                    {
                        timeTest29.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest29.Invoke(new Action(() =>
                    {
                        SoLanTest29.Text = e.SoLanTest.ToString();
                    }));
                }
                else if (e.NguonName == TenThietBi.Nguon30)
                {
                    DongDC30.Invoke(new Action(() =>
                    {
                        DongDC30.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC30.Invoke(new Action(() =>
                    {
                        DienApDC30.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat30.Invoke(new Action(() =>
                    {
                        CongSuat30.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest30.Invoke(new Action(() =>
                    {
                        timeTest30.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest30.Invoke(new Action(() =>
                    {
                        SoLanTest30.Text = e.SoLanTest.ToString();
                    }));
                }
            }
        }

        private void Nguon_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (aTimer != null)
            {
                aTimer.Stop();
                aTimer.Dispose();
            }
        }
    }


}
