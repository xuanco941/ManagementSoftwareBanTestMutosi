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
        public static void Add(TestLoiLoc testLoiLoc ,LoiLoc loiLoc)
        {
            DataBaseContext dbContext = new DataBaseContext();

            dbContext.TestLoiLocs.Add(testLoiLoc);
            dbContext.SaveChanges();

            loiLoc.TestLoiLocID = testLoiLoc.TestLoiLocID;
            dbContext.LoiLocs.Add(loiLoc);
            dbContext.SaveChanges();
        }
    }
}
