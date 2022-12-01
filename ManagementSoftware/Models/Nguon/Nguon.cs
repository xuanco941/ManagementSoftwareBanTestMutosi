using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models
{
    [Table("Nguon")]
    public class Nguon
    {
        [Key]
        public int NguonID { get; set; }
        public string NguonName { get; set; }
        public double DongDC { get; set; }
        public double DienApDC { get; set; }
        public double CongSuat { get; set; }
        public uint ThoiGianTest { get; set; }
        public ushort SoLanTest { get; set; }
        public int TestNguonID { get; set; }
        public TestNguon TestNguon { get; set; }
    }
}
