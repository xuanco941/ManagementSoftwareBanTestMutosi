using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models.BauNongModel
{
    [Table("BauNong")]
    public class BauNong
    {
        [Key]
        public int BauNongID { get; set; }
        public string BauNongName { get; set; } = "";
        public double DongDien { get; set; }
        public double NhietDo { get; set; }
        public uint ThoiGian { get; set; }
        public ushort NhietDoNgatCBNhiet { get; set; }
        public ushort LanTestThu { get; set; }
        public bool TrangThaiCBNhiet { get; set; }
        public bool Error_CB_Nhiet_Cao { get; set; }
        public bool Error_CB_Nhiet_Thap { get; set; }
        public bool Error_CB_Cang_Dot { get; set; }
        public string Error { get; set; } = "Không";
        public int TestBauNongID { get; set; }
        public TestBauNong TestBauNong { get; set; }
    }
}
