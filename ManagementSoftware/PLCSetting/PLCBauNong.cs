using ManagementSoftware.DAL;
using ManagementSoftware.Models.BauNongModel;
using S7.Net;
using Syncfusion.XPS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.PLCSetting
{
    public class PLCBauNong : PLCMainDB100
    {
        public PLCBauNong(string ip, string plcName) : base(ip, plcName)
        {

        }

        public async Task<List<BauNong>> GetAllData()
        {
            List<BauNong> listBauNong = new List<BauNong>();

            int dongDienAC = 0;
            int nhietDoPC = 40;
            int SoLanTest_ST_PC = 60;
            int nhietdongatcb = 100;

            int cbNhiet = 120;
            int errCbNhietCao = 140;
            int errCbNhietThap = 160;
            int errCbCangDot = 180;





            for (int i = 0; i <= 9; i++)
            {
                BauNong obj = new BauNong();
                obj.DongDien = await this.ConvertRealToDouble(dongDienAC);
                obj.NhietDo = Math.Round(Convert.ToDouble(await this.ConvertUIntToUshort(nhietDoPC)) / 10, 2, MidpointRounding.AwayFromZero);
                obj.LanTestThu = await this.ConvertUIntToUshort(SoLanTest_ST_PC);
                obj.NhietDoNgatCBNhiet = await this.ConvertUIntToUshort(nhietdongatcb);
                obj.TrangThaiCBNhiet = await this.ConvertUIntToUshort(cbNhiet) == 0 ? false : true;
                obj.Error_CB_Nhiet_Cao = await this.ConvertUIntToUshort(errCbNhietCao) == 0 ? false : true;
                obj.Error_CB_Nhiet_Thap = await this.ConvertUIntToUshort(errCbNhietThap) == 0 ? false : true;
                obj.Error_CB_Cang_Dot = await this.ConvertUIntToUshort(errCbCangDot) == 0 ? false : true;



                if(obj.Error_CB_Nhiet_Cao==false && obj.Error_CB_Nhiet_Thap == false && obj.Error_CB_Cang_Dot == false)
                {
                    obj.Error = Common.NOT_ERROR_STR;
                }
                else
                {
                    string strerrCbNhietCao = "";
                    string strerrCbNhietThap = "";
                    string strerrCbCangDot = "";
                    if (obj.Error_CB_Nhiet_Cao)
                    {
                        strerrCbNhietCao = "Nhiệt độ cao, ";
                    }
                    if (obj.Error_CB_Nhiet_Thap)
                    {
                        strerrCbNhietCao = "Nhiệt độ thấp, ";
                    }
                    if (obj.Error_CB_Cang_Dot)
                    {
                        strerrCbNhietCao = "Càng đốt, ";
                    }
                    string strErr = strerrCbNhietCao + strerrCbNhietThap + strerrCbCangDot;
                    obj.Error = strErr.Substring(0, strErr.Length - 2);
                }






                obj.BauNongName = "Bầu " + (i + 1);
                dongDienAC += 4;
                nhietDoPC += 2;
                SoLanTest_ST_PC += 2;
                nhietdongatcb += 2;
                cbNhiet += 2;
                errCbNhietCao += 2;
                errCbNhietThap += 2;
                errCbCangDot += 2;
                listBauNong.Add(obj);
            }

            return listBauNong;
        }

        public void SaveData(List<BauNong> listBauNong)
        {
            if (listBauNong != null && listBauNong.Count > 0)
            {
                new DALBauNong().Add(listBauNong);
            }
        }
    }
}
