using ManagementSoftware.DAL;
using ManagementSoftware.Models.BepTuModel;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.PLCSetting
{
    public class PLCBepTu : PLCMainDB100
    {
        public PLCBepTu(string ip, string name) : base(ip, name) 
        {
        
        }
       
        public async Task<List<BepTu>> GetAllData()
        {
            List<BepTu> list = new List<BepTu>();

            ushort err = await this.ConvertUIntToUshort(48);

            BepTu bepTu1 = new BepTu();
            bepTu1.BepTuName = TenThietBi.BepTu1;
            bepTu1.DienAp = await this.ConvertRealToDouble(8);
            bepTu1.NhietDo = await this.ConvertRealToDouble(0);
            bepTu1.DongDien = await this.ConvertRealToDouble(20);
            bepTu1.CongSuat = await this.ConvertRealToDouble(28);
            bepTu1.CongSuatTieuThu = await this.ConvertRealToDouble(36);
            bepTu1.TrangThai = (await this.ConvertUIntToUshort(40)) == 0 ? false : true;
            bepTu1.LanTestThu = await this.ConvertUIntToUshort(44);


            BepTu bepTu2 = new BepTu();
            bepTu2.BepTuName = TenThietBi.BepTu2;
            bepTu2.DienAp = await this.ConvertRealToDouble(12);
            bepTu2.NhietDo = await this.ConvertRealToDouble(4);
            bepTu2.DongDien = await this.ConvertRealToDouble(16);
            bepTu2.CongSuat = await this.ConvertRealToDouble(24);
            bepTu2.CongSuatTieuThu = await this.ConvertRealToDouble(32);
            bepTu2.TrangThai = (await this.ConvertUIntToUshort(42)) == 0 ? false : true;
            bepTu2.LanTestThu = await this.ConvertUIntToUshort(46);


            if(err == 1)
            {
                bepTu1.Error = "Lỗi cấp nguồn bếp 1";
                bepTu1.isError = true;
            }
            else if (err == 2)
            {
                bepTu2.Error = "Lỗi cấp nguồn bếp 2";
                bepTu2.isError = true;
            }
            else if (err == 3)
            {
                bepTu1.Error = "Lỗi bơm 1";
                bepTu1.isError = true;
            }
            else if (err == 4)
            {
                bepTu2.Error = "Lỗi bơm 2";
                bepTu2.isError = true;
            }
            else
            {
                bepTu1.Error = Common.NOT_ERROR_STR;
                bepTu2.Error = Common.NOT_ERROR_STR;
                bepTu1.isError = false;
                bepTu2.isError = false;
            }

            list.Add(bepTu1);
            list.Add(bepTu2);

            return list;
        }


        public void SaveData(List<BepTu> listBepTu)
        {
            if (listBepTu != null && listBepTu.Count > 0)
            {
                new DALBepTu().Add(listBepTu);
            }
        }


    }
}
