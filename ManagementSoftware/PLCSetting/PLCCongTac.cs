using ManagementSoftware.DAL;
using ManagementSoftware.Models;
using ManagementSoftware.Models.CongTacModel;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.PLCSetting
{
    public class PLCCongTac : PLCMainDB100
    {
        public PLCCongTac(string ip, string name) : base(ip, name)
        {

        }

        public async Task<List<Models.CongTacModel.CongTac>> GetAllData()
        {
            List<CongTac> jig10 = await this.GetData(104, 106, 108, 110, 112, 10, 210);
            List<CongTac> jig9 = await this.GetData(94, 96, 98, 100, 102, 9, 200);
            List<CongTac> jig8 = await this.GetData(84, 86, 88, 90, 92, 8, 190);
            List<CongTac> jig7 = await this.GetData(74, 76, 78, 80, 82, 7, 180);
            List<CongTac> jig6 = await this.GetData(64, 66, 70, 52, 72, 6, 170);
            List<CongTac> jig5 = await this.GetData(40, 42, 44, 46, 48, 5, 160);
            List<CongTac> jig4 = await this.GetData(30, 32, 34, 36, 38, 4, 150);
            List<CongTac> jig3 = await this.GetData(20, 22, 24, 26, 28, 3, 140);
            List<CongTac> jig2 = await this.GetData(50, 12, 14, 16, 18, 2, 130);
            List<CongTac> jig1 = await this.GetData(0, 2, 4, 6, 8, 1, 120);


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

            return list;
        }

        public async Task<List<Models.CongTacModel.CongTac>> GetData(double addrCT1, double addrCT2, double addrCT3, double addrCT4, double addrCT5, int jig, double err)
        {
            List<Models.CongTacModel.CongTac> list = new List<CongTac>();

            ushort lantestValue = await this.ConvertUIntToUshort(118);


            CongTac ct1 = new CongTac();
            ct1.TrangThai = await this.ConvertUIntToUshort(addrCT1) == 0 ? false : true;
            ct1.isError = await this.ConvertUIntToUshort(err) != 0 ? true : false;
            ct1.Error = ct1.isError == true ? "Lỗi" : "Không";
            ct1.CongTacName = TenThietBi.CongTac1Jig1;
            ct1.JigCongTac = "Jig " + jig;
            ct1.LanTestThu = lantestValue;
            list.Add(ct1);


            CongTac ct2 = new CongTac();
            ct2.TrangThai = await this.ConvertUIntToUshort(addrCT2) == 0 ? false : true;
            ct2.isError = await this.ConvertUIntToUshort(err + 2) != 0 ? true : false;
            ct2.Error = ct2.isError == true ? "Lỗi" : "Không";

            ct2.CongTacName = TenThietBi.CongTac2Jig1;
            ct2.JigCongTac = "Jig " + jig;
            ct2.LanTestThu = lantestValue;
            list.Add(ct2);


            CongTac ct3 = new CongTac();
            ct3.TrangThai = await this.ConvertUIntToUshort(addrCT3) == 0 ? false : true;
            ct3.isError = await this.ConvertUIntToUshort(err + 4) != 0 ? true : false;
            ct3.Error = ct3.isError == true ? "Lỗi" : "Không";

            ct3.CongTacName = TenThietBi.CongTac3Jig1;
            ct3.JigCongTac = "Jig " + jig;
            ct3.LanTestThu = lantestValue;
            list.Add(ct3);

            CongTac ct4 = new CongTac();
            ct4.TrangThai = await this.ConvertUIntToUshort(addrCT4) == 0 ? false : true;
            ct4.isError = await this.ConvertUIntToUshort(err + 6) != 0 ? true : false;
            ct4.Error = ct4.isError == true ? "Lỗi" : "Không";


            ct4.CongTacName = TenThietBi.CongTac4Jig1;
            ct4.JigCongTac = "Jig " + jig;
            ct4.LanTestThu = lantestValue;
            list.Add(ct4);


            CongTac ct5 = new CongTac();
            ct5.TrangThai = await this.ConvertUIntToUshort(addrCT5) == 0 ? false : true;
            ct5.isError = await this.ConvertUIntToUshort(err + 8) != 0 ? true : false;
            ct5.Error = ct5.isError == true ? "Lỗi" : "Không";

            ct5.CongTacName = TenThietBi.CongTac5Jig1;
            ct5.JigCongTac = "Jig " + jig;
            ct5.LanTestThu = lantestValue;
            list.Add(ct5);


            return list;
        }




        public void SaveData(List<Models.CongTacModel.CongTac> listCT)
        {
            if (listCT != null && listCT.Count > 0)
            {
                new DALCongTac().Add(listCT);
            }

        }
    }
}
