using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.DAL.DALPagination
{
    public class PaginationBepTu
    {
        public static int NumberRows { get; set; } = 20;
        public int PageCurrent { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
        public int TotalResults { get; set; } = 0;
        public Dictionary<TestBepTu, List<BepTu>> ListResults { get; set; } = new Dictionary<TestBepTu, List<BepTu>>();
        public void Set(int page, DateTime? start, DateTime? end)
        {
            DataBaseContext dbContext = new DataBaseContext();

            int position = (page - 1) * NumberRows;

            List<TestBepTu> listTest = new List<TestBepTu>();
            if (start != null && end != null)
            {
                listTest = dbContext.TestBepTus.OrderByDescending(t => t.TestBepTuID)
                .Where(a => start <= a.CreateAt && end >= a.CreateAt)
                .Skip(position)
                .Take(NumberRows)
                .ToList();

                this.TotalResults = dbContext.TestBepTus.Where(a => start <= a.CreateAt && end >= a.CreateAt).Count();

            }
            else
            {
                listTest = dbContext.TestBepTus.OrderByDescending(t => t.TestBepTuID)
                .Skip(position)
                .Take(NumberRows)
                .ToList();
                this.TotalResults = dbContext.TestBepTus.Count();
            }

            foreach (var elm in listTest)
            {
                List<BepTu> l = new List<BepTu>();
                l = dbContext.BepTus.Where(e => e.TestBepTuID == elm.TestBepTuID).ToList();
                ListResults.Add(elm, l);
            }

            this.PageCurrent = page;
            this.TotalPages = TotalResults % NumberRows == 0 ? TotalResults / NumberRows : (TotalResults / NumberRows) + 1;

        }
    }
}
