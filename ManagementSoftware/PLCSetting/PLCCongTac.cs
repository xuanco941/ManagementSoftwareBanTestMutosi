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


        public void GetData()
        {

        }

        List<CongTac> listCT = new List<CongTac>();

        public void SaveData()
        {
            if (listCT != null && listCT.Count>0)
            {
                DALCongTac.Add(listCT);
            }

        }
    }
}
