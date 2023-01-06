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
        public static int NumberRows { get; set; } = 10;
        public int PageCurrent { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
        public int TotalResults { get; set; } = 0;
        public Dictionary<TestBauNong, List<BauNong>> ListResults { get; set; } = new Dictionary<TestBauNong, List<BauNong>>();
        public void Set(int page, DateTime? start, DateTime? end)
        {
            DataBaseContext dbContext = new DataBaseContext();

            int position = (page - 1) * NumberRows;

            List<TestBauNong> listTest = new List<TestBauNong>();
            if (start != null && end != null)
            {
                listTest = dbContext.TestBauNongs.OrderByDescending(t => t.TestBauNongID)
                .Where(a => start <= a.CreateAt && end >= a.CreateAt)
                .Skip(position)
                .Take(NumberRows)
                .ToList();

                this.TotalResults = dbContext.TestBauNongs.Where(a => start <= a.CreateAt && end >= a.CreateAt).Count();

            }
            else
            {
                listTest = dbContext.TestBauNongs.OrderByDescending(t => t.TestBauNongID)
                .Skip(position)
                .Take(NumberRows)
                .ToList();
                this.TotalResults = dbContext.TestBauNongs.Count();
            }

            foreach (var elm in listTest)
            {
                List<BauNong> l = new List<BauNong>();
                l = dbContext.BauNongs.Where(e => e.TestBauNongID == elm.TestBauNongID).ToList();
                ListResults.Add(elm, l);
            }

            this.PageCurrent = page;
            this.TotalPages = TotalResults % NumberRows == 0 ? TotalResults / NumberRows : (TotalResults / NumberRows) + 1;

        }
    }
}
