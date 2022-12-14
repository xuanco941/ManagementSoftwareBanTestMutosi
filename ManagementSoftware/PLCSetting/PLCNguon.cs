using ManagementSoftware.DAL;
using ManagementSoftware.Models;
using S7.Net;


namespace ManagementSoftware.PLCSetting
{
    public class PLCNguon
    {
        public static Plc plc { get; set; }

        public static string plcName = "PLC Nguồn";
        public static string message { get; set; } = "";
        public static List<Models.Nguon> listNguonTu1Den15 { get; set; } = new List<Models.Nguon>();
        public static List<Models.Nguon> listNguonTu16Den30 { get; set; } = new List<Models.Nguon>();


        public static void Start()
        {
            string ip = "192.168.0.17";
            S7.Net.CpuType cpu = CpuType.S71200;
            short rack = 0;
            short slot = 1;
            plc = new Plc(cpu, ip, rack, slot);

            try
            {
                if (string.IsNullOrEmpty(plc.IP))
                {
                    message = $"*{plcName} thiếu địa chỉ IP";
                    throw new Exception($"Xin vui lòng nhập địa chỉ IP {plcName}");
                }
                plc.Open();
                if (!plc.IsConnected)
                {
                    message = $"*Không tìm thấy {plcName}!";
                    throw new Exception($"Không tìm thấy {plcName}!");
                }


                // success
                message = "";
            }
            catch
            {
                message = $"Không thể kết nối tới {plcName}";
            }
        }


        public static void Stop()
        {
            try
            {
                plc.Close();
                message = "";
            }
            catch (Exception ex)
            {
                message = "*Lỗi đóng máy: " + ex.Message;
            }
        }

        public static void GetDataTu1Den15()
        {
            listNguonTu1Den15 = new List<Models.Nguon>();
            string db = "DB100.";
            int dienApCSAddr = 0;
            int dongDienCSAddr = 120;
            int congSuatCSAddr = 240;
            int timeAddr = 360;
            int soLanTestAddr = 480;


            for (int i = 0; i <= 14; i++)
            {
                Models.Nguon nguon = new Models.Nguon();
                try
                {
                    object? dienApDCVar = plc.Read(db + "DBD" + dienApCSAddr);
                    object? DongDCVar = plc.Read(db + "DBD" + dongDienCSAddr);
                    object? congSuatVar = plc.Read(db + "DBD" + congSuatCSAddr);
                    object? thoiGianTestVar = plc.Read(db + "DBD" + timeAddr);
                    object? soLanTestVar = plc.Read(db + "DBW" + soLanTestAddr);

                    nguon.DienApDC = dienApDCVar != null ? Math.Round(Conversion.ConvertToFloat((uint)dienApDCVar), 3, MidpointRounding.AwayFromZero).ToString() : "N/A";
                    nguon.DongDC = DongDCVar != null ? Math.Round(Conversion.ConvertToFloat((uint)DongDCVar), 3, MidpointRounding.AwayFromZero).ToString() : "N/A";
                    nguon.CongSuat = congSuatVar != null ? Math.Round(Conversion.ConvertToFloat((uint)congSuatVar), 3, MidpointRounding.AwayFromZero).ToString() : "N/A";
                    nguon.ThoiGianTest = thoiGianTestVar != null ? ((uint)thoiGianTestVar).ToString() : "N/A";
                    nguon.SoLanTest = soLanTestVar != null ? ((ushort)soLanTestVar).ToString() : "N/A";
                }
                catch
                {
                    Stop();
                }
                


                //bool c = (bool)plc.Read("DB100.DBX544.1");

                nguon.NguonName = "Nguồn " + (i + 1);
                dienApCSAddr += 4;
                dongDienCSAddr += 4;
                congSuatCSAddr += 4;
                timeAddr += 4;
                soLanTestAddr += 2;

                listNguonTu1Den15.Add(nguon);
            }
        }
        public static void GetDataTu16Den30()
        {
            listNguonTu16Den30 = new List<Models.Nguon>();
            string db = "DB100.";
            int dienApCSAddr = 60;
            int dongDienCSAddr = 180;
            int congSuatCSAddr = 300;
            int timeAddr = 420;
            int soLanTestAddr = 510;


            for (int i = 15; i <= 29; i++)
            {
                Models.Nguon nguon = new Models.Nguon();
                try
                {
                    object? dienApDCVar = plc.Read(db + "DBD" + dienApCSAddr);
                    object? DongDCVar = plc.Read(db + "DBD" + dongDienCSAddr);
                    object? congSuatVar = plc.Read(db + "DBD" + congSuatCSAddr);
                    object? thoiGianTestVar = plc.Read(db + "DBD" + timeAddr);
                    object? soLanTestVar = plc.Read(db + "DBW" + soLanTestAddr);

                    nguon.DienApDC = dienApDCVar != null ? Math.Round(Conversion.ConvertToFloat((uint)dienApDCVar), 3, MidpointRounding.AwayFromZero).ToString() : "N/A";
                    nguon.DongDC = DongDCVar != null ? Math.Round(Conversion.ConvertToFloat((uint)DongDCVar), 3, MidpointRounding.AwayFromZero).ToString() : "N/A";
                    nguon.CongSuat = congSuatVar != null ? Math.Round(Conversion.ConvertToFloat((uint)congSuatVar), 3, MidpointRounding.AwayFromZero).ToString() : "N/A";
                    nguon.ThoiGianTest = thoiGianTestVar != null ? ((uint)thoiGianTestVar).ToString() : "N/A";
                    nguon.SoLanTest = soLanTestVar != null ? ((ushort)soLanTestVar).ToString() : "N/A";
                }
                catch
                {
                    Stop();
                }



                //bool c = (bool)plc.Read("DB100.DBX544.1");

                nguon.NguonName = "Nguồn " + (i + 1);
                dienApCSAddr += 4;
                dongDienCSAddr += 4;
                congSuatCSAddr += 4;
                timeAddr += 4;
                soLanTestAddr += 2;

                listNguonTu16Den30.Add(nguon);
            }
        }






        public static void SaveData()
        {
            List<Nguon> listNguonSave = new List<Models.Nguon>();
            string db = "DB100.";
            int dienApCSAddr = 0;
            int dongDienCSAddr = 120;
            int congSuatCSAddr = 240;
            int timeAddr = 360;
            int soLanTestAddr = 480;


            for (int i = 0; i <= 29; i++)
            {
                Models.Nguon nguon = new Models.Nguon();

                try
                {
                    object? dienApDCVar = plc.Read(db + "DBD" + dienApCSAddr);
                    object? DongDCVar = plc.Read(db + "DBD" + dongDienCSAddr);
                    object? congSuatVar = plc.Read(db + "DBD" + congSuatCSAddr);
                    object? thoiGianTestVar = plc.Read(db + "DBD" + timeAddr);
                    object? soLanTestVar = plc.Read(db + "DBW" + soLanTestAddr);

                    nguon.DienApDC = dienApDCVar != null ? Math.Round(Conversion.ConvertToFloat((uint)dienApDCVar), 3, MidpointRounding.AwayFromZero).ToString() : "N/A";
                    nguon.DongDC = DongDCVar != null ? Math.Round(Conversion.ConvertToFloat((uint)DongDCVar), 3, MidpointRounding.AwayFromZero).ToString() : "N/A";
                    nguon.CongSuat = congSuatVar != null ? Math.Round(Conversion.ConvertToFloat((uint)congSuatVar), 3, MidpointRounding.AwayFromZero).ToString() : "N/A";
                    nguon.ThoiGianTest = thoiGianTestVar != null ? ((uint)thoiGianTestVar).ToString() : "N/A";
                    nguon.SoLanTest = soLanTestVar != null ? ((ushort)soLanTestVar).ToString() : "N/A";
                    //bool c = (bool)plc.Read("DB100.DBX544.1");
                }
                catch
                {
                    ControlAllPLC.StopNguon();
                    Stop();
                }


                nguon.NguonName = "Nguồn " + (i + 1);
                dienApCSAddr += 4;
                dongDienCSAddr += 4;
                congSuatCSAddr += 4;
                timeAddr += 4;
                soLanTestAddr += 2;

                listNguonSave.Add(nguon);
            }

            DALNguon.Add(listNguonSave);
        }
    }
}