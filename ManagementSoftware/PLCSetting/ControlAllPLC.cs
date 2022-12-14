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
        private static void LoiLoc_Tick(object sender, EventArgs e)
        {
            PLCJigLoiLoc.SaveData();

        }
        private static void Nguon_Tick(object sender, EventArgs e)
        {
            PLCNguon.SaveData();

        }
        private static void BauNong_Tick(object sender, EventArgs e)
        {
            PLCBauNong.SaveData();
        }
        private static void JigMach_Tick(object sender, EventArgs e)
        {
            PLCJigMach.SaveData();
        }
        private static void CongTac_Tick(object sender, EventArgs e)
        {
            PLCCongTac.SaveData();
        }
        private static void BepTu_Tick(object sender, EventArgs e)
        {
            PLCBepTu.SaveData();
        }



        public static System.Timers.Timer aTimerLoiLoc;
        public static System.Timers.Timer aTimerNguon;
        public static System.Timers.Timer aTimerBauNong;
        public static System.Timers.Timer aTimerJigMach;
        public static System.Timers.Timer aTimerBepTu;
        public static System.Timers.Timer aTimerCongTac;


        public static void RunLoiLoc()
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
                    aTimerLoiLoc = new System.Timers.Timer();
                    aTimerLoiLoc.Elapsed += new ElapsedEventHandler(LoiLoc_Tick);
                    aTimerLoiLoc.Interval = 15000;
                    aTimerLoiLoc.Start();
                }
            }).Start();
        }
        public static void StopLoiLoc()
        {
            if (aTimerLoiLoc != null && aTimerLoiLoc.Enabled)
            {
                aTimerLoiLoc.Stop();
                aTimerLoiLoc.Dispose();
            }
        }


        public static void RunNguon()
        {
            new Thread(() =>
            {
                PLCNguon.Start();
                if (PLCNguon.plc.IsConnected == false)
                {
                    MessageBox.Show(PLCNguon.message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    aTimerNguon = new System.Timers.Timer();
                    aTimerNguon.Elapsed += new ElapsedEventHandler(Nguon_Tick);
                    aTimerNguon.Interval = 15000;
                    aTimerNguon.Start();
                }
            }).Start();
        }
        public static void StopNguon()
        {
            if (aTimerNguon != null && aTimerNguon.Enabled)
            {
                aTimerNguon.Stop();
                aTimerNguon.Dispose();
            }
        }

        public static void RunBauNong()
        {
            new Thread(() =>
            {
                PLCBauNong.Start();
                if (PLCBauNong.plc.IsConnected == false)
                {
                    MessageBox.Show(PLCBauNong.message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    aTimerBauNong = new System.Timers.Timer();
                    aTimerBauNong.Elapsed += new ElapsedEventHandler(BauNong_Tick);
                    aTimerBauNong.Interval = 15000;
                    aTimerBauNong.Start();
                }
            }).Start();
        }
        public static void StopBauNong()
        {
            if (aTimerBauNong != null && aTimerBauNong.Enabled)
            {
                aTimerBauNong.Stop();
                aTimerBauNong.Dispose();
            }
        }


        public static void RunBepTu()
        {
            new Thread(() =>
            {
                PLCBepTu.Start();
                if (PLCBepTu.plc.IsConnected == false)
                {
                    MessageBox.Show(PLCBepTu.message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    aTimerBepTu = new System.Timers.Timer();
                    aTimerBepTu.Elapsed += new ElapsedEventHandler(BepTu_Tick);
                    aTimerBepTu.Interval = 15000;
                    aTimerBepTu.Start();
                }
            }).Start();
        }

        public static void StopBepTu()
        {
            if (aTimerBepTu != null && aTimerBepTu.Enabled)
            {
                aTimerBepTu.Stop();
                aTimerBepTu.Dispose();
            }
        }



        public static void RunJigMach()
        {
            new Thread(() =>
            {
                PLCJigMach.Start();
                if (PLCJigMach.plc.IsConnected == false)
                {
                    MessageBox.Show(PLCJigMach.message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    aTimerJigMach = new System.Timers.Timer();
                    aTimerJigMach.Elapsed += new ElapsedEventHandler(JigMach_Tick);
                    aTimerJigMach.Interval = 15000;
                    aTimerJigMach.Start();
                }
            }).Start();
        }
        public static void StopJigMach()
        {
            if (aTimerJigMach != null && aTimerJigMach.Enabled)
            {
                aTimerJigMach.Stop();
                aTimerJigMach.Dispose();
            }
        }


        public static void RunCongTac()
        {
            new Thread(() =>
            {
                PLCCongTac.Start();
                if (PLCCongTac.plc.IsConnected == false)
                {
                    MessageBox.Show(PLCCongTac.message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    aTimerCongTac = new System.Timers.Timer();
                    aTimerCongTac.Elapsed += new ElapsedEventHandler(CongTac_Tick);
                    aTimerCongTac.Interval = 15000;
                    aTimerCongTac.Start();
                }
            }).Start();
        }

        public static void StopCongTac()
        {
            if (aTimerCongTac != null && aTimerCongTac.Enabled)
            {
                aTimerCongTac.Stop();
                aTimerCongTac.Dispose();
            }
        }

        public static void ConnectAndRunAll()
        {
            RunBauNong();
            RunBepTu();
            RunJigMach();
            RunLoiLoc();
            RunNguon();
            RunCongTac();
        }
    }
}
