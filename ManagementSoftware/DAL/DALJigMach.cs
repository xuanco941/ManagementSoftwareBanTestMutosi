using ManagementSoftware.Models;
using ManagementSoftware.Models.JigMachModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.DAL
{
    public class DALJigMach
    {
        public void Add(List<JigMachNguon> listMachNguon, List<JigMachTDS> listMachTDS)
        {
            DataBaseContext dbContext = new DataBaseContext();
            TestJigMach testID = new TestJigMach();

            dbContext.TestJigMachs.Add(testID);
            dbContext.SaveChanges();

            foreach (var i in listMachNguon)
            {
                i.TestJigMachID = testID.TestJigMachID;
            }
            foreach (var i in listMachTDS)
            {
                i.TestJigMachID = testID.TestJigMachID;
            }
            dbContext.JigMachNguons.AddRange(listMachNguon.ToList());
            dbContext.JigMachTDSs.AddRange(listMachTDS.ToList());

            dbContext.SaveChanges();
        }
        public List<JigMachNguon>? GetDataFromIDTest(int id)
        {
            DataBaseContext dbContext = new DataBaseContext();

            return dbContext.JigMachNguons.Where(a => a.TestJigMachID == id).ToList();

        }
        public List<JigMachTDS>? GetDataFromIDTestTDS(int id)
        {
            DataBaseContext dbContext = new DataBaseContext();

            return dbContext.JigMachTDSs.Where(a => a.TestJigMachID == id).ToList();

        }
    }
}
