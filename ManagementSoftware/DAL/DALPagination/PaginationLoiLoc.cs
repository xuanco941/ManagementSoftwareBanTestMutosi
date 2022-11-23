using ManagementSoftware.Models;
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
        public static int NumberRows { get; set; } = Common.NumberRows;
        public int PageCurrent { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
        public int TotalResults { get; set; } = 0;
        public Dictionary<TestLoiLoc, List<LoiLoc>> ListResults { get; set; } = new Dictionary<TestLoiLoc, List<LoiLoc>>();
        public void Set(int page, DateTime? start, DateTime? end)
        {
            DataBaseContext dbContext = new DataBaseContext();

            int position = (page - 1) * NumberRows;

            List<TestLoiLoc> listTest = new List<TestLoiLoc>();
            if (start != null && end != null)
            {
                listTest = dbContext.TestLoiLocs
                .Where(a => start <= a.CreateAt && end >= a.CreateAt)
                .Skip(position)
                .Take(NumberRows)
                .OrderByDescending(t => t.TestLoiLocID)
                .ToList();

                this.TotalResults = dbContext.TestLoiLocs.Where(a => start <= a.CreateAt && end >= a.CreateAt).Count();

            }
            else
            {
                listTest = dbContext.TestLoiLocs
                .Skip(position)
                .Take(NumberRows)
                .OrderByDescending(t => t.TestLoiLocID)
                .ToList();
                this.TotalResults = dbContext.TestLoiLocs.Count();
            }

            foreach(TestLoiLoc elm in listTest)
            {
                List<LoiLoc> l = new List<LoiLoc>();
                l = dbContext.LoiLocs.Where(e => e.TestLoiLocID == elm.TestLoiLocID).ToList();
                ListResults.Add(elm, l);
            }

            this.PageCurrent = page;
            this.TotalPages = TotalResults % NumberRows == 0 ? TotalResults / NumberRows : (TotalResults / NumberRows) + 1;

        }
    }
}
