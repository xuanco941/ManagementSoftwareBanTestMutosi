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

namespace ManagementSoftware.GUI.JigMachManagement
{
    public partial class GiamSatJigMachNguon : Form
    {

        PLCMach plc;

        System.Threading.Timer timer;
        int TIME_INTERVAL_IN_MILLISECONDS = 0;
        public GiamSatJigMachNguon()
        {
            InitializeComponent();
            plc = new PLCMach(ControlAllPLC.ipMach, ControlAllPLC.PLCMach);
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

            List<Models.JigMachModel.JigMachNguon> list = await plc.GetDataMachNguon();
            if (list != null && list.Count > 0)
            {
                UpdateData(list.ToList());
            }



            if (timer != null)
            {
                timer.Change(Math.Max(0, TIME_INTERVAL_IN_MILLISECONDS - watch.ElapsedMilliseconds), Timeout.Infinite);
            }
        }



        private void UpdateData(List<Models.JigMachModel.JigMachNguon> list)
        {

            if (IsHandleCreated && InvokeRequired)
            {
                BeginInvoke(new Action<List<Models.JigMachModel.JigMachNguon>>(UpdateData), list);
                return;
            }


            //update gui




            foreach (Models.JigMachModel.JigMachNguon e in list)
            {
                if (e.JigMachNguonName == TenThietBi.JigMachNguon1)
                {
                    SetTextControl(MachNguonDongDienJig1, MachNguonDienApJig1, MachNguonCongSuatJig1, ThoiGianTestJ1, LanTestThuJ1, e);
                }
                else if(e.JigMachNguonName == TenThietBi.JigMachNguon2)
                {
                    SetTextControl(MachNguonDongDienJig2, MachNguonDienApJig2, MachNguonCongSuatJig2, ThoiGianTestJ2, LanTestThuJ2, e);
                }
                else if (e.JigMachNguonName == TenThietBi.JigMachNguon3)
                {
                    SetTextControl(MachNguonDongDienJig3, MachNguonDienApJig3, MachNguonCongSuatJig3, ThoiGianTestJ3, LanTestThuJ3, e);
                }
                else if (e.JigMachNguonName == TenThietBi.JigMachNguon4)
                {
                    SetTextControl(MachNguonDongDienJig4, MachNguonDienApJig4, MachNguonCongSuatJig4, ThoiGianTestJ4, LanTestThuJ4, e);
                }
                else if (e.JigMachNguonName == TenThietBi.JigMachNguon5)
                {
                    SetTextControl(MachNguonDongDienJig5, MachNguonDienApJig5, MachNguonCongSuatJig5, ThoiGianTestJ5, LanTestThuJ5, e);
                }
                else if (e.JigMachNguonName == TenThietBi.JigMachNguon6)
                {
                    SetTextControl(MachNguonDongDienJig6, MachNguonDienApJig6, MachNguonCongSuatJig6, ThoiGianTestJ6, LanTestThuJ6, e);
                }
                else if (e.JigMachNguonName == TenThietBi.JigMachNguon7)
                {
                    SetTextControl(MachNguonDongDienJig7, MachNguonDienApJig7, MachNguonCongSuatJig7, ThoiGianTestJ7, LanTestThuJ7, e);
                }
                else if (e.JigMachNguonName == TenThietBi.JigMachNguon8)
                {
                    SetTextControl(MachNguonDongDienJig8, MachNguonDienApJig8, MachNguonCongSuatJig8, ThoiGianTestJ8, LanTestThuJ8, e);
                }
                else if (e.JigMachNguonName == TenThietBi.JigMachNguon9)
                {
                    SetTextControl(MachNguonDongDienJig9, MachNguonDienApJig9, MachNguonCongSuatJig9, ThoiGianTestJ9, LanTestThuJ9, e);
                }
                else if (e.JigMachNguonName == TenThietBi.JigMachNguon10)
                {
                    SetTextControl(MachNguonDongDienJig10, MachNguonDienApJig10, MachNguonCongSuatJig10, ThoiGianTestJ10, LanTestThuJ10, e);
                }

            }


        }







            private void SetTextControl(Button dongDien, Button dienAp, Button congSuat, Button time, Button soLanTest, Models.JigMachModel.JigMachNguon e)
        {

            dongDien.Text = String.Format("{0:0.00}", e.DongDienDC) + " A";

            dienAp.Text = String.Format("{0:0.00}", e.DienApDC) + " V";

            congSuat.Text = String.Format("{0:0.00}", e.CongSuat) + " W";

            time.Text = e.ThoiGian.ToString() + " s";

            soLanTest.Text = e.LanTestThu.ToString();

        }

        private void GiamSatJigMachNguon_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopTimer();
        }
    }
}
