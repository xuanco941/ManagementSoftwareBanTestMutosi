using ManagementSoftware.Models;

namespace ManagementSoftware.DAL
{
    public class DALActivity
    {

        public static List<Activity>? GetAllActivities()
        {
            DataBaseContext dbContext = new DataBaseContext();
            List<Activity>? list = (from a in dbContext.Activities select a).OrderByDescending(e => e.ActivityID).ToList();
            return list;
        }

        // Them Activity
        public static int AddActivity(Activity activity)
        {
            DataBaseContext dbContext = new DataBaseContext();
            dbContext.Activities.Add(activity);
            return dbContext.SaveChanges();
        }

        // xóa nhiều activity
        public static int DeleteActivities(List<Activity> activities)
        {
            DataBaseContext dbContext = new DataBaseContext();
            if (activities.Count > 0)
            {
                dbContext.Activities.RemoveRange(activities);
            }
            return dbContext.SaveChanges();
        }

        public static Activity? GetActivityFromID(int activityID)
        {
            DataBaseContext dbContext = new DataBaseContext();
            return dbContext.Activities.Where(a => a.ActivityID == activityID).FirstOrDefault();
        }

        public static List<string>? GetListActivityHasDistinctUsername()
        {
            DataBaseContext dbContext = new DataBaseContext();
            List<string>? list = new List<string>();
            list = dbContext.Activities.Select(a => a.Username).Distinct().ToList();
            return list;
        }

    }
}
