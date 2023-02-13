using ManagementSoftware.PLCSetting;
using S7.Net.Types;
using Syncfusion.Windows.Forms.Tools;
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

namespace ManagementSoftware.GUI.CongTacManagement
{
    public partial class TemplateJigCongTac : Form
    {
        double a1;
        double a2;
        double a3;
        double a4;
        double a5;
        int Jig;


        PLCCongTac plc;

        System.Threading.Timer timer;
        int TIME_INTERVAL_IN_MILLISECONDS = 0;
        public TemplateJigCongTac(double addrCT1, double addrCT2, double addrCT3, double addrCT4, double addrCT5, int jig,int time)
        {
            InitializeComponent();
            labelNameJig.Text = "Jig " + jig;
            Jig = jig;
            a1 = addrCT1;
            a2 = addrCT2;
            a3 = addrCT3;
            a4 = addrCT4;
            a5 = addrCT5;
            plc = new PLCCongTac(ControlAllPLC.ipCongTac, ControlAllPLC.PLCCongTac);
            TIME_INTERVAL_IN_MILLISECONDS = time;
        }

        private async void TemplateJigCongTac_Load(object sender, EventArgs e)
        {
            if (await plc.Open() == true)
            {
                timer = new System.Threading.Timer(Callback, null, TIME_INTERVAL_IN_MILLISECONDS, Timeout.Infinite);
            }
        }

        private async void TemplateJigCongTac_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timer != null)
            {
                this.timer.Change(Timeout.Infinite, Timeout.Infinite);
                timer.Dispose();
                timer = null;
            }
            await plc.Close();
        }




        private async void Callback(Object state)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();


            // update data
            // Long running operation

            List<Models.CongTacModel.CongTac> list = await plc.GetData(a1, a2, a3, a4, a5, Jig);
            if (list != null && list.Count> 0)
            {
                UpdateData(list);
            }


            if (timer != null)
            {
                timer.Change(Math.Max(0, TIME_INTERVAL_IN_MILLISECONDS - watch.ElapsedMilliseconds), Timeout.Infinite);
            }
        }

        private void UpdateData(List<Models.CongTacModel.CongTac> list)
        {

            if (IsHandleCreated && InvokeRequired)
            {
                BeginInvoke(new Action<List<Models.CongTacModel.CongTac>>(UpdateData), list);
                return;
            }


            //update gui

            SetTextControl(SoLanTestCT1, TrangThaiCT1, list[0]);
            SetTextControl(SoLanTestCT2, TrangThaiCT2, list[1]);
            SetTextControl(SoLanTestCT3, TrangThaiCT3, list[2]);
            SetTextControl(SoLanTestCT4, TrangThaiCT4, list[3]);
            SetTextControl(SoLanTestCT5, TrangThaiCT5, list[4]);


        }

        private void SetTextControl(Button lanTestThu, Button TrangThai, Models.CongTacModel.CongTac e)
        {

            lanTestThu.Text = e.LanTestThu.ToString();

            TrangThai.Text = e.TrangThai == true ? "ON" : "OFF";

        }
    }
}
