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
        public void AddNguon(List<JigMachNguon> listMachNguon)
        {
            DataBaseContext dbContext = new DataBaseContext();
            TestJigMach testID = new TestJigMach();

            dbContext.TestJigMachNguons.Add(testID);
            dbContext.SaveChanges();

            foreach (var i in listMachNguon)
            {
                i.TestJigMachID = testID.TestJigMachID;
            }
            dbContext.JigMachNguons.AddRange(listMachNguon.ToList());

            dbContext.SaveChanges();
        }

        public void AddTDS(List<JigMachTDS> listMachTDS)
        {
            DataBaseContext dbContext = new DataBaseContext();
            TestJigMachTDS testID = new TestJigMachTDS();

            dbContext.TestJigMachTDSs.Add(testID);
            dbContext.SaveChanges();

            foreach (var i in listMachTDS)
            {
                i.TestJigMachTDSID = testID.TestJigMachTDSID;
            }
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

            return dbContext.JigMachTDSs.Where(a => a.TestJigMachTDSID == id).ToList();

        }
    }
}
