using ManagementSoftware.Models.NguonModel;
using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagementSoftware.Models.LedModel;

namespace ManagementSoftware.DAL
{
    public class DALLed
    {
        public static void Add(List<Led> list)
        {
            DataBaseContext dbContext = new DataBaseContext();
            TestLed testID = new TestLed();

            dbContext.TestLeds.Add(testID);
            dbContext.SaveChanges();

            foreach (var i in list)
            {
                if (i != null)
                {
                    i.TestLedID = testID.TestLedID;
                }
            }
            dbContext.Leds.AddRange(list.ToList());
            dbContext.SaveChanges();
        }

        public static List<Led>? GetDataFromIDTest(int id)
        {
            DataBaseContext dbContext = new DataBaseContext();

            return dbContext.Leds.Where(a => a.TestLedID == id).ToList();

        }
    }
}
