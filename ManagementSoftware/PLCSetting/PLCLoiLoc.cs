using ManagementSoftware.DAL;
using ManagementSoftware.Models.LoiLocModel;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.PLCSetting
{
    public class PLCLoiLoc : PLCMainDB100
    {


        public PLCLoiLoc(string ip, string name) : base(ip, name)
        {

        }

        public async Task<LoiLoc> GetData()
        {
            LoiLoc loiloc = new Models.LoiLocModel.LoiLoc();


            var thoiGianNen = this.ConvertUDIntToUInt(74);
            var thoiGianGiu = this.ConvertUDIntToUInt(78);
            var thoiGianXa = this.ConvertUDIntToUInt(82);
            var ApSuatTest = this.ConvertRealToDouble(36);
            var SoLanTest = this.ConvertUIntToUshort(34);
            var loaiLoiLocTest = this.ConvertUIntToUshort(64);

            var err = this.ConvertUIntToUshort(86);

            await Task.WhenAll(thoiGianNen, thoiGianXa, thoiGianGiu, ApSuatTest, SoLanTest, loaiLoiLocTest, err);


            loiloc.ThoiGianNen = thoiGianNen.Result;
            loiloc.ThoiGianGiu = thoiGianGiu.Result;
            loiloc.ThoiGianXa = thoiGianXa.Result;
            loiloc.ApSuatTest = ApSuatTest.Result;
            loiloc.SoLanTest = SoLanTest.Result;
            loiloc.Error = err.Result != 0 ? "Lỗi" : "Không";



            if (loaiLoiLocTest.Result == 1)
            {
                loiloc.LoiLocName = TenThietBi.LoiLoc1;
            }
            else if (loaiLoiLocTest.Result == 2)
            {
                loiloc.LoiLocName = TenThietBi.LoiLoc2;
            }
            else
            {
                loiloc.LoiLocName = TenThietBi.LoiLoc1va2;
            }


            return loiloc;

        }
        public void SaveData(LoiLoc loiLoc)
        {
            if (loiLoc != null)
            {
                new DALLoiLoc().Add(loiLoc);
            }
        }
    }
}
