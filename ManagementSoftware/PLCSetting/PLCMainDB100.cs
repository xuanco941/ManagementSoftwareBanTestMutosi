using S7.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.PLCSetting
{
    public class PLCMainDB100
    {
        string db = "DB100.";

        public Plc plc { get; set; }
        public string plcName { get; set; }
        public PLCMainDB100(string ip, string name)
        {
            plcName = name;
            S7.Net.CpuType cpu = CpuType.S71200;
            short rack = 0;
            short slot = 1;
            plc = new Plc(cpu, ip, rack, slot);
        }



        public async Task<bool> Open()
        {

            Func<bool> func = () =>
            {
                try
                {
                    plc.Open();
                    return plc.IsConnected;
                }
                catch
                {
                    return false;
                }
            };
            Task<bool> task = new Task<bool>(func);
            task.Start();
            await task;

            return task.Result;

        }


        public async Task<bool> Close()
        {

            Func<bool> func = () =>
            {
                try
                {
                    plc.Close();
                    return plc.IsConnected;
                }
                catch
                {
                    return false;
                }

            };
            Task<bool> task = new Task<bool>(func);
            task.Start();
            await task;

            return task.Result;

        }


        public async Task<ushort> ConvertUIntToUshort(double diaChi)
        {
            if (plc.IsConnected)
            {
                Func<ushort> func = () =>
                {
                    try
                    {
                        object? data = plc.Read(db + "DBW" + diaChi);
                        if (data != null)
                        {
                            return (ushort)data;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    catch
                    {
                        return 0;
                    }
                    
                };
                Task<ushort> task = new Task<ushort>(func);
                task.Start();
                await task;

                return task.Result;
            }
            else
            {
                return 0;
            }
        }




        public async Task<uint> ConvertUDIntToUInt(double diaChi)
        {
            if (plc.IsConnected)
            {
                Func<uint> func = () =>
                {
                    try
                    {
                        object? data = plc.Read(db + "DBD" + diaChi);
                        if (data != null)
                        {
                            return (uint)data;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    catch
                    {
                        return 0;
                    }
                    
                };
                Task<uint> task = new Task<uint>(func);
                task.Start();
                await task;

                return task.Result;
            }
            else
            {
                return 0;
            }
        }




        public async Task<double> ConvertRealToDouble(double diaChi)
        {
            if (plc.IsConnected)
            {
                Func<double> func = () =>
                {
                    try
                    {
                        object? data = plc.Read(db + "DBD" + diaChi);
                        if (data != null)
                        {
                            return Math.Round(Conversion.ConvertToFloat((uint)data), 2, MidpointRounding.AwayFromZero);
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    catch
                    {
                        return 0;
                    }
                   
                };
                Task<double> task = new Task<double>(func);
                task.Start();
                await task;

                return task.Result;
            }
            else
            {
                return 0;
            }
        }





    }
}
