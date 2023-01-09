using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.DAL.DALPagination
{
    public class PaginationNguon
    {
        public static int NumberRows { get; set; } = 1;
        public int PageCurrent { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
        public int TotalResults { get; set; } = 0;
        public List<Models.NguonModel.TestNguon> ListResults = new List<Models.NguonModel.TestNguon>();
        public void Set(int page, DateTime? start, DateTime? end)
        {
            DataBaseContext dbContext = new DataBaseContext();

            int position = (page - 1) * NumberRows;

            if (start != null && end != null)
            {
                ListResults = dbContext.TestNguons.OrderByDescending(t => t.TestNguonID)
                .Where(a => start <= a.CreateAt && end >= a.CreateAt)
                .Skip(position)
                .Take(NumberRows)
                .ToList();

                this.TotalResults = dbContext.TestNguons.Where(a => start <= a.CreateAt && end >= a.CreateAt).Count();

            }
            else
            {
                ListResults = dbContext.TestNguons.OrderByDescending(t => t.TestNguonID)
                .Skip(position)
                .Take(NumberRows)
                .ToList();
                this.TotalResults = dbContext.TestNguons.Count();
            }

            this.PageCurrent = page;
            this.TotalPages = TotalResults % NumberRows == 0 ? TotalResults / NumberRows : (TotalResults / NumberRows) + 1;

        }
    }
}
