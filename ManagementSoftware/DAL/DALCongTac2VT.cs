using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.DAL
{
    public class DALCongTac2VT
    {
        public static void Add(List<CongTac2VT> list)
        {
            DataBaseContext dbContext = new DataBaseContext();
            TestCongTac2VT testID = new TestCongTac2VT();

            dbContext.TestCongTac2VTs.Add(testID);
            dbContext.SaveChanges();

            foreach (var i in list)
            {
                if (i != null)
                {
                    i.TestCongTac2VTID = testID.TestCongTac2VTID;
                }
            }
            dbContext.CongTac2VTs.AddRange(list);
            dbContext.SaveChanges();
        }
    }
}
