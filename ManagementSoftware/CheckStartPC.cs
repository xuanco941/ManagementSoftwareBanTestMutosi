using ActUtlTypeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware
{
    public class CheckStartPC
    {
        public ActUtlType plc;

        public CheckStartPC()
        {
            plc = new ActUtlType();
            plc.ActLogicalStationNumber = 1;
        }

        public async Task<int> Open()
        {
            Func<int> func = () =>
            {
                return plc.Open(); //0 = true
            };
            Task<int> task = new Task<int>(func);
            task.Start();
            await task;

            return task.Result;
        }

        public async Task<int> Close()
        {
            Func<int> func = () =>
            {
                return plc.Close();
            };
            Task<int> task = new Task<int>(func);
            task.Start();
            await task;

            return task.Result;
        }

        //truy van du lieu 1 o nho
        public async Task<int?> Query(string addr)
        {
            Func<int?> func = () =>
            {
                try
                {
                    int value;
                    int status = plc.GetDevice(addr, out value);
                    if (status == 0) //0 = true
                    {
                        return value;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch
                {
                    return null;
                }

            };
            Task<int?> task = new Task<int?>(func);
            task.Start();
            await task;

            return task.Result;
        }


        public bool Start()
        {
            try
            {
                plc.Open();
                int x = plc.SetDevice("M1", 1);
                if (x == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }


        public bool Stop()
        {
            try
            {
                int x = plc.SetDevice("M1", 0);
                if (x == 0)
                {
                    plc.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


    }
}
