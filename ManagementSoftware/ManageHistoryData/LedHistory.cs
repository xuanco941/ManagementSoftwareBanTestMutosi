using ManagementSoftware.Models.LedModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.ManageHistoryData
{
    public class LedHistory
    {
        private List<Led>? lastValue = null;

        public List<Led>? Check(List<Led>? value)
        {

            if (lastValue != null && value != null)
            {
                List<Led> result = new List<Led>();
                foreach (var item in lastValue)
                {
                    foreach (var jtem in value)
                    {
                        if (item.LedName == jtem.LedName && item.LanTestThu != jtem.LanTestThu && item.isOn == true )
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
