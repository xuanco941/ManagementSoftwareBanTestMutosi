using PROFINET_STEP_7.Profinet;
using ManagementSoftware.DAL;
using ManagementSoftware.Models;

namespace ManagementSoftware.PLCSetting
{
    public class MainPLC
    {
        public static PLC plc;
        public static ExceptionCode errCode;

        public static string message = "";

        public static void Start()
        {
            string ip = "192.168.0.12";
            CPU_Type cpu = CPU_Type.S71200;
            short rack = 0;
            short slot = 1;

            plc = new PLC(cpu, ip, rack, slot);
            try
            {
                if (string.IsNullOrEmpty(plc.IP))
                {
                    message = "*Thiếu địa chỉ IP";
                    throw new Exception("Xin vui lòng nhập địa chỉ IP");
                }
                if (!plc.IsAvailable)
                {
                    message = "*Không tìm thấy PLC cần kết nối!";
                    throw new Exception("Không tìm thấy PLC cần kết nối!");
                }
                errCode = plc.Open();
                if (errCode != ExceptionCode.ExceptionNo)
                {
                    message = "*Lỗi: " + plc.lastErrorString.ToString();
                    throw new Exception(plc.lastErrorString);
                }

                // success
                message = null;
                DALActivity.AddActivity(new Activity("Khởi động ứng dụng", "Kết nối tới PLC thành công.", ""));
            }
            catch
            {
                //message = "Không thể kết nối";
            }
        }


        public static void Stop()
        {
            try
            {
                plc.Close();
            }
            catch (Exception ex)
            {
                message = "*Lỗi đóng máy: " + ex.Message;
            }
        }


        public static void GetDataJigMachNguon()
        {
            DataPLC.DongDien = new List<double>();
            DataPLC.DienAp = new List<double>();
            DataPLC.CongSuat = new List<double>();

            //(READ) JigMachNguon DB100.DB

            int firstElementDienAp = 0;
            int firstElementDongDien = 40;
            int firstElementCongSuat = 80;

            for (int i = 0; i < 10; i++)
            {
                int khoangCachVungNhoTiepTheo = i * 4;
                string adrrDienAp = "DB100.DBD" + (firstElementDienAp + khoangCachVungNhoTiepTheo);
                string adrrCongSuat = "DB100.DBD" + (firstElementCongSuat + khoangCachVungNhoTiepTheo);
                string adrrDongDien = "DB100.DBD" + (firstElementDongDien + khoangCachVungNhoTiepTheo);

                DataPLC.DongDien.Add(Math.Round(PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read(adrrDongDien)), 2, MidpointRounding.AwayFromZero));
                DataPLC.CongSuat.Add(Math.Round(PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read(adrrCongSuat)), 2, MidpointRounding.AwayFromZero));
                DataPLC.DienAp.Add(Math.Round(PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read(adrrDienAp)), 2, MidpointRounding.AwayFromZero));

            }


            ////paramete
            //CurrentValuePLC.pH = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB16.DBD0"));

            ////luu luong
            //CurrentValuePLC.luuLuongTong = PROFINET_STEP_7.Types.Double.FromDWord((uint)plc.Read("DB16.DBD16"));




            //////status_position DB17
            //CurrentValuePLC.status_position_DB17_1 = (ushort)plc.Read("DB17.DBW0");

            //////status_position DB18
            //CurrentValuePLC.status_position_DB18_1 = (ushort)plc.Read("DB18.DBW0");

        }
    }
}
