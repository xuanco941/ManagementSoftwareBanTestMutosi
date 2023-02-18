using ManagementSoftware.DAL;
using ManagementSoftware.Models.JigMachModel;
using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.PLCSetting
{
    public class PLCMach : PLCMainDB100
    {


        public PLCMach(string ip , string name) : base(ip, name)
        {
         
        }


        public async Task<List<JigMachNguon>> GetDataMachNguon()
        {
            //dienAp 0-36 real
            //dong dien 40-76 real
            //cong suat 80-116 real
            //so lan test nguon 168-204


            List<JigMachNguon> listMachNguon = new List<JigMachNguon>();
            int dienAp = 0;
            int dongDien = 40;
            int congSuat = 80;
            int time = 240;
            int lantestthu = 340;

            //err
            int errDong = 160;
            int errDienAp = 180;


            for (int i = 0; i < 10; i++)
            {
                JigMachNguon jig = new JigMachNguon();
                jig.JigMachNguonName = "Jig "+ (i+1).ToString();

                jig.DienApDC = await this.ConvertRealToDouble(dienAp);
                jig.DongDienDC = await this.ConvertRealToDouble(dongDien);
                jig.CongSuat = await this.ConvertRealToDouble(congSuat);
                jig.ThoiGian = await this.ConvertUDIntToUInt(time);
                jig.LanTestThu = await this.ConvertUIntToUshort(lantestthu);
                


                //err
                jig.Error_Dong = await this.ConvertUIntToUshort(errDong) != 0 ? true : false;
                jig.Error_Ap = await this.ConvertUIntToUshort(errDienAp) != 0 ? true : false;

                jig.Error = jig.Error_Dong && jig.Error_Ap ? "Lỗi dòng, lỗi áp" :
                                jig.Error_Dong ? "Lỗi dòng" :
                                jig.Error_Ap ? "Lỗi áp" :
                                Common.NOT_ERROR_STR;

                listMachNguon.Add(jig);

                dienAp = dienAp + 4;
                dongDien = dongDien + 4;
                congSuat = congSuat + 4;
                time = time + 4;
                lantestthu = lantestthu + 2;

                //err
                errDong = errDong+ 2;
                errDienAp = errDienAp + 2;

            }
            return listMachNguon;

        }

        public async Task<List<JigMachTDS>> GetDataMachTDS()
        {
            //dien ap tds 120-156
            //slt 208-244
            int time = 280;
            int lantestthu = 320;
            int vandt = 220;
            int vanapcao = 180;

            int err_th_van_dt = 220;

            List<JigMachTDS> listJigMachTDS = new List<JigMachTDS>();

            for (int i = 0; i < 10; i++)
            {
                JigMachTDS jig = new JigMachTDS();
                jig.JigMachTDSName = "Jig " + (i + 1).ToString();
                jig.ThoiGian = await this.ConvertUDIntToUInt(time);
                jig.LanTestThu = await this.ConvertUIntToUshort(lantestthu);
                jig.VanDienTu = await this.ConvertUIntToUshort(vandt) == 0 ? false : true;
                jig.VanApCao = await this.ConvertUIntToUshort(vanapcao) == 0 ? false : true;

                jig.Error_Van_DT = await this.ConvertUIntToUshort(err_th_van_dt) != 0 ? true : false;

                jig.Error = jig.Error_Van_DT==true ? "Lỗi van điện từ" : Common.NOT_ERROR_STR;

                listJigMachTDS.Add(jig);

                time = time + 4;
                lantestthu = lantestthu + 2;
                vanapcao = vanapcao + 2;
                vandt = vandt + 2;
                err_th_van_dt = err_th_van_dt + 2;
            }

            return listJigMachTDS;
        }

        public void SaveData(List<JigMachNguon> listNguon, List<JigMachTDS> listTDS)
        {
            if (listNguon != null && listNguon.Count >0 && listTDS!=null && listTDS.Count>0)
            {
                new DALJigMach().Add(listNguon,listTDS);
            }
        }

    }
}
