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
        public Dictionary<Models.NguonModel.TestNguon, List<Models.NguonModel.Nguon>> ListResults { get; set; } = new Dictionary<Models.NguonModel.TestNguon, List<Models.NguonModel.Nguon>>();
        public void Set(int page, DateTime? start, DateTime? end)
        {
            DataBaseContext dbContext = new DataBaseContext();

            int position = (page - 1) * NumberRows;

            List<Models.NguonModel.TestNguon> listTest = new List<Models.NguonModel.TestNguon>();
            if (start != null && end != null)
            {
                listTest = dbContext.TestNguons.OrderByDescending(t => t.TestNguonID)
                .Where(a => start <= a.CreateAt && end >= a.CreateAt)
                .Skip(position)
                .Take(NumberRows)
                .ToList();

                this.TotalResults = dbContext.TestNguons.Where(a => start <= a.CreateAt && end >= a.CreateAt).Count();

            }
            else
            {
                listTest = dbContext.TestNguons.OrderByDescending(t => t.TestNguonID)
                .Skip(position)
                .Take(NumberRows)
                .ToList();
                this.TotalResults = dbContext.TestNguons.Count();
            }

            foreach (var elm in listTest)
            {
                List<Models.NguonModel.Nguon> l = new List<Models.NguonModel.Nguon>();
                l = dbContext.Nguons.Where(e => e.TestNguonID == elm.TestNguonID).ToList();
                ListResults.Add(elm, l);
            }

            this.PageCurrent = page;
            this.TotalPages = TotalResults % NumberRows == 0 ? TotalResults / NumberRows : (TotalResults / NumberRows) + 1;

        }
    }
}
