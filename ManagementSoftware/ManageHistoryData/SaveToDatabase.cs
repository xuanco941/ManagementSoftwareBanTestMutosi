using ManagementSoftware.Models.CongTacModel;
using ManagementSoftware.Models.JigMachModel;
using ManagementSoftware.Models.LedModel;
using ManagementSoftware.PLCSetting;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
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



        int TIME_INTERVAL_SAVE = 0;


        System.Threading.Timer timerBauNong;
        System.Threading.Timer timerBepTu;
        System.Threading.Timer timerCongTac;
        System.Threading.Timer timerLoiLoc;
        System.Threading.Timer timerMach;
        System.Threading.Timer timerNguon;



        LoiLocHistory loiLocHistory;
        NguonHistory nguonHistory;
        LedHistory ledHistory;
        JigMachNguonHistory jigMachNguonHistory;
        JigMachTDSHistory JigMachTDSHistory;
        BepTuHistory BepTuHistory;
        CongTacHistory CongTacHistory;
        BauNongHistory bauNongHistory;

        public SaveToDatabase()
        {
            loiLocHistory = new LoiLocHistory();
            nguonHistory = new NguonHistory();
            ledHistory = new LedHistory();
            jigMachNguonHistory = new JigMachNguonHistory();
            JigMachTDSHistory = new JigMachTDSHistory();
            BepTuHistory = new BepTuHistory();
            CongTacHistory = new CongTacHistory();
            bauNongHistory = new BauNongHistory();

        }

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

                    List<Models.BauNongModel.BauNong>? l = bauNongHistory.Check(list);

                    if (l != null && l.Count > 0)
                    {
                        plcBauNong.SaveData(l);

                        new SaveToFIleExcel2().SaveBauNong("TEST BẦU NÓNG", l);
                    }


                    await plcBauNong.Close();
                }


            }
            catch
            {

            }
            finally
            {
                watch.Stop();

                // Tính toán thời gian còn lại để đợi trước khi gọi lại callback
                timerBauNong.Change(Math.Max(0, TIME_INTERVAL_SAVE - watch.ElapsedMilliseconds), Timeout.Infinite);
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

                    Models.LoiLocModel.LoiLoc? l = loiLocHistory.Check(list);

                    if (l != null)
                    {
                        plcLoiLoc.SaveData(l);

                        new SaveToFIleExcel2().SaveLoiLoc("TEST LÕI LỌC", l);
                    }

                    await plcLoiLoc.Close();
                }

            }
            catch
            {

            }
            finally
            {
                watch.Stop();

                // Tính toán thời gian còn lại để đợi trước khi gọi lại callback
                timerLoiLoc.Change(Math.Max(0, TIME_INTERVAL_SAVE - watch.ElapsedMilliseconds), Timeout.Infinite);
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
                    List<Models.NguonModel.Nguon>? l = nguonHistory.Check(list);

                    List<Models.LedModel.Led> listLed = await plcNguon.GetDataLED();
                    List<Models.LedModel.Led>? lLed = ledHistory.Check(listLed);

                    if (l != null && l.Count > 0)
                    {
                        plcNguon.SaveData(l);
                        new SaveToFIleExcel2().SaveNguon("TEST NGUỒN", l);
                    }

                    if (lLed != null && lLed.Count > 0)
                    {
                        plcNguon.SaveDataLed(lLed);
                        new SaveToFIleExcel2().SaveLed("TEST LED", lLed);
                    }



                    await plcNguon.Close();
                }

            }
            catch
            {

            }
            finally
            {
                watch.Stop();

                // Tính toán thời gian còn lại để đợi trước khi gọi lại callback
                timerNguon.Change(Math.Max(0, TIME_INTERVAL_SAVE - watch.ElapsedMilliseconds), Timeout.Infinite);
            }

        }

















        //CT
        private async void CallbackCongTac(Object state)
        {
            Stopwatch watch = new Stopwatch();

            watch.Start();


            // update data
            // Long running operation

            try
            {
                if (await plcCongTac.Open() == true)
                {
                    List<Models.CongTacModel.CongTac> list = await plcCongTac.GetAllData();

                    List<Models.CongTacModel.CongTac>? l = CongTacHistory.Check(list);

                    if (l != null && l.Count > 0)
                    {
                        plcCongTac.SaveData(l);

                        new SaveToFIleExcel2().SaveCongTac("TEST CÔNG TẮC", l);
                    }


                    await plcCongTac.Close();
                }


            }
            catch
            {

            }
            finally
            {
                watch.Stop();

                // Tính toán thời gian còn lại để đợi trước khi gọi lại callback
                timerCongTac.Change(Math.Max(0, TIME_INTERVAL_SAVE - watch.ElapsedMilliseconds), Timeout.Infinite);
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
                    List<JigMachNguon>? l = jigMachNguonHistory.Check(list);

                    if (l != null && l.Count > 0)
                    {
                        new SaveToFIleExcel2().SaveJigMachNguon("TEST MẠCH NGUỒN", l);
                        plcMach.SaveDataMach(l);
                    }


                    List<JigMachTDS> list2 = await plcMach.GetDataMachTDS();

                    List<JigMachTDS>? l2 = JigMachTDSHistory.Check(list2);

                    if (l2 != null && l2.Count > 0)
                    {
                        new SaveToFIleExcel2().SaveJigMachTDS("TEST MẠCH TDS", l2);
                        plcMach.SaveDataTDS(l2);
                    }

                    await plcMach.Close();
                }

            }
            catch
            {

            }
            finally
            {
                watch.Stop();

                // Tính toán thời gian còn lại để đợi trước khi gọi lại callback
                timerMach.Change(Math.Max(0, TIME_INTERVAL_SAVE - watch.ElapsedMilliseconds), Timeout.Infinite);

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

                    List<Models.BepTuModel.BepTu>? l = BepTuHistory.Check(list);

                    if (l != null && l.Count > 0)
                    {
                        plcBepTu.SaveData(l);
                        new SaveToFIleExcel2().SaveBepTu("TEST BẾP TỪ", l);
                    }



                    await plcBepTu.Close();
                }
            }
            catch
            {
                // Xử lý ngoại lệ nếu có
            }
            finally
            {
                watch.Stop();
                // Thực hiện gọi lại callback với thời gian chờ tương ứng
                timerBepTu.Change(Math.Max(0, TIME_INTERVAL_SAVE - watch.ElapsedMilliseconds), Timeout.Infinite);
            }
        }

        public void ConnectAndRunSaveAll()
        {
            timerBauNong = new System.Threading.Timer(CallbackBauNong, null, TIME_INTERVAL_SAVE, Timeout.Infinite);
            timerBepTu = new System.Threading.Timer(CallbackBepTu, null, TIME_INTERVAL_SAVE, Timeout.Infinite);
            timerCongTac = new System.Threading.Timer(CallbackCongTac, null, TIME_INTERVAL_SAVE, Timeout.Infinite);
            timerLoiLoc = new System.Threading.Timer(CallbackLoiLoc, null, TIME_INTERVAL_SAVE, Timeout.Infinite);
            timerMach = new System.Threading.Timer(CallbackMach, null, TIME_INTERVAL_SAVE, Timeout.Infinite);
            timerNguon = new System.Threading.Timer(CallbackNguon, null, TIME_INTERVAL_SAVE, Timeout.Infinite);

        }
    }
}
