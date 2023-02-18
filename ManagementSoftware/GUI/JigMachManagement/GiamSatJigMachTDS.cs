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
    public partial class GiamSatJigMachTDS : Form
    {
        PLCMach plc;

        System.Threading.Timer? timer = null;
        int TIME_INTERVAL_IN_MILLISECONDS = 0;
        public GiamSatJigMachTDS()
        {
            InitializeComponent();
            plc = new PLCMach(ControlAllPLC.ipMach, ControlAllPLC.PLCMach);
        }

        public async void StartTimer()
        {
            if (timer == null && await plc.Open() == true)
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

            List<Models.JigMachModel.JigMachTDS> list = await plc.GetDataMachTDS();
            if (list != null && list.Count > 0)
            {
                UpdateData(list.ToList());
            }


            if (timer != null)
            {
                timer.Change(Math.Max(0, TIME_INTERVAL_IN_MILLISECONDS - watch.ElapsedMilliseconds), Timeout.Infinite);
            }
        }



        private void UpdateData(List<Models.JigMachModel.JigMachTDS> list)
        {

            if (IsHandleCreated && InvokeRequired)
            {
                BeginInvoke(new Action<List<Models.JigMachModel.JigMachTDS>>(UpdateData), list);
                return;
            }


            //update gui




            foreach (Models.JigMachModel.JigMachTDS e in list)
            {
                if (e.JigMachTDSName == TenThietBi.JigMachNguon1)
                {
                    SetTextControl(MachNguonDienApJig1, MachNguonCongSuatJig1, ThoiGianTestJ1, LanTestThuJ1, buttonTinhTrang1, lbjig1, e);
                }
                else if (e.JigMachTDSName == TenThietBi.JigMachNguon2)
                {
                    SetTextControl(MachNguonDienApJig2, MachNguonCongSuatJig2, ThoiGianTestJ2, LanTestThuJ2, buttonTinhTrang2, lbjig2, e);
                }
                else if (e.JigMachTDSName == TenThietBi.JigMachNguon3)
                {
                    SetTextControl(MachNguonDienApJig3, MachNguonCongSuatJig3, ThoiGianTestJ3, LanTestThuJ3, buttonTinhTrang3, lbjig3, e);
                }
                else if (e.JigMachTDSName == TenThietBi.JigMachNguon4)
                {
                    SetTextControl(MachNguonDienApJig4, MachNguonCongSuatJig4, ThoiGianTestJ4, LanTestThuJ4, buttonTinhTrang4, lbjig4, e);
                }
                else if (e.JigMachTDSName == TenThietBi.JigMachNguon5)
                {
                    SetTextControl(MachNguonDienApJig5, MachNguonCongSuatJig5, ThoiGianTestJ5, LanTestThuJ5, buttonTinhTrang5, lbjig5, e);
                }
                else if (e.JigMachTDSName == TenThietBi.JigMachNguon6)
                {
                    SetTextControl(MachNguonDienApJig6, MachNguonCongSuatJig6, ThoiGianTestJ6, LanTestThuJ6, buttonTinhTrang6, lbjig6, e);
                }
                else if (e.JigMachTDSName == TenThietBi.JigMachNguon7)
                {
                    SetTextControl(MachNguonDienApJig7, MachNguonCongSuatJig7, ThoiGianTestJ7, LanTestThuJ7, buttonTinhTrang7, lbjig7, e);
                }
                else if (e.JigMachTDSName == TenThietBi.JigMachNguon8)
                {
                    SetTextControl(MachNguonDienApJig8, MachNguonCongSuatJig8, ThoiGianTestJ8, LanTestThuJ8, buttonTinhTrang8, lbjig8, e);
                }
                else if (e.JigMachTDSName == TenThietBi.JigMachNguon9)
                {
                    SetTextControl(MachNguonDienApJig9, MachNguonCongSuatJig9, ThoiGianTestJ9, LanTestThuJ9, buttonTinhTrang9, lbjig9, e);
                }
                else if (e.JigMachTDSName == TenThietBi.JigMachNguon10)
                {
                    SetTextControl(MachNguonDienApJig10, MachNguonCongSuatJig10, ThoiGianTestJ10, LanTestThuJ10, buttonTinhTrang10, lbjig10, e);
                }

            }


        }







        private void SetTextControl(Button dienAp, Button congSuat, Button time, Button soLanTest, Button tinhTrang, Label lbjig, Models.JigMachModel.JigMachTDS e)
        {


            dienAp.Text = e.VanDienTu == true ? "ON" : "OFF";

            congSuat.Text = e.VanApCao == true ? "ON" : "OFF";

            time.Text = e.ThoiGian.ToString() + " s";

            soLanTest.Text = e.LanTestThu.ToString();

            tinhTrang.Text = e.Error;
            if (e.Error != Common.NOT_ERROR_STR)
            {
                lbjig.BackColor = Color.Crimson;
                tinhTrang.Font = new Font("Segoe UI", 8, FontStyle.Regular);
            }
            else
            {
                lbjig.BackColor = Color.DarkOrange;
                tinhTrang.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            }

            if (e.isOn)
            {
                lbjig.Text = e.JigMachTDSName;
            }
            else
            {
                lbjig.Text = e.JigMachTDSName + " (OFF)";
            }
        }


        private void GiamSatJigMachTDS_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopTimer();

        }
    }
}
