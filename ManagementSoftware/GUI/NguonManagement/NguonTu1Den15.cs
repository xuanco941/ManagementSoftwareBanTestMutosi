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
    public partial class NguonTu1Den15 : Form
    {
        Thread ThreadGetDataPLC;
        System.Timers.Timer aTimer;
        public NguonTu1Den15()
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

        ~NguonTu1Den15()
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

            PLCNguon.GetDataTu1Den15();
            foreach (Models.Nguon e in PLCNguon.listNguonTu1Den15.ToList())
            {
                if (e.NguonName == TenThietBi.Nguon1)
                {
                    DongDC1.Invoke(new Action(() =>
                    {
                        DongDC1.Text = e.DongDC.ToString() + " A";
                    }));
                    DienApDC1.Invoke(new Action(() =>
                    {
                        DienApDC1.Text = e.DienApDC.ToString() + " V";
                    }));
                    CongSuat1.Invoke(new Action(() =>
                    {
                        CongSuat1.Text = e.CongSuat.ToString() + " W";
                    }));
                    timeTest1.Invoke(new Action(() =>
                    {
                        timeTest1.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                    SoLanTest1.Invoke(new Action(() =>
                    {
                        SoLanTest1.Text = e.SoLanTest.ToString();
                    }));

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
            }
        }

        private void NguonTu1Den15_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (aTimer != null)
            {
                aTimer.Stop();
                aTimer.Dispose();
            }
        }
    }
}
