using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.DAL.DALPagination
{
    public class PaginationCongTac3VT
    {
        public static int NumberRows { get; set; } = 15;
        public int PageCurrent { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
        public int TotalResults { get; set; } = 0;
        public Dictionary<TestCongTac3VT, List<CongTac3VT>> ListResults { get; set; } = new Dictionary<TestCongTac3VT, List<CongTac3VT>>();
        public void Set(int page, DateTime? start, DateTime? end)
        {
            DataBaseContext dbContext = new DataBaseContext();

            int position = (page - 1) * NumberRows;

            List<TestCongTac3VT> listTest = new List<TestCongTac3VT>();
            if (start != null && end != null)
            {
                listTest = dbContext.TestCongTac3VTs.OrderByDescending(t => t.TestCongTac3VTID)
                .Where(a => start <= a.CreateAt && end >= a.CreateAt)
                .Skip(position)
                .Take(NumberRows)
                .ToList();

                this.TotalResults = dbContext.TestCongTac3VTs.Where(a => start <= a.CreateAt && end >= a.CreateAt).Count();

            }
            else
            {
                listTest = dbContext.TestCongTac3VTs.OrderByDescending(t => t.TestCongTac3VTID)
                .Skip(position)
                .Take(NumberRows)
                .ToList();
                this.TotalResults = dbContext.TestCongTac3VTs.Count();
            }

            foreach (var elm in listTest)
            {
                List<CongTac3VT> l = new List<CongTac3VT>();
                l = dbContext.CongTac3VTs.Where(e => e.TestCongTac3VTID == elm.TestCongTac3VTID).ToList();
                ListResults.Add(elm, l);
            }

            this.PageCurrent = page;
            this.TotalPages = TotalResults % NumberRows == 0 ? TotalResults / NumberRows : (TotalResults / NumberRows) + 1;

        }
    }
}
