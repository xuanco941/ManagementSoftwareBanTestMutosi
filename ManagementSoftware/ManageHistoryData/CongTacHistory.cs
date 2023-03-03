using ManagementSoftware.Models.CongTacModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.ManageHistoryData
{
    public class CongTacHistory
    {
        private List<CongTac>? lastValue = null;

        public List<CongTac>? Check(List<CongTac>? value)
        {

            if (lastValue != null && value != null)
            {
                List< CongTac> result = new List<CongTac>();
                foreach (var item in lastValue)
                {
                    foreach (var jtem in value)
                    {
                        if (item.CongTacName == jtem.CongTacName && Math.Abs(item.LanTestThu - jtem.LanTestThu) >= 5 )
                        {
                            result.Add(item);
                        }
                    }
                }
                if (result.Count > 0)
                {
                    lastValue = value;
                    return result;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                lastValue = value;
                return null;
            }

        }
    }
}
