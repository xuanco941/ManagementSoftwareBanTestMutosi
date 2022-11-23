using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.DAL
{
    public class DALLoiLoc
    {
        public static void Add(List<LoiLoc> list)
        {
            DataBaseContext dbContext = new DataBaseContext();
            TestLoiLoc testID = new TestLoiLoc();

            dbContext.TestLoiLocs.Add(testID);
            dbContext.SaveChanges();

            foreach(var i in list)
            {
                if (i != null)
                {
                    i.TestLoiLocID = testID.TestLoiLocID;
                }
            }
            dbContext.LoiLocs.AddRange(list);
            dbContext.SaveChanges();
        }
    }
}
