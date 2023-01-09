using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.DAL.DALPagination
{
    public class PaginationCongTac
    {
        public static int NumberRows { get; set; } = 2;
        public int PageCurrent { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
        public int TotalResults { get; set; } = 0;
        public List<Models.CongTacModel.TestCongTac> ListResults { get; set; } = new List<Models.CongTacModel.TestCongTac>();
        public void Set(int page, DateTime? start, DateTime? end)
        {
            DataBaseContext dbContext = new DataBaseContext();

            int position = (page - 1) * NumberRows;

            if (start != null && end != null)
            {
                ListResults = dbContext.TestCongTacs.OrderByDescending(t => t.TestCongTacID)
                .Where(a => start <= a.CreateAt && end >= a.CreateAt)
                .Skip(position)
                .Take(NumberRows)
                .ToList();

                this.TotalResults = dbContext.TestCongTacs.Where(a => start <= a.CreateAt && end >= a.CreateAt).Count();

            }
            else
            {
                ListResults = dbContext.TestCongTacs.OrderByDescending(t => t.TestCongTacID)
                .Skip(position)
                .Take(NumberRows)
                .ToList();
                this.TotalResults = dbContext.TestCongTacs.Count();
            }

            this.PageCurrent = page;
            this.TotalPages = TotalResults % NumberRows == 0 ? TotalResults / NumberRows : (TotalResults / NumberRows) + 1;

        }
    }
}
