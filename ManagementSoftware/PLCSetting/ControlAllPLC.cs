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

        public const string ipLoiLoc = "192.168.0.11";
        public const string PLCLoiLoc = "PLC Lõi Lọc";

        public const string ipBauNong = "192.168.0.15";
        public const string PLCBauNong = "PLC Bầu nóng";

        public const string ipBepTu = "192.168.0.13";
        public const string PLCBepTu = "PLC Bếp từ";

        public const string ipCongTac = "192.168.0.21";
        public const string PLCCongTac = "PLC Công tắc";

        public const string ipMach = "192.168.0.19";
        public const string PLCMach = "PLC Mạch";

        public const string ipNguon = "192.168.0.17";
        public const string PLCNguon = "PLC Nguồn";



        public static PLCBauNong plcBauNong = new PLCBauNong(ipBauNong, PLCBauNong);
        public static PLCBepTu plcBepTu = new PLCBepTu(ipBepTu, PLCBepTu);
        public static PLCCongTac plcCongTac = new PLCCongTac(ipCongTac, PLCCongTac);
        public static PLCLoiLoc plcLoiLoc = new PLCLoiLoc(ipLoiLoc, PLCLoiLoc);
        public static PLCMach plcMach = new PLCMach(ipMach, PLCMach);
        public static PLCNguon plcNguon = new PLCNguon(ipNguon, PLCNguon);


        //    private static void LoiLoc_Tick(object sender, EventArgs e)
        //    {
        //        plcJigLoiLoc.SaveData();

        //    }
        //    private static void Nguon_Tick(object sender, EventArgs e)
        //    {
        //        plcNguon.SaveData();

        //    }
        //    private static void BauNong_Tick(object sender, EventArgs e)
        //    {
        //        plcBauNong.SaveData();
        //    }
        //    private static void JigMach_Tick(object sender, EventArgs e)
        //    {
        //        plcJigMach.SaveData();
        //    }
        //    private static void CongTac_Tick(object sender, EventArgs e)
        //    {
        //        plcCongTac.SaveData();
        //    }
        //    private static void BepTu_Tick(object sender, EventArgs e)
        //    {
        //        plcBepTu.SaveData();
        //    }



        //    public static System.Timers.Timer aTimerLoiLoc;
        //    public static System.Timers.Timer aTimerNguon;
        //    public static System.Timers.Timer aTimerBauNong;
        //    public static System.Timers.Timer aTimerJigMach;
        //    public static System.Timers.Timer aTimerBepTu;
        //    public static System.Timers.Timer aTimerCongTac;


        //    public static void RunLoiLoc()
        //    {
        //        Thread t = new Thread(() =>
        //        {

        //            plcJigLoiLoc.Start();
        //            if (plcJigLoiLoc.plc.IsConnected == false)
        //            {
        //                MessageBox.Show(plcJigLoiLoc.message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //            else
        //            {
        //                aTimerLoiLoc = new System.Timers.Timer();
        //                aTimerLoiLoc.Elapsed += new ElapsedEventHandler(LoiLoc_Tick);
        //                aTimerLoiLoc.Interval = 2000;
        //                aTimerLoiLoc.Start();
        //            }
        //        });
        //        t.Start();
        //    }
        //    public static void StopLoiLoc()
        //    {
        //        if (aTimerLoiLoc != null && aTimerLoiLoc.Enabled)
        //        {
        //            aTimerLoiLoc.Stop();
        //            aTimerLoiLoc.Dispose();
        //        }
        //    }


        //    public static void RunNguon()
        //    {
        //        Thread t = new Thread(() =>
        //        {
        //            plcNguon.Start();
        //            if (plcNguon.plc.IsConnected == false)
        //            {
        //                MessageBox.Show(plcNguon.message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //            else
        //            {
        //                aTimerNguon = new System.Timers.Timer();
        //                aTimerNguon.Elapsed += new ElapsedEventHandler(Nguon_Tick);
        //                aTimerNguon.Interval = 2000;
        //                aTimerNguon.Start();
        //            }
        //        });
        //        t.Start();
        //    }
        //    public static void StopNguon()
        //    {
        //        if (aTimerNguon != null && aTimerNguon.Enabled)
        //        {
        //            aTimerNguon.Stop();
        //            aTimerNguon.Dispose();
        //        }
        //    }

        //    public static void RunBauNong()
        //    {
        //        Thread t = new Thread(() =>
        //        {
        //            plcBauNong.Start();
        //            if (plcBauNong.plc.IsConnected == false)
        //            {
        //                MessageBox.Show(plcBauNong.message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //            else
        //            {
        //                aTimerBauNong = new System.Timers.Timer();
        //                aTimerBauNong.Elapsed += new ElapsedEventHandler(BauNong_Tick);
        //                aTimerBauNong.Interval = 2000;
        //                aTimerBauNong.Start();
        //            }
        //        });
        //        t.Start();
        //    }
        //    public static void StopBauNong()
        //    {
        //        if (aTimerBauNong != null && aTimerBauNong.Enabled)
        //        {
        //            aTimerBauNong.Stop();
        //            aTimerBauNong.Dispose();
        //        }
        //    }


        //    public static void RunBepTu()
        //    {
        //        Thread t = new Thread(() =>
        //        {
        //            plcBepTu.Start();
        //            if (plcBepTu.plc.IsConnected == false)
        //            {
        //                MessageBox.Show(plcBepTu.message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //            else
        //            {
        //                aTimerBepTu = new System.Timers.Timer();
        //                aTimerBepTu.Elapsed += new ElapsedEventHandler(BepTu_Tick);
        //                aTimerBepTu.Interval = 2000;
        //                aTimerBepTu.Start();
        //            }
        //        });
        //        t.Start();
        //    }

        //    public static void StopBepTu()
        //    {
        //        if (aTimerBepTu != null && aTimerBepTu.Enabled)
        //        {
        //            aTimerBepTu.Stop();
        //            aTimerBepTu.Dispose();
        //        }
        //    }



        //    public static void RunJigMach()
        //    {
        //        Thread t = new Thread(() =>
        //        {
        //            plcJigMach.Start();
        //            if (plcJigMach.plc.IsConnected == false)
        //            {
        //                MessageBox.Show(plcJigMach.message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //            else
        //            {
        //                aTimerJigMach = new System.Timers.Timer();
        //                aTimerJigMach.Elapsed += new ElapsedEventHandler(JigMach_Tick);
        //                aTimerJigMach.Interval = 2000;
        //                aTimerJigMach.Start();
        //            }
        //        });
        //        t.Start();
        //    }
        //    public static void StopJigMach()
        //    {
        //        if (aTimerJigMach != null && aTimerJigMach.Enabled)
        //        {
        //            aTimerJigMach.Stop();
        //            aTimerJigMach.Dispose();
        //        }
        //    }


        //    public static void RunCongTac()
        //    {
        //        Thread t = new Thread(() =>
        //        {
        //            plcCongTac.Start();
        //            if (plcCongTac.plc.IsConnected == false)
        //            {
        //                MessageBox.Show(plcCongTac.message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            }
        //            else
        //            {
        //                aTimerCongTac = new System.Timers.Timer();
        //                aTimerCongTac.Elapsed += new ElapsedEventHandler(CongTac_Tick);
        //                aTimerCongTac.Interval = 2000;
        //                aTimerCongTac.Start();
        //            }
        //        });
        //        t.Start();
        //    }

        //    public static void StopCongTac()
        //    {
        //        if (aTimerCongTac != null && aTimerCongTac.Enabled)
        //        {
        //            aTimerCongTac.Stop();
        //            aTimerCongTac.Dispose();
        //        }
        //    }

        //    public static void ConnectAndRunAll()
        //    {
        //        RunBauNong();
        //        RunBepTu();
        //        RunJigMach();
        //        RunLoiLoc();
        //        RunNguon();
        //        RunCongTac();
        //    }
    }
}
