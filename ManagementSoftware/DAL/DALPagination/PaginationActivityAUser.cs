using ManagementSoftware.Models;

namespace ManagementSoftware.DAL.DALPagination
{
    public class PaginationActivityAUser
    {
        public static int NumberRows { get; set; } = Common.NumberRows;
        public int PageCurrent { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
        public int TotalResults { get; set; } = 0;
        public List<Activity>? ListResults { get; set; }

        public void Set(int page, DateTime? start, DateTime? end, string username)
        {
            DataBaseContext dbContext = new DataBaseContext();

            int position = (page - 1) * NumberRows;

            if (start == null && end == null)
            {
                this.ListResults = dbContext.Activities.OrderByDescending(t => t.ActivityID)
                .Where(a => a.Username == username)
                .Skip(position)
                .Take(NumberRows)
                .ToList();
                this.TotalResults = dbContext.Activities.Count();
            }
            else
            {
                this.ListResults = dbContext.Activities.OrderByDescending(t => t.ActivityID)
                .Where(a => (start <= a.CreateAt && end >= a.CreateAt) && (a.Username == username))
                .Skip(position)
                .Take(NumberRows)
                .ToList();

                this.TotalResults = dbContext.Activities.Where(a => start <= a.CreateAt && end >= a.CreateAt).Count();
            }

            this.PageCurrent = page;
            this.TotalPages = TotalResults % NumberRows == 0 ? TotalResults / NumberRows : (TotalResults / NumberRows) + 1;

        }
    }
}
