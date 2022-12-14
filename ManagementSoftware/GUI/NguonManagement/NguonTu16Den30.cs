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
                    aTimer.Interval = 1000;
                    aTimer.Start();
                });
                ThreadGetDataPLC.Start();
            }
        }


        private void SetTextNguon(Button dongDC, Button dienApDC, Button congSuat, Button time, Button soLanTest, Models.Nguon e)
        {
            try
            {
                if (dongDC.IsHandleCreated)
                {
                    dongDC.Invoke(new Action(() =>
                    {
                        dongDC.Text = e.DongDC.ToString() + " A";
                    }));
                }
                if (dienApDC.IsHandleCreated)
                {
                    dienApDC.Invoke(new Action(() =>
                    {
                        dienApDC.Text = e.DienApDC.ToString() + " V";
                    }));
                }
                if (congSuat.IsHandleCreated)
                {
                    congSuat.Invoke(new Action(() =>
                    {
                        congSuat.Text = e.CongSuat.ToString() + " W";
                    }));
                }
                if (time.IsHandleCreated)
                {
                    time.Invoke(new Action(() =>
                    {
                        time.Text = e.ThoiGianTest.ToString() + " giây";
                    }));
                }
                if (soLanTest.IsHandleCreated)
                {
                    soLanTest.Invoke(new Action(() =>
                    {
                        soLanTest.Text = e.SoLanTest.ToString();
                    }));
                }
            }
            catch (Exception ex)
            {
            }


        }

        private void MyTimer_Tick(object sender, EventArgs eb)
        {
            if (PLCNguon.plc.IsConnected == true)
            {
                foreach (Models.Nguon e in PLCNguon.listNguonTu16Den30.ToList())
                {
                    if (e.NguonName == TenThietBi.Nguon16)
                    {

                        SetTextNguon(DongDC16, DienApDC16, CongSuat16, timeTest16, SoLanTest16, e);


                    }
                    else if (e.NguonName == TenThietBi.Nguon17)
                    {

                        SetTextNguon(DongDC17, DienApDC17, CongSuat17, timeTest17, SoLanTest17, e);


                    }
                    else if (e.NguonName == TenThietBi.Nguon18)
                    {

                        SetTextNguon(DongDC18, DienApDC18, CongSuat18, timeTest18, SoLanTest18, e);


                    }
                    else if (e.NguonName == TenThietBi.Nguon19)
                    {

                        SetTextNguon(DongDC19, DienApDC19, CongSuat19, timeTest19, SoLanTest19, e);


                    }
                    else if (e.NguonName == TenThietBi.Nguon20)
                    {

                        SetTextNguon(DongDC20, DienApDC20, CongSuat20, timeTest20, SoLanTest20, e);


                    }
                    else if (e.NguonName == TenThietBi.Nguon21)
                    {

                        SetTextNguon(DongDC21, DienApDC21, CongSuat21, timeTest21, SoLanTest21, e);


                    }
                    else if (e.NguonName == TenThietBi.Nguon22)
                    {

                        SetTextNguon(DongDC22, DienApDC22, CongSuat22, timeTest22, SoLanTest22, e);


                    }
                    else if (e.NguonName == TenThietBi.Nguon23)
                    {

                        SetTextNguon(DongDC23, DienApDC23, CongSuat23, timeTest23, SoLanTest23, e);


                    }
                    else if (e.NguonName == TenThietBi.Nguon24)
                    {

                        SetTextNguon(DongDC24, DienApDC24, CongSuat24, timeTest24, SoLanTest24, e);


                    }
                    else if (e.NguonName == TenThietBi.Nguon25)
                    {

                        SetTextNguon(DongDC25, DienApDC25, CongSuat25, timeTest25, SoLanTest25, e);

                    }
                    else if (e.NguonName == TenThietBi.Nguon26)
                    {

                        SetTextNguon(DongDC26, DienApDC26, CongSuat26, timeTest26, SoLanTest26, e);


                    }
                    else if (e.NguonName == TenThietBi.Nguon27)
                    {

                        SetTextNguon(DongDC27, DienApDC27, CongSuat27, timeTest27, SoLanTest27, e);


                    }
                    else if (e.NguonName == TenThietBi.Nguon28)
                    {

                        SetTextNguon(DongDC28, DienApDC28, CongSuat28, timeTest28, SoLanTest28, e);


                    }
                    else if (e.NguonName == TenThietBi.Nguon29)
                    {

                        SetTextNguon(DongDC29, DienApDC29, CongSuat29, timeTest29, SoLanTest29, e);


                    }
                    else if (e.NguonName == TenThietBi.Nguon30)
                    {

                        SetTextNguon(DongDC30, DienApDC30, CongSuat30, timeTest30, SoLanTest30, e);


                    }
                }
            }
            else
            {
                CloseForm();
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
        public void CloseForm()
        {
            if (aTimer != null)
            {
                aTimer.Stop();
                aTimer.Dispose();
            }
            ThreadGetDataPLC?.Interrupt();
        }
    }
}
