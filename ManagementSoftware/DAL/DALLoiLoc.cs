using ManagementSoftware.Models;
using ManagementSoftware.Models.LoiLocModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.DAL
{
    public class DALLoiLoc
    {
        public static void Add(LoiLoc loiloc)
        {
            DataBaseContext dbContext = new DataBaseContext();
            TestLoiLoc testID = new TestLoiLoc();

            dbContext.TestLoiLocs.Add(testID);
            dbContext.SaveChanges();


            if (loiloc != null)
            {
                loiloc.TestLoiLocID = testID.TestLoiLocID;
                dbContext.LoiLocs.Add(loiloc);
                dbContext.SaveChanges();
            }

        }
    }
}
