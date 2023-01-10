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
       
        public async Task<List<BepTu>> GetData()
        {
            List<BepTu> list = new List<BepTu>();



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
