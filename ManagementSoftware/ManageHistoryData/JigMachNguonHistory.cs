using ManagementSoftware.Models.JigMachModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.ManageHistoryData
{
    public class JigMachNguonHistory
    {
        private List<JigMachNguon>? lastValue = null;

        public List<JigMachNguon>? Check(List<JigMachNguon>? value)
        {

            if (lastValue != null && value != null)
            {
                List<JigMachNguon> result = new List<JigMachNguon>();
                foreach (var item in lastValue)
                {
                    foreach (var jtem in value)
                    {
                        if (item.JigMachNguonName == jtem.JigMachNguonName && item.LanTestThu != jtem.LanTestThu && item.isOn == true)
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
