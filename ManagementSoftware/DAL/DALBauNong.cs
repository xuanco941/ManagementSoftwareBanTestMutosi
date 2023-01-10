using ManagementSoftware.Models;
using ManagementSoftware.Models.BauNongModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.DAL
{
    public class DALBauNong
    {
        public void Add(List<BauNong> list)
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
        public List<BauNong>? GetDataFromIDTest(int id)
        {
            DataBaseContext dbContext = new DataBaseContext();

            return dbContext.BauNongs.Where(a => a.TestBauNongID == id).ToList();

        }
    }
}
