using ManagementSoftware.Models.BauNongModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.ManageHistoryData
{
    public class BauNongHistory
    {
        private List<BauNong>? lastValue = null;

        public List<BauNong>? Check(List<BauNong>? value)
        {

            if(lastValue != null && value != null)
            {
                List<BauNong> result = new List<BauNong>();
                foreach (var item in lastValue)
                {
                    foreach (var jtem in value)
                    {
                        if(item.BauNongName == jtem.BauNongName && item.LanTestThu != jtem.LanTestThu && item.isOn == true)
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
