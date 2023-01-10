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
    public partial class NguonTu16Den30 : Form
    {

        // Giam sat

        PLCNguon plc;

        System.Threading.Timer timer;
        int TIME_INTERVAL_IN_MILLISECONDS = 1000;

        public NguonTu16Den30()
        {
            InitializeComponent();
            plc = new PLCNguon(ControlAllPLC.ipNguon, ControlAllPLC.PLCNguon);
        }


        public async void StartTimer()
        {
            if (await plc.Open() == true)
            {
                timer = new System.Threading.Timer(Callback, null, TIME_INTERVAL_IN_MILLISECONDS, Timeout.Infinite);
            }
        }

        public async void StopTimer()
        {
            if (timer != null)
            {
                this.timer.Change(Timeout.Infinite, Timeout.Infinite);
            }
            await plc.Close();
        }

        private async void NguonTu16Den30_FormClosing(object sender, FormClosingEventArgs e)
        {

            StopTimer();
        }



        private async void Callback(Object state)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();


            // update data
            // Long running operation

            List<Models.NguonModel.Nguon> list = await plc.GetDataNguon16Den30();
            if (list != null && list.Count > 0)
            {
                UpdateData(list.ToList());
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


    }
}
