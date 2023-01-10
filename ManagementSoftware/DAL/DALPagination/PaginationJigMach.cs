using ManagementSoftware.Models;
using ManagementSoftware.Models.JigMachModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.DAL.DALPagination
{

    public class PaginationJigMach
    {
        public static int NumberRows { get; set; } = 50;
        public int PageCurrent { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
        public int TotalResults { get; set; } = 0;
        public List<TestJigMach> ListResults { get; set; } = new List<TestJigMach>();
        public void Set(int page, DateTime? start, DateTime? end)
        {
            DataBaseContext dbContext = new DataBaseContext();

            int position = (page - 1) * NumberRows;

            if (start != null && end != null)
            {
                ListResults = dbContext.TestJigMachs.OrderByDescending(t => t.TestJigMachID)
                .Where(a => start <= a.CreateAt && end >= a.CreateAt)
                .Skip(position)
                .Take(NumberRows)
                .ToList();

                this.TotalResults = dbContext.TestJigMachs.Where(a => start <= a.CreateAt && end >= a.CreateAt).Count();

            }
            else
            {
                ListResults = dbContext.TestJigMachs.OrderByDescending(t => t.TestJigMachID)
                .Skip(position)
                .Take(NumberRows)
                .ToList();
                this.TotalResults = dbContext.TestJigMachs.Count();
            }


            this.PageCurrent = page;
            this.TotalPages = TotalResults % NumberRows == 0 ? TotalResults / NumberRows : (TotalResults / NumberRows) + 1;

        }
    }
}
