using ManagementSoftware.Models.CongTacModel;
using ManagementSoftware.Models.JigMachModel;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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



        public PLCBauNong plcBauNong = new PLCBauNong(ipBauNong, PLCBauNong);
        public PLCBepTu plcBepTu = new PLCBepTu(ipBepTu, PLCBepTu);
        public PLCCongTac plcCongTac = new PLCCongTac(ipCongTac, PLCCongTac);
        public PLCLoiLoc plcLoiLoc = new PLCLoiLoc(ipLoiLoc, PLCLoiLoc);
        public PLCMach plcMach = new PLCMach(ipMach, PLCMach);
        public PLCNguon plcNguon = new PLCNguon(ipNguon, PLCNguon);



        int TIME_INTERVAL_SAVE = 10000;


        System.Threading.Timer timerBauNong;
        System.Threading.Timer timerBepTu;
        System.Threading.Timer timerCongTac;
        System.Threading.Timer timerLoiLoc;
        System.Threading.Timer timerMach;
        System.Threading.Timer timerNguon;



        private async void CallbackBauNong(Object state)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();


            // update data
            // Long running operation

            try
            {
                if (await plcBauNong.Open() == true)
                {
                    List<Models.BauNongModel.BauNong> list = await plcBauNong.GetAllData();

                    plcBauNong.SaveData(list);
                    await plcBauNong.Close();
                }


            }
            catch
            {

            }
            finally
            {
                timerBauNong.Change(Math.Max(TIME_INTERVAL_SAVE, TIME_INTERVAL_SAVE - watch.ElapsedMilliseconds), Timeout.Infinite);
            }

        }

        private async void CallbackLoiLoc(Object state)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();


            // update data
            // Long running operation
            try
            {
                if (await plcLoiLoc.Open() == true)
                {
                    Models.LoiLocModel.LoiLoc list = await plcLoiLoc.GetData();

                    plcLoiLoc.SaveData(list);
                    await plcLoiLoc.Close();
                }

            }
            catch
            {

            }
            finally
            {
                //long x = Math.Max(0, TIME_INTERVAL_IN_MILLISECONDS - watch.ElapsedMilliseconds);
                timerLoiLoc.Change(Math.Max(TIME_INTERVAL_SAVE, TIME_INTERVAL_SAVE - watch.ElapsedMilliseconds), Timeout.Infinite);
            }


        }


        private async void CallbackNguon(Object state)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();


            // update data
            // Long running operation

            try
            {
                if (await plcNguon.Open())
                {
                    List<Models.NguonModel.Nguon> list1 = await plcNguon.GetDataNguon1Den15();
                    List<Models.NguonModel.Nguon> list2 = await plcNguon.GetDataNguon16Den30();

                    List<Models.NguonModel.Nguon> list3 = new List<Models.NguonModel.Nguon>();
                    list3.AddRange(list1);
                    list3.AddRange(list2);


                    plcNguon.SaveData(list3);
                    await plcNguon.Close();
                }

            }
            catch
            {

            }
            finally
            {
                timerNguon.Change(Math.Max(TIME_INTERVAL_SAVE, TIME_INTERVAL_SAVE - watch.ElapsedMilliseconds), Timeout.Infinite);
            }

        }

        private async void CallbackCongTac(Object state)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();


            // update data
            // Long running operation
            try
            {
                if (await plcCongTac.Open())
                {

                    CongTac[] jig10 = await plcCongTac.GetData(104, 106, 108, 110, 112, 10);
                    CongTac[] jig9 = await plcCongTac.GetData(94, 96, 98, 100, 102, 9);
                    CongTac[] jig8 = await plcCongTac.GetData(84, 86, 88, 90, 92, 8);
                    CongTac[] jig7 = await plcCongTac.GetData(74, 76, 78, 80, 82, 7);
                    CongTac[] jig6 = await plcCongTac.GetData(64, 66, 70, 52, 72, 6);
                    CongTac[] jig5 = await plcCongTac.GetData(40, 42, 44, 46, 48, 5);
                    CongTac[] jig4 = await plcCongTac.GetData(30, 32, 34, 36, 38, 4);
                    CongTac[] jig3 = await plcCongTac.GetData(20, 22, 24, 26, 28, 3);
                    CongTac[] jig2 = await plcCongTac.GetData(50, 12, 14, 16, 18, 2);
                    CongTac[] jig1 = await plcCongTac.GetData(0, 2, 4, 6, 8, 1);


                    List<CongTac> list = new List<CongTac>();
                    list.AddRange(jig1);
                    list.AddRange(jig2);
                    list.AddRange(jig3);
                    list.AddRange(jig4);
                    list.AddRange(jig5);
                    list.AddRange(jig6);
                    list.AddRange(jig7);
                    list.AddRange(jig8);
                    list.AddRange(jig9);
                    list.AddRange(jig10);


                    plcCongTac.SaveData(list);
                    await plcCongTac.Close();
                }

            }

            catch
            {

            }
            finally
            {
                timerCongTac.Change(Math.Max(TIME_INTERVAL_SAVE, TIME_INTERVAL_SAVE - watch.ElapsedMilliseconds), Timeout.Infinite);

            }
        }

        private async void CallbackMach(Object state)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();


            // update data
            // Long running operation
            try
            {
                if (await plcMach.Open())
                {
                    List<JigMachNguon> list = await plcMach.GetDataMachNguon();
                    List<JigMachTDS> list2 = await plcMach.GetDataMachTDS();

                    plcMach.SaveData(list, list2);
                    await plcMach.Close();
                }

            }
            catch
            {

            }
            finally
            {
                timerMach.Change(Math.Max(TIME_INTERVAL_SAVE, TIME_INTERVAL_SAVE - watch.ElapsedMilliseconds), Timeout.Infinite);

            }
        }


        private async void CallbackBepTu(Object state)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();


            // update data
            // Long running operation
            try
            {
                if (await plcBepTu.Open())
                {
                    List<Models.BepTuModel.BepTu> list = await plcBepTu.GetData();

                    plcBepTu.SaveData(list);
                    await plcBepTu.Close();
                }

            }
            catch
            {

            }
            finally
            {
                timerBepTu.Change(Math.Max(TIME_INTERVAL_SAVE, TIME_INTERVAL_SAVE - watch.ElapsedMilliseconds), Timeout.Infinite);

            }
        }


        public void ConnectAndRunSaveAll()
        {
            timerBauNong = new System.Threading.Timer(CallbackBauNong, null, 2000, 2000);
            timerBepTu = new System.Threading.Timer(CallbackBepTu, null, 2000, 2000);
            timerCongTac = new System.Threading.Timer(CallbackCongTac, null, 2000, 2000);
            timerLoiLoc = new System.Threading.Timer(CallbackLoiLoc, null, 2000, 2000);
            timerMach = new System.Threading.Timer(CallbackMach, null, 2000, 2000);
            timerNguon = new System.Threading.Timer(CallbackNguon, null, 2000, 2000);

        }
    }
}
