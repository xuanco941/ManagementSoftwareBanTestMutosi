using ManagementSoftware.Models;
using ManagementSoftware.Models.LoiLocModel;
using ManagementSoftware.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.DAL.DALPagination
{
    public class PaginationLoiLoc
    {
        public static int NumberRows { get; set; } = 30;
        public int PageCurrent { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
        public int TotalResults { get; set; } = 0;
        public List<LoiLoc> ListResults { get; set; } = new List<LoiLoc>();
        public void Set(int page, DateTime? start, DateTime? end)
        {
            using var dbContext = new DataBaseContext();
            int position = (page - 1) * NumberRows;
            IQueryable<LoiLoc> query = dbContext.LoiLocs.OrderByDescending(t => t.LoiLocID);

            if (start.HasValue && end.HasValue)
            {
                end = end.Value.AddDays(1);
                query = query.Where(a => start <= a.CreateAt && end >= a.CreateAt);
            }

            this.ListResults = query
                .Skip(position)
                .Take(NumberRows)
                .ToList();

            this.TotalResults = query.Count();
            this.PageCurrent = page;
            this.TotalPages = TotalResults % NumberRows == 0 ? TotalResults / NumberRows : (TotalResults / NumberRows) + 1;
        }
    }
}
