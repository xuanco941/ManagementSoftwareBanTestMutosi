using ManagementSoftware.Models.LoiLocModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.ManageHistoryData
{
    public class LoiLocHistory
    {
        private const int MAX_HISTORY_SIZE = 100;
        private LoiLoc? lastLoiLoc = null;
        private List<LoiLoc> loiLocHistory = new List<LoiLoc>(MAX_HISTORY_SIZE);

        public LoiLoc? Check(LoiLoc ll)
        {
            if(lastLoiLoc!=null && ll != null)
            {
                if(lastLoiLoc.LoiLocName == ll.LoiLocName && lastLoiLoc.SoLanTest != ll.SoLanTest && lastLoiLoc.isOn == true)
                {
                    LoiLoc? loiLoc = lastLoiLoc;
                    lastLoiLoc = ll;
                    //AddToHistory(ll);
                    return loiLoc;
                }
                else
                {
                    lastLoiLoc = ll;
                    //AddToHistory(ll);
                    return null;
                }
            }
            else
            {
                lastLoiLoc = ll;
                return null;
            }
        }

        private void AddToHistory(LoiLoc ll)
        {
            if (loiLocHistory.Count >= MAX_HISTORY_SIZE)
            {
                loiLocHistory.RemoveAt(0);
            }
            loiLocHistory.Add(ll);
        }

        public LoiLoc? GetLastLoiLoc()
        {
            return lastLoiLoc;
        }

        public List<LoiLoc> GetLoiLocHistory()
        {
            return loiLocHistory;
        }
    }
}
