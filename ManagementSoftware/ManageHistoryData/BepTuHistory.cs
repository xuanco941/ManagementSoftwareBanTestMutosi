using ManagementSoftware.Models.BepTuModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.ManageHistoryData
{
    public class BepTuHistory
    {
        private List<BepTu>? lastValue = null;

        public List<BepTu>? Check(List<BepTu>? value)
        {

            if (lastValue != null && value != null)
            {
                List<BepTu> result = new List<BepTu>();
                foreach (var item in lastValue)
                {
                    foreach (var jtem in value)
                    {
                        if (item.BepTuName == jtem.BepTuName && item.LanTestThu != jtem.LanTestThu && item.isOn == true)
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
