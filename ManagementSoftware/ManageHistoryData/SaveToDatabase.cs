﻿using ManagementSoftware.Models.JigMachModel;
using ManagementSoftware.Models.LedModel;
using ManagementSoftware.PLCSetting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.ManageHistoryData
{
    public class SaveToDatabase
    {
        public PLCBauNong plcBauNong = new PLCBauNong(ControlAllPLC.ipBauNong, ControlAllPLC.PLCBauNong);
        public PLCBepTu plcBepTu = new PLCBepTu(ControlAllPLC.ipBepTu, ControlAllPLC.PLCBepTu);
        public PLCCongTac plcCongTac = new PLCCongTac(ControlAllPLC.ipCongTac, ControlAllPLC.PLCCongTac);
        public PLCLoiLoc plcLoiLoc = new PLCLoiLoc(ControlAllPLC.ipLoiLoc, ControlAllPLC.PLCLoiLoc);
        public PLCMach plcMach = new PLCMach(ControlAllPLC.ipMach, ControlAllPLC.PLCMach);
        public PLCNguon plcNguon = new PLCNguon(ControlAllPLC.ipNguon, ControlAllPLC.PLCNguon);



        int TIME_INTERVAL_SAVE = 5000;


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


                    Task.Run(() => plcBauNong.SaveData(list));

                    Task.Run(() => new SaveToFIleExcel().SaveBauNong("Test Bầu Nóng", list));

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

                    Task.Run(() => plcLoiLoc.SaveData(list));

                    Task.Run(() => new SaveToFIleExcel().SaveLoiLoc("Test Lõi Lọc", list));

                    

                    await plcLoiLoc.Close();
                }

            }
            catch
            {

            }
            finally
            {
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
                    List<Models.NguonModel.Nguon> list = await plcNguon.GetDataNguon();
                    List<Models.LedModel.Led> listLed = await plcNguon.GetDataLED();

                    Task.Run(() => plcNguon.SaveData(list));
                    Task.Run(() => plcNguon.SaveDataLed(listLed));



                    Task.Run(() => new SaveToFIleExcel().SaveNguon("Test Nguồn", list));
                    Task.Run(() => new SaveToFIleExcel().SaveLed("Test Led", listLed));
                    

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


                    List<Models.CongTacModel.CongTac> list = await plcCongTac.GetAllData();

                    Task.Run(() => plcCongTac.SaveData(list));
                    Task.Run(() => new SaveToFIleExcel().SaveCongTac("Test Công Tắc", list));


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


                    Task.Run(() => plcMach.SaveData(list, list2));

                    Task.Run(() => new SaveToFIleExcel().SaveJigMachNguon("Test Mạch Nguồn", list));
                    Task.Run(() => new SaveToFIleExcel().SaveJigMachTDS("Test Mạch TDS", list2));
                    


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
                    List<Models.BepTuModel.BepTu> list = await plcBepTu.GetAllData();

                    Task.Run(() => plcBepTu.SaveData(list));
                    Task.Run(() => new SaveToFIleExcel().SaveBepTu("Test Bếp Từ", list));


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
            timerBauNong = new System.Threading.Timer(CallbackBauNong, null, 10000, 10000);
            timerBepTu = new System.Threading.Timer(CallbackBepTu, null, 10000, 10000);
            timerCongTac = new System.Threading.Timer(CallbackCongTac, null, 10000, 10000);
            timerLoiLoc = new System.Threading.Timer(CallbackLoiLoc, null, 10000, 10000);
            timerMach = new System.Threading.Timer(CallbackMach, null, 10000, 10000);
            timerNguon = new System.Threading.Timer(CallbackNguon, null, 10000, 10000);

        }
    }
}
