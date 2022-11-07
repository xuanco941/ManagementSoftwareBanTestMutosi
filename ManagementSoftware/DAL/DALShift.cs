using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.DAL
{
    internal class DALShift
    {
        public static List<Shift>? GetAllShifts()
        {
            DataBaseContext dbContext = new DataBaseContext();
            List<Shift>? list = (from s in dbContext.Shifts select s).ToList();
            return list;
        }


        public static Shift? GetShiftFromID(int id)
        {
            DataBaseContext dbContext = new DataBaseContext();
            Shift? shift = (from s in dbContext.Shifts where s.ShiftID == id select s).FirstOrDefault();
            return shift;
        }

        // Them ca làm
        public static int Add(Shift shift)
        {
            DataBaseContext dbContext = new DataBaseContext();
            dbContext.Shifts.Add(shift);
            return dbContext.SaveChanges();
        }

        // Sua ca làm
        public static int Update(Shift shift)
        {
            DataBaseContext dbContext = new DataBaseContext();
            var shiftUpdate = dbContext.Shifts.FirstOrDefault(s => s.ShiftID == shift.ShiftID);
            if (shiftUpdate != null)
            {
                shiftUpdate.ShiftName = shift.ShiftName;
                shiftUpdate.TimeStart = shift.TimeStart;
                shiftUpdate.TimeEnd = shift.TimeEnd;
            }
            return dbContext.SaveChanges();
        }

        public static int Delete(int id)
        {
            DataBaseContext dbContext = new DataBaseContext();
            var shiftDelete = dbContext.Shifts.FirstOrDefault(s => s.ShiftID == id);
            if (shiftDelete != null)
            {
                dbContext.Shifts.Remove(shiftDelete);
            }
            return dbContext.SaveChanges();
        }

    }
}
