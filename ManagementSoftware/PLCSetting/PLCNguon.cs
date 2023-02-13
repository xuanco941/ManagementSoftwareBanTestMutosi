using ManagementSoftware.DAL;
using ManagementSoftware.Models;
using ManagementSoftware.Models.NguonModel;
using S7.Net;


namespace ManagementSoftware.PLCSetting
{
    public class PLCNguon : PLCMainDB100
    {
        public PLCNguon(string ip, string plcName) : base(ip, plcName)
        {

        }

        public async Task<List<Nguon>> GetDataNguon()
        {

            List<Nguon> listNguon = new List<Nguon>();

            int dienApCSAddr = 0;
            int dongDienCSAddr = 120;
            int congSuatCSAddr = 240;
            int timeAddr = 360;
            int soLanTestAddr = 480;
            int errDong = 540;
            int errAp = 600;

            for (int i = 0; i < 30; i++)
            {
                Nguon nguon = new Nguon();
                nguon.DienApDC = await this.ConvertRealToDouble(dienApCSAddr);
                nguon.DongDC = await this.ConvertRealToDouble(dongDienCSAddr);
                nguon.CongSuat = await this.ConvertRealToDouble(congSuatCSAddr);
                nguon.ThoiGianTest = await this.ConvertUDIntToUInt(timeAddr);
                nguon.LanTestThu = await this.ConvertUIntToUshort(soLanTestAddr);
                nguon.isErrorDong = await this.ConvertUIntToUshort(errDong) == 0 ? false : true;
                nguon.isErrorAp = await this.ConvertUIntToUshort(errAp) == 0 ? false : true;

                nguon.NguonName = "Nguồn " + (i + 1);

                listNguon.Add(nguon);

                dienApCSAddr += 4;
                dongDienCSAddr += 4;
                congSuatCSAddr += 4;
                timeAddr += 4;
                soLanTestAddr += 2;
                errDong += 2;
                errAp += 2;
            }

            return listNguon;
        }


        public async Task<List<Models.LedModel.Led>> GetDataLED()
        {

            List<Models.LedModel.Led> listLED = new List<Models.LedModel.Led>();

            int thoiGianTest = 660;
            int soLanTestAddr = 780;

            for (int i = 0; i < 30; i++)
            {
                Models.LedModel.Led led = new Models.LedModel.Led();
                led.ThoiGianTest = await this.ConvertUDIntToUInt(660);
                led.LanTestThu = await this.ConvertUIntToUshort(780);
                led.LedName = "Nguồn " + (i + 1);

                listLED.Add(led);

                thoiGianTest += 4;
                soLanTestAddr += 2;
            }

            return listLED;
        }




        public void SaveData(List<Nguon> list)
        {
            if (list != null && list.Count > 0)
            {
                new DALNguon().Add(list);
            }
        }

        public void SaveDataLed(List<Models.LedModel.Led> list)
        {
            if (list != null && list.Count > 0)
            {
                new DALLed().Add(list);
            }
        }
    }
}