using ManagementSoftware.PLCSetting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace ManagementSoftware.GUI.NguonManagement
{
    public partial class NguonTu16Den30 : Form
    {
        Thread ThreadGetDataPLC;
        System.Timers.Timer aTimer;
        public NguonTu16Den30()
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
        }

        ~NguonTu16Den30()
        {
            if (aTimer != null)
            {
                aTimer.Stop();
                aTimer.Dispose();
            }
            ThreadGetDataPLC.Abort();
        }




        private void MyTimer_Tick(object sender, EventArgs eb)
        {

            PLCNguon.GetDataTu16Den30();
            foreach (Models.Nguon e in PLCNguon.listNguonTu16Den30.ToList())
            {
                if (e.NguonName == TenThietBi.Nguon16)
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
                        timeTest26.Text = e.ThoiGianTest.ToString() + " giây";
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

        private void NguonTu16Den30_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (aTimer != null)
            {
                aTimer.Stop();
                aTimer.Dispose();
            }
        }
    }
}
