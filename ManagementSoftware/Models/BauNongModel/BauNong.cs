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
        public ushort LanTestThu { get; set; }
        public bool TrangThaiCBNhiet { get; set; }
        public int TestBauNongID { get; set; }
        public TestBauNong TestBauNong { get; set; }
    }
}
