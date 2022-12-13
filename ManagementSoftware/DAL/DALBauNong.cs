using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.DAL
{
    public class DALBauNong
    {
        public static void Add(List<BauNong> list)
        {
            DataBaseContext dbContext = new DataBaseContext();
            TestBauNong testID = new TestBauNong();

            dbContext.TestBauNongs.Add(testID);
            dbContext.SaveChanges();

            foreach (var i in list)
            {
                if (i != null)
                {
                    i.TestBauNongID = testID.TestBauNongID;
                }
            }
            dbContext.BauNongs.AddRange(list.ToList());
            dbContext.SaveChanges();
        }
    }
}
