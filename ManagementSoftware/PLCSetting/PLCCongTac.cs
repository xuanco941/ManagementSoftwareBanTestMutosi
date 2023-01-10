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


        public async Task<List<Models.CongTacModel.CongTac>> GetData(double addrCT1, double addrCT2, double addrCT3, double addrCT4, double addrCT5, int jig)
        {
            List<Models.CongTacModel.CongTac> list = new List<CongTac>();

            CongTac ct1 = new CongTac();
            ct1.TrangThai = await this.ConvertUIntToUshort(addrCT1) == 0 ? false : true;
            ct1.CongTacName = TenThietBi.CongTac1Jig1;
            ct1.JigCongTac = "Jig " + jig;
            ct1.LanTestThu = await this.ConvertUIntToUshort(118); ;
            list.Add(ct1);


            CongTac ct2 = new CongTac();
            ct2.TrangThai = await this.ConvertUIntToUshort(addrCT2) == 0 ? false : true;
            ct2.CongTacName = TenThietBi.CongTac2Jig1;
            ct2.JigCongTac = "Jig " + jig;
            ct2.LanTestThu = await this.ConvertUIntToUshort(118); ;
            list.Add(ct2);

            CongTac ct3 = new CongTac();
            ct3.TrangThai = await this.ConvertUIntToUshort(addrCT3) == 0 ? false : true;
            ct3.CongTacName = TenThietBi.CongTac3Jig1;
            ct3.JigCongTac = "Jig " + jig;
            ct3.LanTestThu = await this.ConvertUIntToUshort(118); ;
            list.Add(ct3);

            CongTac ct4 = new CongTac();
            ct4.TrangThai = await this.ConvertUIntToUshort(addrCT4) == 0 ? false : true;
            ct4.CongTacName = TenThietBi.CongTac4Jig1;
            ct4.JigCongTac = "Jig " + jig;
            ct4.LanTestThu = await this.ConvertUIntToUshort(118); ;
            list.Add(ct4);


            CongTac ct5 = new CongTac();
            ct5.TrangThai = await this.ConvertUIntToUshort(addrCT5) == 0 ? false : true;
            ct5.CongTacName = TenThietBi.CongTac5Jig1;
            ct5.JigCongTac = "Jig " + jig;
            ct5.LanTestThu = await this.ConvertUIntToUshort(118); ;
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
