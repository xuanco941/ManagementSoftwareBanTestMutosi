using ManagementSoftware.Models;

namespace ManagementSoftware.DAL
{
    public class DALGroup
    {

        public static List<Group>? GetAllGroups()
        {
            DataBaseContext dbContext = new DataBaseContext();
            List<Group>? list = (from gr in dbContext.Groups select gr).ToList();
            return list;
        }


        public static Group? GetGroupFromID(int id)
        {
            DataBaseContext dbContext = new DataBaseContext();
            Group? group = (from gr in dbContext.Groups where gr.GroupID == id select gr).FirstOrDefault();
            return group;
        }
        //Tìm kiếm group bằng tên
        public static List<Group> FindGroupByGroupName(string groupName)
        {
            DataBaseContext dbContext = new DataBaseContext();
            var list = (from gr in dbContext.Groups where (gr.GroupName != null && gr.GroupName.Contains(groupName) == true) select gr).ToList();
            return list;
        }

        // Them nhóm quyền
        public static int AddGroup(Group group)
        {
            DataBaseContext dbContext = new DataBaseContext();
            dbContext.Groups.Add(group);
            return dbContext.SaveChanges();
        }

        // Sua group
        public static int UpdateGroup(Group group)
        {
            DataBaseContext dbContext = new DataBaseContext();
            var groupUpdate = dbContext.Groups.FirstOrDefault(g => g.GroupName == group.GroupName);
            if (groupUpdate != null)
            {
                groupUpdate.GroupName = group.GroupName;
                groupUpdate.IsManagementUser = group.IsManagementUser;
                groupUpdate.IsManagementGroup = group.IsManagementGroup;
            }
            return dbContext.SaveChanges();
        }

        public static int DeleteGroup(string grName)
        {
            DataBaseContext dbContext = new DataBaseContext();
            var groupDelete = dbContext.Groups.FirstOrDefault(g => g.GroupName == grName);
            if (groupDelete != null)
            {
                dbContext.Groups.Remove(groupDelete);
            }
            return dbContext.SaveChanges();
        }

        public static Group? GetGroupFromGroupName(string groupName)
        {
            DataBaseContext dbContext = new DataBaseContext();
            return dbContext.Groups.Where(u => u.GroupName == groupName).FirstOrDefault();
        }

        public static List<string>? GetListGroupName()
        {
            DataBaseContext dbContext = new DataBaseContext();
            return dbContext.Groups.Select(u => u.GroupName).ToList();
        }
        public static Group? GetGroupFromUserID(int? UserID)
        {
            Group? group = null;
            if (UserID != null)
            {
                DataBaseContext dbContext = new DataBaseContext();
                int? groupid = (from u in dbContext.Users where u.UserID == UserID select u.GroupID).FirstOrDefault();
                if (groupid != null)
                {
                    group = (from gr in dbContext.Groups
                             where gr.GroupID == groupid
                             select gr).FirstOrDefault();
                }
            }
            return group;
        }

        public static int ConvertGroupNameToGroupID(string grName)
        {
            DataBaseContext context = new DataBaseContext();
            return (from gr in context.Groups where gr.GroupName.Trim().ToLower() == grName.Trim().ToLower() select gr.GroupID).FirstOrDefault();
        }

    }
}
