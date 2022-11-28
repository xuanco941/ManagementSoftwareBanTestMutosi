using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.DAL.DALPagination
{
    public class PaginationCongTac2VT
    {
        public static int NumberRows { get; set; } = 2;
        public int PageCurrent { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
        public int TotalResults { get; set; } = 0;
        public Dictionary<TestCongTac2VT, List<CongTac2VT>> ListResults { get; set; } = new Dictionary<TestCongTac2VT, List<CongTac2VT>>();
        public void Set(int page, DateTime? start, DateTime? end)
        {
            DataBaseContext dbContext = new DataBaseContext();

            int position = (page - 1) * NumberRows;

            List<TestCongTac2VT> listTest = new List<TestCongTac2VT>();
            if (start != null && end != null)
            {
                listTest = dbContext.TestCongTac2VTs.OrderByDescending(t => t.TestCongTac2VTID)
                .Where(a => start <= a.CreateAt && end >= a.CreateAt)
                .Skip(position)
                .Take(NumberRows)
                .ToList();

                this.TotalResults = dbContext.TestCongTac2VTs.Where(a => start <= a.CreateAt && end >= a.CreateAt).Count();

            }
            else
            {
                listTest = dbContext.TestCongTac2VTs.OrderByDescending(t => t.TestCongTac2VTID)
                .Skip(position)
                .Take(NumberRows)
                .ToList();
                this.TotalResults = dbContext.TestCongTac2VTs.Count();
            }

            foreach (var elm in listTest)
            {
                List<CongTac2VT> l = new List<CongTac2VT>();
                l = dbContext.CongTac2VTs.Where(e => e.TestCongTac2VTID == elm.TestCongTac2VTID).ToList();
                ListResults.Add(elm, l);
            }

            this.PageCurrent = page;
            this.TotalPages = TotalResults % NumberRows == 0 ? TotalResults / NumberRows : (TotalResults / NumberRows) + 1;

        }
    }
}
