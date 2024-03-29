﻿using ManagementSoftware.Models;
using ManagementSoftware.Models.CongTacModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.DAL
{
    public class DALCongTac
    {
        public void Add(List<CongTac> list)
        {
            DataBaseContext dbContext = new DataBaseContext();
            TestCongTac testID = new TestCongTac();

            dbContext.TestCongTacs.Add(testID);
            dbContext.SaveChanges();

            foreach (var i in list)
            {
                if (i != null)
                {
                    i.TestCongTacID = testID.TestCongTacID;
                }
            }
            dbContext.CongTacs.AddRange(list);
            dbContext.SaveChanges();
        }
        public List<CongTac>? GetDataFromIDTest(int id)
        {
            DataBaseContext dbContext = new DataBaseContext();

            return dbContext.CongTacs.Where(a => a.TestCongTacID == id).ToList();

        }
    }
}
