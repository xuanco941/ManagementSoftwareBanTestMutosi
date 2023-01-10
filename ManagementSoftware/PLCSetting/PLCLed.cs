using ManagementSoftware.DAL;
using ManagementSoftware.Models.LedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.PLCSetting
{
    public class PLCLed : PLCMainDB100
    {
        public PLCLed(string ip, string plcName) : base(ip, plcName)
        {

        }

        public async Task<List<Led>> GetDataLed1Den15()
        {

            List<Led> listNguonTu1Den15 = new List<Led>();

            int dienApCSAddr = 0;
            int dongDienCSAddr = 120;
            int congSuatCSAddr = 240;
            int timeAddr = 360;
            int soLanTestAddr = 480;

            for (int i = 0; i < 15; i++)
            {
                Led nguon = new Led();
                nguon.ThoiGianTest = await this.ConvertUDIntToUInt(timeAddr);
                nguon.LanTestThu = await this.ConvertUIntToUshort(soLanTestAddr);
                nguon.LedName = "Nguồn " + (i + 1);

                listNguonTu1Den15.Add(nguon);

                dienApCSAddr += 4;
                dongDienCSAddr += 4;
                congSuatCSAddr += 4;
                timeAddr += 4;
                soLanTestAddr += 2;
            }

            return listNguonTu1Den15;
        }



        public async Task<List<Led>> GetDataLed16Den30()
        {

            List<Led> listNguonTu16Den30 = new List<Led>();

            int dienApCSAddr = 60;
            int timeAddr = 420;
            int soLanTestAddr = 510;

            for (int i = 15; i < 30; i++)
            {
                Led nguon = new Led();
                nguon.TrangThai = false;
                nguon.ThoiGianTest = await this.ConvertUDIntToUInt(timeAddr);
                nguon.LanTestThu = await this.ConvertUIntToUshort(soLanTestAddr);
                nguon.LedName = "Nguồn " + (i + 1);

                listNguonTu16Den30.Add(nguon);

                dienApCSAddr += 4;

                timeAddr += 4;
                soLanTestAddr += 2;
            }

            return listNguonTu16Den30;
        }



        public void SaveData(List<Led> list)
        {
            if (list != null && list.Count > 0)
            {
                DALLed.Add(list);
            }
        }
    }
}
