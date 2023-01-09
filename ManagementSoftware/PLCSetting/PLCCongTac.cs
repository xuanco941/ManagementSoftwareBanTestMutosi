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


        public async Task<List<Models.CongTacModel.CongTac>> GetData()
        {
            List<Models.CongTacModel.CongTac> list = new List<CongTac>();

            double z = await this.ConvertRealToDouble(20);



            return list;
        }

        public void SaveData(List<Models.CongTacModel.CongTac> listCT)
        {
            if (listCT != null && listCT.Count>0)
            {
                DALCongTac.Add(listCT);
            }

        }
    }
}
