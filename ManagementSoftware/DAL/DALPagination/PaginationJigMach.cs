using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.DAL.DALPagination
{

    public class JigMachResponse
    {
        public List<JigMachNguon> JigMachNguons { get; set; }
        public List<JigMachTDS> JigMachTDs { get; set; }

    }

    public class PaginationJigMach
    {
        public static int NumberRows { get; set; } = 5;
        public int PageCurrent { get; set; } = 1;
        public int TotalPages { get; set; } = 1;
        public int TotalResults { get; set; } = 0;
        public Dictionary<TestJigMach, JigMachResponse> ListResults { get; set; } = new Dictionary<TestJigMach, JigMachResponse>();
        public void Set(int page, DateTime? start, DateTime? end)
        {
            DataBaseContext dbContext = new DataBaseContext();

            int position = (page - 1) * NumberRows;

            List<TestJigMach> listTest = new List<TestJigMach>();
            if (start != null && end != null)
            {
                listTest = dbContext.TestJigMachs.OrderByDescending(t => t.TestJigMachID)
                .Where(a => start <= a.CreateAt && end >= a.CreateAt)
                .Skip(position)
                .Take(NumberRows)
                .ToList();

                this.TotalResults = dbContext.TestJigMachs.Where(a => start <= a.CreateAt && end >= a.CreateAt).Count();

            }
            else
            {
                listTest = dbContext.TestJigMachs.OrderByDescending(t => t.TestJigMachID)
                .Skip(position)
                .Take(NumberRows)
                .ToList();
                this.TotalResults = dbContext.TestJigMachs.Count();
            }

            foreach (var elm in listTest)
            {
                List<JigMachNguon> l1 = new List<JigMachNguon>();
                l1 = dbContext.JigMachNguons.Where(e => e.TestJigMachID == elm.TestJigMachID).ToList();

                List<JigMachTDS> l2 = new List<JigMachTDS>();
                l2 = dbContext.JigMachTDSs.Where(e => e.TestJigMachID == elm.TestJigMachID).ToList();

                JigMachResponse response = new JigMachResponse();
                response.JigMachNguons = l1;
                response.JigMachTDs = l2;

                ListResults.Add(elm, response);
            }

            this.PageCurrent = page;
            this.TotalPages = TotalResults % NumberRows == 0 ? TotalResults / NumberRows : (TotalResults / NumberRows) + 1;

        }
    }
}
