using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.DAL
{
    public class DALCongTac3VT
    {
        public static void Add(List<CongTac3VT> list)
        {
            DataBaseContext dbContext = new DataBaseContext();
            TestCongTac3VT testID = new TestCongTac3VT();

            dbContext.TestCongTac3VTs.Add(testID);
            dbContext.SaveChanges();

            foreach (var i in list)
            {
                if (i != null)
                {
                    i.TestCongTac3VTID = testID.TestCongTac3VTID;
                }
            }
            dbContext.CongTac3VTs.AddRange(list.ToList());
            dbContext.SaveChanges();
        }
    }
}
