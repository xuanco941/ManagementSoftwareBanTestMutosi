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

        public async Task<List<Nguon>> GetDataNguon1Den15()
        {

        List<Nguon> listNguonTu1Den15 = new List<Nguon>();

            int dienApCSAddr = 0;
            int dongDienCSAddr = 120;
            int congSuatCSAddr = 240;
            int timeAddr = 360;
            int soLanTestAddr = 480;

            for (int i = 0; i < 15; i++)
            {
                Nguon nguon = new Nguon();
                nguon.DienApDC = await this.ConvertRealToDouble(dienApCSAddr);
                nguon.DongDC = await this.ConvertRealToDouble(dongDienCSAddr);
                nguon.CongSuat = await this.ConvertRealToDouble(congSuatCSAddr);
                nguon.ThoiGianTest = await this.ConvertUDIntToUInt(timeAddr);
                nguon.SoLanTest = await this.ConvertUIntToUshort(soLanTestAddr);
                nguon.NguonName = "Nguồn " + (i + 1);

                listNguonTu1Den15.Add(nguon);

                dienApCSAddr += 4;
                dongDienCSAddr += 4;
                congSuatCSAddr += 4;
                timeAddr += 4;
                soLanTestAddr += 2;
            }

            return listNguonTu1Den15;
        }



        public async Task<List<Nguon>> GetDataNguon16Den30()
        {

            List<Nguon> listNguonTu16Den30 = new List<Nguon>();

            int dienApCSAddr = 60;
            int dongDienCSAddr = 180;
            int congSuatCSAddr = 300;
            int timeAddr = 420;
            int soLanTestAddr = 510;

            for (int i = 15; i < 30; i++)
            {
                Nguon nguon = new Nguon();
                nguon.DienApDC = await this.ConvertRealToDouble(dienApCSAddr);
                nguon.DongDC = await this.ConvertRealToDouble(dongDienCSAddr);
                nguon.CongSuat = await this.ConvertRealToDouble(congSuatCSAddr);
                nguon.ThoiGianTest = await this.ConvertUDIntToUInt(timeAddr);
                nguon.SoLanTest = await this.ConvertUIntToUshort(soLanTestAddr);
                nguon.NguonName = "Nguồn " + (i + 1);

                listNguonTu16Den30.Add(nguon);

                dienApCSAddr += 4;
                dongDienCSAddr += 4;
                congSuatCSAddr += 4;
                timeAddr += 4;
                soLanTestAddr += 2;
            }

            return listNguonTu16Den30;
        }



        public void SaveData(List<Nguon> list)
        {
            if (list != null && list.Count > 0 )
            {
                DALNguon.Add(list);
            }
        }
    }
}