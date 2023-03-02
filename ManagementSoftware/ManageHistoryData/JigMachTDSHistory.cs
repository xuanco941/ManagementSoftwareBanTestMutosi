using ManagementSoftware.Models.JigMachModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.ManageHistoryData
{
    public class JigMachTDSHistory
    {
        private List<JigMachTDS>? lastValue = null;

        public List<JigMachTDS>? Check(List<JigMachTDS>? value)
        {

            if (lastValue != null && value != null)
            {
                List<JigMachTDS> result = new List<JigMachTDS>();
                foreach (var item in lastValue)
                {
                    foreach (var jtem in value)
                    {
                        if (item.JigMachTDSName == jtem.JigMachTDSName && item.LanTestThu != jtem.LanTestThu && item.isOn == true)
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
