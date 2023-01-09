using ManagementSoftware.Models.NguonModel;
using ManagementSoftware.PLCSetting;
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

namespace ManagementSoftware.GUI.NguonManagement
{
    public partial class NguonTu1Den15 : Form
    {


        // Giam sat

        PLCNguon plc;

        System.Threading.Timer timer;
        int TIME_INTERVAL_IN_MILLISECONDS = 1000;

        public NguonTu1Den15()
        {
            InitializeComponent();
            plc = new PLCNguon(ControlAllPLC.ipNguon, ControlAllPLC.PLCNguon);
        }

        private async void NguonTu1Den15_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer != null)
            {
                this.timer.Change(Timeout.Infinite, Timeout.Infinite);
            }
            await plc.Close();
        }

        private async void NguonTu1Den15_Load(object sender, EventArgs e)
        {
            if (await plc.Open() == true)
            {
                timer = new System.Threading.Timer(Callback, null, TIME_INTERVAL_IN_MILLISECONDS, Timeout.Infinite);
            }

        }



        private async void Callback(Object state)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();


            // update data
            // Long running operation

            List<Models.NguonModel.Nguon> list = await plc.GetDataNguon1Den15();
            if (list != null && list.Count > 0)
            {
                UpdateData(list);
            }


            timer.Change(Math.Max(0, TIME_INTERVAL_IN_MILLISECONDS - watch.ElapsedMilliseconds), Timeout.Infinite);
        }



        private void SetTextNguon(Button dongDC, Button dienApDC, Button congSuat, Button time, Button soLanTest, Models.NguonModel.Nguon e)
        {

            dongDC.Text = String.Format("{0:0.00}", e.DongDC) + " A";

            dienApDC.Text = String.Format("{0:0.00}", e.DienApDC) + " V";

            congSuat.Text = String.Format("{0:0.00}", e.CongSuat) + " W";

            time.Text = e.ThoiGianTest.ToString() + " giây";

            soLanTest.Text = e.LanTestThu.ToString();

        }


        private void UpdateData(List<Models.NguonModel.Nguon> list)
        {

            if (IsHandleCreated && InvokeRequired)
            {
                BeginInvoke(new Action<List<Models.NguonModel.Nguon>>(UpdateData), list);
                return;
            }


            //update gui




            foreach (Models.NguonModel.Nguon e in list)
            {
                if (e.NguonName == TenThietBi.Nguon1)
                {
                    SetTextNguon(DongDC1, DienApDC1, CongSuat1, timeTest1, SoLanTest1, e);

                }
                else if (e.NguonName == TenThietBi.Nguon2)
                {
                    SetTextNguon(DongDC2, DienApDC2, CongSuat2, timeTest2, SoLanTest2, e);

                }
                else if (e.NguonName == TenThietBi.Nguon3)
                {

                    SetTextNguon(DongDC3, DienApDC3, CongSuat3, timeTest3, SoLanTest3, e);


                }
                else if (e.NguonName == TenThietBi.Nguon4)
                {

                    SetTextNguon(DongDC4, DienApDC4, CongSuat4, timeTest4, SoLanTest4, e);


                }
                else if (e.NguonName == TenThietBi.Nguon5)
                {

                    SetTextNguon(DongDC5, DienApDC5, CongSuat5, timeTest5, SoLanTest5, e);


                }
                else if (e.NguonName == TenThietBi.Nguon6)
                {

                    SetTextNguon(DongDC6, DienApDC6, CongSuat6, timeTest6, SoLanTest6, e);


                }
                else if (e.NguonName == TenThietBi.Nguon7)
                {

                    SetTextNguon(DongDC7, DienApDC7, CongSuat7, timeTest7, SoLanTest7, e);


                }
                else if (e.NguonName == TenThietBi.Nguon8)
                {
                    SetTextNguon(DongDC8, DienApDC8, CongSuat8, timeTest8, SoLanTest8, e);
                }
                else if (e.NguonName == TenThietBi.Nguon9)
                {
                    SetTextNguon(DongDC9, DienApDC9, CongSuat9, timeTest9, SoLanTest9, e);
                }
                else if (e.NguonName == TenThietBi.Nguon10)
                {
                    SetTextNguon(DongDC10, DienApDC10, CongSuat10, timeTest10, SoLanTest10, e);
                }
                else if (e.NguonName == TenThietBi.Nguon11)
                {

                    SetTextNguon(DongDC11, DienApDC11, CongSuat11, timeTest11, SoLanTest11, e);
                }
                else if (e.NguonName == TenThietBi.Nguon12)
                {
                    SetTextNguon(DongDC12, DienApDC12, CongSuat12, timeTest12, SoLanTest12, e);
                }
                else if (e.NguonName == TenThietBi.Nguon13)
                {
                    SetTextNguon(DongDC13, DienApDC13, CongSuat13, timeTest13, SoLanTest13, e);
                }
                else if (e.NguonName == TenThietBi.Nguon14)
                {
                    SetTextNguon(DongDC14, DienApDC14, CongSuat14, timeTest14, SoLanTest14, e);
                }
                else if (e.NguonName == TenThietBi.Nguon15)
                {

                    SetTextNguon(DongDC15, DienApDC15, CongSuat15, timeTest15, SoLanTest15, e);
                }
            }

        }

    }
}
