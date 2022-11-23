using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.DAL
{
    public class DALJigMach
    {
        public static void Add(List<JigMachNguon> listMachNguon, List<JigMachTDS> listMachTDS)
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
            dbContext.JigMachNguons.AddRange(listMachNguon);
            dbContext.JigMachTDSs.AddRange(listMachTDS);

            dbContext.SaveChanges();
        }
    }
}
