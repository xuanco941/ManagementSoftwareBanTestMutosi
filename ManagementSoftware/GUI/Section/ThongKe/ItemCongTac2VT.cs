using ManagementSoftware.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementSoftware.GUI.Section.ThongKe
{
    public partial class ItemCongTac2VT : Form
    {
        public ItemCongTac2VT(TestCongTac2VT testID , List<CongTac2VT> listCongTac2VT)
        {
            InitializeComponent();
            TimeID.Text = $"ID{testID.TestCongTac2VTID} - (" + testID.CreateAt.ToString($"hh:mm:ss dd/MM/yyyy", CultureInfo.InvariantCulture) + ")";


            foreach (var e in listCongTac2VT)
            {
                if (e.JigCongTac2VTName == TenThietBi.Jig1CongTac)
                {
                    if(e.CongTac2VTName != TenThietBi.CongTac1Jig1)
                    {
                        SoLanTestJig1CT1.Text = e.SoLanTest.ToString();
                        TrangThaiJig1CT1.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac2Jig1)
                    {
                        SoLanTestJig1CT2.Text = e.SoLanTest.ToString();
                        TrangThaiJig1CT2.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac3Jig1)
                    {
                        SoLanTestJig1CT3.Text = e.SoLanTest.ToString();
                        TrangThaiJig1CT3.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac4Jig1)
                    {
                        SoLanTestJig1CT4.Text = e.SoLanTest.ToString();
                        TrangThaiJig1CT4.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac5Jig1)
                    {
                        SoLanTestJig1CT5.Text = e.SoLanTest.ToString();
                        TrangThaiJig1CT5.Text = e.TrangThai == true ? "On" : "Off";
                    }
                }

                else if (e.JigCongTac2VTName == TenThietBi.Jig2CongTac)
                {
                    if (e.CongTac2VTName != TenThietBi.CongTac1Jig2)
                    {
                        SoLanTestJig2CT1.Text = e.SoLanTest.ToString();
                        TrangThaiJig2CT1.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac2Jig2)
                    {
                        SoLanTestJig2CT2.Text = e.SoLanTest.ToString();
                        TrangThaiJig2CT2.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac3Jig2)
                    {
                        SoLanTestJig2CT3.Text = e.SoLanTest.ToString();
                        TrangThaiJig2CT3.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac4Jig2)
                    {
                        SoLanTestJig2CT4.Text = e.SoLanTest.ToString();
                        TrangThaiJig2CT4.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac5Jig2)
                    {
                        SoLanTestJig2CT5.Text = e.SoLanTest.ToString();
                        TrangThaiJig2CT5.Text = e.TrangThai == true ? "On" : "Off";
                    }
                }

                //jig 3

                 else if (e.JigCongTac2VTName == TenThietBi.Jig3CongTac)
                {
                    if (e.CongTac2VTName != TenThietBi.CongTac1Jig3)
                    {
                        SoLanTestJig3CT1.Text = e.SoLanTest.ToString();
                        TrangThaiJig3CT1.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac2Jig3)
                    {
                        SoLanTestJig3CT2.Text = e.SoLanTest.ToString();
                        TrangThaiJig3CT2.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac3Jig3)
                    {
                        SoLanTestJig3CT3.Text = e.SoLanTest.ToString();
                        TrangThaiJig3CT3.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac4Jig3)
                    {
                        SoLanTestJig3CT4.Text = e.SoLanTest.ToString();
                        TrangThaiJig3CT4.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac5Jig3)
                    {
                        SoLanTestJig3CT5.Text = e.SoLanTest.ToString();
                        TrangThaiJig3CT5.Text = e.TrangThai == true ? "On" : "Off";
                    }
                }

                //jig 4

                else if (e.JigCongTac2VTName == TenThietBi.Jig4CongTac)
                {
                    if (e.CongTac2VTName != TenThietBi.CongTac1Jig4)
                    {
                        SoLanTestJig4CT1.Text = e.SoLanTest.ToString();
                        TrangThaiJig4CT1.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac2Jig4)
                    {
                        SoLanTestJig4CT2.Text = e.SoLanTest.ToString();
                        TrangThaiJig4CT2.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac3Jig4)
                    {
                        SoLanTestJig4CT3.Text = e.SoLanTest.ToString();
                        TrangThaiJig4CT3.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac4Jig4)
                    {
                        SoLanTestJig4CT4.Text = e.SoLanTest.ToString();
                        TrangThaiJig4CT4.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac5Jig4)
                    {
                        SoLanTestJig4CT5.Text = e.SoLanTest.ToString();
                        TrangThaiJig4CT5.Text = e.TrangThai == true ? "On" : "Off";
                    }
                }

                //jig 5

                else if (e.JigCongTac2VTName == TenThietBi.Jig5CongTac)
                {
                    if (e.CongTac2VTName != TenThietBi.CongTac1Jig5)
                    {
                        SoLanTestJig5CT1.Text = e.SoLanTest.ToString();
                        TrangThaiJig5CT1.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac2Jig5)
                    {
                        SoLanTestJig5CT2.Text = e.SoLanTest.ToString();
                        TrangThaiJig5CT2.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac3Jig5)
                    {
                        SoLanTestJig5CT3.Text = e.SoLanTest.ToString();
                        TrangThaiJig5CT3.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac4Jig5)
                    {
                        SoLanTestJig5CT4.Text = e.SoLanTest.ToString();
                        TrangThaiJig5CT4.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac5Jig5)
                    {
                        SoLanTestJig5CT5.Text = e.SoLanTest.ToString();
                        TrangThaiJig5CT5.Text = e.TrangThai == true ? "On" : "Off";
                    }
                }

                //jig 6

                else if (e.JigCongTac2VTName == TenThietBi.Jig6CongTac)
                {
                    if (e.CongTac2VTName != TenThietBi.CongTac1Jig6)
                    {
                        SoLanTestJig6CT1.Text = e.SoLanTest.ToString();
                        TrangThaiJig6CT1.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac2Jig6)
                    {
                        SoLanTestJig6CT2.Text = e.SoLanTest.ToString();
                        TrangThaiJig6CT2.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac3Jig6)
                    {
                        SoLanTestJig6CT3.Text = e.SoLanTest.ToString();
                        TrangThaiJig6CT3.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac4Jig6)
                    {
                        SoLanTestJig6CT4.Text = e.SoLanTest.ToString();
                        TrangThaiJig6CT4.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac5Jig6)
                    {
                        SoLanTestJig6CT5.Text = e.SoLanTest.ToString();
                        TrangThaiJig6CT5.Text = e.TrangThai == true ? "On" : "Off";
                    }
                }



                //jig 7

                else if (e.JigCongTac2VTName == TenThietBi.Jig7CongTac)
                {
                    if (e.CongTac2VTName != TenThietBi.CongTac1Jig7)
                    {
                        SoLanTestJig7CT1.Text = e.SoLanTest.ToString();
                        TrangThaiJig7CT1.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac2Jig7)
                    {
                        SoLanTestJig7CT2.Text = e.SoLanTest.ToString();
                        TrangThaiJig7CT2.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac3Jig7)
                    {
                        SoLanTestJig7CT3.Text = e.SoLanTest.ToString();
                        TrangThaiJig7CT3.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac4Jig7)
                    {
                        SoLanTestJig7CT4.Text = e.SoLanTest.ToString();
                        TrangThaiJig7CT4.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac5Jig7)
                    {
                        SoLanTestJig7CT5.Text = e.SoLanTest.ToString();
                        TrangThaiJig7CT5.Text = e.TrangThai == true ? "On" : "Off";
                    }
                }

                //jig 3

                else if (e.JigCongTac2VTName == TenThietBi.Jig8CongTac)
                {
                    if (e.CongTac2VTName != TenThietBi.CongTac1Jig8)
                    {
                        SoLanTestJig8CT1.Text = e.SoLanTest.ToString();
                        TrangThaiJig8CT1.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac2Jig8)
                    {
                        SoLanTestJig8CT2.Text = e.SoLanTest.ToString();
                        TrangThaiJig8CT2.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac3Jig8)
                    {
                        SoLanTestJig8CT3.Text = e.SoLanTest.ToString();
                        TrangThaiJig8CT3.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac4Jig8)
                    {
                        SoLanTestJig8CT4.Text = e.SoLanTest.ToString();
                        TrangThaiJig8CT4.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac5Jig8)
                    {
                        SoLanTestJig8CT5.Text = e.SoLanTest.ToString();
                        TrangThaiJig8CT5.Text = e.TrangThai == true ? "On" : "Off";
                    }
                }


                //jig 9

                else if (e.JigCongTac2VTName == TenThietBi.Jig9CongTac)
                {
                    if (e.CongTac2VTName != TenThietBi.CongTac1Jig9)
                    {
                        SoLanTestJig9CT1.Text = e.SoLanTest.ToString();
                        TrangThaiJig9CT1.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac2Jig9)
                    {
                        SoLanTestJig9CT2.Text = e.SoLanTest.ToString();
                        TrangThaiJig9CT2.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac3Jig9)
                    {
                        SoLanTestJig9CT3.Text = e.SoLanTest.ToString();
                        TrangThaiJig9CT3.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac4Jig9)
                    {
                        SoLanTestJig9CT4.Text = e.SoLanTest.ToString();
                        TrangThaiJig9CT4.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac5Jig9)
                    {
                        SoLanTestJig9CT5.Text = e.SoLanTest.ToString();
                        TrangThaiJig9CT5.Text = e.TrangThai == true ? "On" : "Off";
                    }
                }


                //jig 3

                else if (e.JigCongTac2VTName == TenThietBi.Jig10CongTac)
                {
                    if (e.CongTac2VTName != TenThietBi.CongTac1Jig10)
                    {
                        SoLanTestJig10CT1.Text = e.SoLanTest.ToString();
                        TrangThaiJig10CT1.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac2Jig10)
                    {
                        SoLanTestJig10CT2.Text = e.SoLanTest.ToString();
                        TrangThaiJig10CT2.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac3Jig10)
                    {
                        SoLanTestJig10CT3.Text = e.SoLanTest.ToString();
                        TrangThaiJig10CT3.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac4Jig10)
                    {
                        SoLanTestJig10CT4.Text = e.SoLanTest.ToString();
                        TrangThaiJig10CT4.Text = e.TrangThai == true ? "On" : "Off";
                    }
                    else if (e.CongTac2VTName != TenThietBi.CongTac5Jig10)
                    {
                        SoLanTestJig10CT5.Text = e.SoLanTest.ToString();
                        TrangThaiJig10CT5.Text = e.TrangThai == true ? "On" : "Off";
                    }
                }


            }
        }

    }
}
