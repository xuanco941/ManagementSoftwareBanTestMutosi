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
using System.Windows.Forms;

namespace ManagementSoftware.GUI.NguonManagement
{
    public partial class FormTestLed : Form
    {
        PLCNguon plc;

        System.Threading.Timer timer;
        int TIME_INTERVAL_IN_MILLISECONDS = 1000;
        public FormTestLed()
        {
            InitializeComponent();
            plc = new PLCNguon(ControlAllPLC.ipNguon, ControlAllPLC.PLCNguon);
        }

        private void FormTestLed_Load(object sender, EventArgs e)
        {
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

        private void FormTestLed_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopTimer();

        }

        private async void Callback(Object state)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();


            // update data
            // Long running operation

            List<Models.LedModel.Led> list = await plc.GetDataLED();
            if (list != null && list.Count > 0)
            {
                UpdateData(list.ToList());
            }


            timer.Change(Math.Max(0, TIME_INTERVAL_IN_MILLISECONDS - watch.ElapsedMilliseconds), Timeout.Infinite);
        }


        private void SetTextNguon(Button time, Button soLanTest, Models.LedModel.Led e)
        {

            time.Text = e.ThoiGianTest.ToString() + " s";

            soLanTest.Text = e.LanTestThu.ToString();

        }









        private void UpdateData(List<Models.LedModel.Led> list)
        {

            if (IsHandleCreated && InvokeRequired)
            {
                BeginInvoke(new Action<List<Models.LedModel.Led>>(UpdateData), list);
                return;
            }


            //update gui




            foreach (Models.LedModel.Led e in list)
            {
                if (e.LedName == TenThietBi.Nguon1)
                {
                    SetTextNguon(ThoiGian1, LanTest1, e);

                }
                else if (e.LedName == TenThietBi.Nguon2)
                {
                    SetTextNguon(ThoiGian2, LanTest2, e);

                }
                else if (e.LedName == TenThietBi.Nguon3)
                {

                    SetTextNguon(ThoiGian3, LanTest3, e);


                }
                else if (e.LedName == TenThietBi.Nguon4)
                {

                    SetTextNguon(ThoiGian4, LanTest4, e);


                }
                else if (e.LedName == TenThietBi.Nguon5)
                {

                    SetTextNguon(ThoiGian5, LanTest5, e);


                }
                else if (e.LedName == TenThietBi.Nguon6)
                {

                    SetTextNguon(ThoiGian6, LanTest6, e);


                }
                else if (e.LedName == TenThietBi.Nguon7)
                {

                    SetTextNguon(ThoiGian7, LanTest7, e);


                }
                else if (e.LedName == TenThietBi.Nguon8)
                {
                    SetTextNguon(ThoiGian8, LanTest8, e);
                }
                else if (e.LedName == TenThietBi.Nguon9)
                {
                    SetTextNguon(ThoiGian9, LanTest9, e);
                }
                else if (e.LedName == TenThietBi.Nguon10)
                {
                    SetTextNguon(ThoiGian10, LanTest10, e);
                }
                else if (e.LedName == TenThietBi.Nguon11)
                {

                    SetTextNguon(ThoiGian11, LanTest11, e);
                }
                else if (e.LedName == TenThietBi.Nguon12)
                {
                    SetTextNguon(ThoiGian12, LanTest12, e);
                }
                else if (e.LedName == TenThietBi.Nguon13)
                {
                    SetTextNguon(ThoiGian13, LanTest13, e);
                }
                else if (e.LedName == TenThietBi.Nguon14)
                {
                    SetTextNguon(ThoiGian14, LanTest14, e);
                }
                else if (e.LedName == TenThietBi.Nguon15)
                {

                    SetTextNguon(ThoiGian15, LanTest15, e);
                }
                else if (e.LedName == TenThietBi.Nguon16)
                {

                    SetTextNguon(ThoiGian16, LanTest16, e);
                }
                else if (e.LedName == TenThietBi.Nguon17)
                {

                    SetTextNguon(ThoiGian17, LanTest17, e);
                }
                else if (e.LedName == TenThietBi.Nguon18)
                {

                    SetTextNguon(ThoiGian18, LanTest18, e);
                }
                else if (e.LedName == TenThietBi.Nguon19)
                {

                    SetTextNguon(ThoiGian19, LanTest19, e);
                }
                else if (e.LedName == TenThietBi.Nguon20)
                {

                    SetTextNguon(ThoiGian20, LanTest20, e);
                }
                else if (e.LedName == TenThietBi.Nguon21)
                {

                    SetTextNguon(ThoiGian21, LanTest21, e);
                }
                else if (e.LedName == TenThietBi.Nguon22)
                {

                    SetTextNguon(ThoiGian22, LanTest22, e);
                }
                else if (e.LedName == TenThietBi.Nguon23)
                {

                    SetTextNguon(ThoiGian23, LanTest23, e);
                }
                else if (e.LedName == TenThietBi.Nguon24)
                {

                    SetTextNguon(ThoiGian24, LanTest24, e);
                }
                else if (e.LedName == TenThietBi.Nguon25)
                {

                    SetTextNguon(ThoiGian25, LanTest25, e);
                }
                else if (e.LedName == TenThietBi.Nguon26)
                {

                    SetTextNguon(ThoiGian26, LanTest26, e);
                }
                else if (e.LedName == TenThietBi.Nguon27)
                {

                    SetTextNguon(ThoiGian27, LanTest27, e);
                }
                else if (e.LedName == TenThietBi.Nguon28)
                {

                    SetTextNguon(ThoiGian28, LanTest28, e);
                }
                else if (e.LedName == TenThietBi.Nguon29)
                {

                    SetTextNguon(ThoiGian29, LanTest29, e);
                }
                else if (e.LedName == TenThietBi.Nguon30)
                {

                    SetTextNguon(ThoiGian30, LanTest30, e);
                }
            }

        }
    }
}
