using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ManagementSoftware.PLCSetting
{
    public class ControlAllPLC
    {
        private void LoiLoc_Tick(object sender, EventArgs e)
        {
            PLCJigLoiLoc.GetData();
            PLCJigLoiLoc.SaveData();

        }
        private void Nguon_Tick(object sender, EventArgs e)
        {
            PLCNguon.GetData();
            PLCNguon.SaveData();

        }
        private void BauNong_Tick(object sender, EventArgs e)
        {
            PLCBauNong.GetData();
            PLCBauNong.SaveData();
        }
        private void JigMach_Tick(object sender, EventArgs e)
        {
            PLCJigMach.GetData();
            PLCJigMach.SaveData();
        }
        private void CongTac_Tick(object sender, EventArgs e)
        {
            PLCCongTac.GetData();
            PLCCongTac.SaveData();
        }
        private void BepTu_Tick(object sender, EventArgs e)
        {
            PLCBepTu.GetData();
            PLCBepTu.SaveData();
        }
        public void ConnectAndRun()
        {
            new Thread(() =>
            {

                PLCJigLoiLoc.Start();
                if (PLCJigLoiLoc.plc.IsConnected == false)
                {
                    MessageBox.Show(PLCJigLoiLoc.message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    System.Timers.Timer aTimer = new System.Timers.Timer();
                    aTimer.Elapsed += new ElapsedEventHandler(LoiLoc_Tick);
                    aTimer.Interval = 5000;
                    aTimer.Start();
                }
            }).Start();

            new Thread(() =>
            {
                PLCNguon.Start();
                if (PLCNguon.plc.IsConnected == false)
                {
                    MessageBox.Show(PLCNguon.message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    System.Timers.Timer aTimer = new System.Timers.Timer();
                    aTimer.Elapsed += new ElapsedEventHandler(Nguon_Tick);
                    aTimer.Interval = 5000;
                    aTimer.Start();
                }
            }).Start();
            new Thread(() =>
            {
                PLCBauNong.Start();
                if (PLCBauNong.plc.IsConnected == false)
                {
                    MessageBox.Show(PLCBauNong.message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    System.Timers.Timer aTimer = new System.Timers.Timer();
                    aTimer.Elapsed += new ElapsedEventHandler(BauNong_Tick);
                    aTimer.Interval = 5000;
                    aTimer.Start();
                }
            }).Start();
            new Thread(() =>
            {
                PLCBepTu.Start();
                if (PLCBepTu.plc.IsConnected == false)
                {
                    MessageBox.Show(PLCBepTu.message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    System.Timers.Timer aTimer = new System.Timers.Timer();
                    aTimer.Elapsed += new ElapsedEventHandler(BepTu_Tick);
                    aTimer.Interval = 5000;
                    aTimer.Start();
                }
            }).Start();
            new Thread(() =>
            {
                PLCCongTac.Start();
                if (PLCCongTac.plc.IsConnected == false)
                {
                    MessageBox.Show(PLCCongTac.message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    System.Timers.Timer aTimer = new System.Timers.Timer();
                    aTimer.Elapsed += new ElapsedEventHandler(CongTac_Tick);
                    aTimer.Interval = 5000;
                    aTimer.Start();
                }
            }).Start();
            new Thread(() =>
            {
                PLCJigMach.Start();
                if (PLCJigMach.plc.IsConnected == false)
                {
                    MessageBox.Show(PLCJigMach.message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    System.Timers.Timer aTimer = new System.Timers.Timer();
                    aTimer.Elapsed += new ElapsedEventHandler(JigMach_Tick);
                    aTimer.Interval = 5000;
                    aTimer.Start();
                }
            }).Start();

        }
    }
}
