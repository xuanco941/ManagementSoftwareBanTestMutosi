using ManagementSoftware.Models;
using ManagementSoftware.Models.BauNongModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.DAL.DALPagination
{
    public class PaginationBauNong
    {
        public static int NumberRows { get; set; } = 50;
        public int PageCurrent { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
        public int TotalResults { get; set; } = 0;
        public List<TestBauNong> ListResults { get; set; } = new List<TestBauNong>();
        public void Set(int page, DateTime? start, DateTime? end)
        {
            DataBaseContext dbContext = new DataBaseContext();

            int position = (page - 1) * NumberRows;

            if (start != null && end != null)
            {
                ListResults = dbContext.TestBauNongs.OrderByDescending(t => t.TestBauNongID)
                .Where(a => start <= a.CreateAt && end >= a.CreateAt)
                .Skip(position)
                .Take(NumberRows)
                .ToList();

                this.TotalResults = dbContext.TestBauNongs.Where(a => start <= a.CreateAt && end >= a.CreateAt).Count();

            }
            else
            {
                ListResults = dbContext.TestBauNongs.OrderByDescending(t => t.TestBauNongID)
                .Skip(position)
                .Take(NumberRows)
                .ToList();
                this.TotalResults = dbContext.TestBauNongs.Count();
            }


            this.PageCurrent = page;
            this.TotalPages = TotalResults % NumberRows == 0 ? TotalResults / NumberRows : (TotalResults / NumberRows) + 1;

        }
    }
}
