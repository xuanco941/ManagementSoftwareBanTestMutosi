using ManagementSoftware.Models;
using ManagementSoftware.ViewModels;

namespace ManagementSoftware.DAL.DALPagination
{
    public class PaginationUser
    {
        public static int NumberRows { get; set; } = Common.NumberRows;
        public int PageCurrent { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
        public int TotalResults { get; set; } = 0;
        public List<UserHasGroupName>? ListResults { get; set; }

        public void Set(int page)
        {
            DataBaseContext dbContext = new DataBaseContext();

            int position = (page - 1) * NumberRows;

            List<User> users = dbContext.Users.OrderByDescending(t => t.UserID)
            .Skip(position)
            .Take(NumberRows)
            .ToList();

            List<UserHasGroupName>? ListResults2 = new List<UserHasGroupName>();


            foreach (User item in users)
            {
                Group? grOfUser = DALGroup.GetGroupFromID(item.GroupID);
                string nameGr = grOfUser != null ? grOfUser.GroupName : "Lỗi(Not Found)";
                ListResults2.Add(new UserHasGroupName
                {
                    UserID = item.UserID,
                    FullName = item.FullName,
                    Username = item.Username,
                    Password = item.Password,
                    GroupName = nameGr
                });
            }
            this.ListResults = ListResults2;

            this.TotalResults = dbContext.Users.Count();

            this.PageCurrent = page;
            this.TotalPages = TotalResults % NumberRows == 0 ? TotalResults / NumberRows : (TotalResults / NumberRows) + 1;

        }
    }
}