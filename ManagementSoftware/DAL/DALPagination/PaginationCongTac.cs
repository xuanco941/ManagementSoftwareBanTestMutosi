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
        public Dictionary<Models.CongTacModel.TestCongTac, List<Models.CongTacModel.CongTac>> ListResults { get; set; } = new Dictionary<Models.CongTacModel.TestCongTac, List<Models.CongTacModel.CongTac>>();
        public void Set(int page, DateTime? start, DateTime? end)
        {
            DataBaseContext dbContext = new DataBaseContext();

            int position = (page - 1) * NumberRows;

            List< Models.CongTacModel.TestCongTac> listTest = new List<Models.CongTacModel.TestCongTac>();
            if (start != null && end != null)
            {
                listTest = dbContext.TestCongTacs.OrderByDescending(t => t.TestCongTacID)
                .Where(a => start <= a.CreateAt && end >= a.CreateAt)
                .Skip(position)
                .Take(NumberRows)
                .ToList();

                this.TotalResults = dbContext.TestCongTacs.Where(a => start <= a.CreateAt && end >= a.CreateAt).Count();

            }
            else
            {
                listTest = dbContext.TestCongTacs.OrderByDescending(t => t.TestCongTacID)
                .Skip(position)
                .Take(NumberRows)
                .ToList();
                this.TotalResults = dbContext.TestCongTacs.Count();
            }

            foreach (var elm in listTest)
            {
                List< Models.CongTacModel.CongTac> l = new List<Models.CongTacModel.CongTac>();
                l = dbContext.CongTacs.Where(e => e.TestCongTacID == elm.TestCongTacID).ToList();
                ListResults.Add(elm, l);
            }

            this.PageCurrent = page;
            this.TotalPages = TotalResults % NumberRows == 0 ? TotalResults / NumberRows : (TotalResults / NumberRows) + 1;

        }
    }
}
