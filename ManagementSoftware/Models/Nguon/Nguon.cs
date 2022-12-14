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
        public string? DongDC { get; set; } // double
        public string? DienApDC { get; set; } // double
        public string? CongSuat { get; set; } //double
        public string? ThoiGianTest { get; set; } // uint
        public string? SoLanTest { get; set; } //ushort 
        public int TestNguonID { get; set; }
        public TestNguon TestNguon { get; set; }
    }
}
