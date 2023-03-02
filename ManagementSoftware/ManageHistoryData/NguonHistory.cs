using ManagementSoftware.Models.NguonModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.ManageHistoryData
{
    public class NguonHistory
    {
        private List<Nguon>? lastValue = null;

        public List<Nguon>? Check(List<Nguon>? value)
        {

            if (lastValue != null && value != null)
            {
                List<Nguon> result = new List<Nguon>();
                foreach (var item in lastValue)
                {
                    foreach (var jtem in value)
                    {
                        if (item.NguonName == jtem.NguonName && item.LanTestThu != jtem.LanTestThu && item.isOn == true)
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
                    lastValue = value;
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
