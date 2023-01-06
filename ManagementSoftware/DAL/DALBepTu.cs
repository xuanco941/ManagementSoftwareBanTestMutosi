using ManagementSoftware.Models;
using ManagementSoftware.Models.BepTuModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.DAL
{
    public class DALBepTu
    {
        public static void Add(List<BepTu> list)
        {
            DataBaseContext dbContext = new DataBaseContext();
            TestBepTu testID = new TestBepTu();

            dbContext.TestBepTus.Add(testID);
            dbContext.SaveChanges();

            foreach (var i in list)
            {
                if (i != null)
                {
                    i.TestBepTuID = testID.TestBepTuID;
                }
            }
            dbContext.BepTus.AddRange(list.ToList());
            dbContext.SaveChanges();
        }
    }
}
