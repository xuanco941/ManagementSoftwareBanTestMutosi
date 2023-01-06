using ManagementSoftware.DAL;
using ManagementSoftware.Models;
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
            int slt = 168;
            for (int i = 0; i < 10; i++)
            {
                JigMachNguon jig = new JigMachNguon();
                jig.JigMachNguonName = "Jig "+ (i+1).ToString();

                jig.DienAp = await this.ConvertRealToDouble(dienAp);
                jig.DongDien = await this.ConvertRealToDouble(dongDien);
                jig.CongSuat = await this.ConvertRealToDouble(congSuat);
                jig.SoLanTest = await this.ConvertUDIntToUInt(slt);


                listMachNguon[i] = jig;

                dienAp = dienAp + 4;
                dongDien = dongDien + 4;
                congSuat = congSuat + 4;
                slt = slt + 4;
            }
            return listMachNguon;

        }

        public async Task<List<JigMachTDS>> GetDataMachTDS()
        {
            //dien ap tds 120-156
            //slt 208-244
            int slt = 208;

            List<JigMachTDS> listJigMachTDS = new List<JigMachTDS>();

            for (int i = 0; i < 10; i++)
            {
                JigMachTDS jig = new JigMachTDS();
                jig.JigMachTDSName = "Jig " + (i + 1).ToString();
                jig.SoLanTest = await this.ConvertUDIntToUInt(slt);

                listJigMachTDS[i] = jig;

                slt = slt + 4;

            }

            return listJigMachTDS;
        }

        public void SaveData(List<JigMachNguon> listNguon, List<JigMachTDS> listTDS)
        {
            if (listNguon != null && listNguon.Count >0 && listTDS!=null && listTDS.Count>0)
            {
                DALJigMach.Add(listNguon,listTDS);
            }
        }

    }
}
