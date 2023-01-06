using ManagementSoftware.DAL;
using ManagementSoftware.Models.BauNongModel;
using S7.Net;
using Syncfusion.XPS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.PLCSetting
{
    public class PLCBauNong : PLCMainDB100
    {
        public PLCBauNong(string ip, string plcName) : base(ip, plcName)
        {

        }

        public async Task<List<BauNong>> GetAllData()
        {
            List<BauNong> listBauNong = new List<BauNong>();

            int dongDienAC = 0;
            int nhietDoPC = 40;
            int SoLanTest_ST_PC = 60;
            int SoLanTest_SP_PC = 80;
            int nhietDoNgatCBNhiet = 100;

            int cbNhiet = 120;


            for (int i = 0; i <= 9; i++)
            {
                BauNong obj = new BauNong();
                obj.DongDienAC = await this.ConvertRealToDouble(dongDienAC);
                obj.NhietDo = await this.ConvertRealToDouble(nhietDoPC);
                obj.SoLanTest = await this.ConvertUIntToUshort(SoLanTest_ST_PC);
                obj.NhietDoNgatCBNhiet = await this.ConvertUIntToUshort(nhietDoNgatCBNhiet);
                obj.CBNhietThanBauNong = await this.ConvertUIntToUshort(cbNhiet) == 0 ? false : true;


                obj.BauNongName = "Jig " + (i + 1);
                dongDienAC += 4;
                nhietDoPC += 2;
                SoLanTest_ST_PC += 2;
                SoLanTest_SP_PC += 2;
                nhietDoNgatCBNhiet += 2;
                cbNhiet += 2;

                listBauNong.Add(obj);
            }

            return listBauNong;
        }

        public void SaveData(List<BauNong> listBauNong)
        {
            if (listBauNong != null && listBauNong.Count > 0)
            {
                DALBauNong.Add(listBauNong);
            }
        }
    }
}
