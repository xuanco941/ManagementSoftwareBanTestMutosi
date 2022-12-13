﻿using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.DAL
{
    public class DALNguon
    {
        public static void Add(List<Nguon> list)
        {
            DataBaseContext dbContext = new DataBaseContext();
            TestNguon testID = new TestNguon();

            dbContext.TestNguons.Add(testID);
            dbContext.SaveChanges();

            foreach (var i in list)
            {
                if (i != null)
                {
                    i.TestNguonID = testID.TestNguonID;
                }
            }
            dbContext.Nguons.AddRange(list.ToList());
            dbContext.SaveChanges();
        }
    }
}
