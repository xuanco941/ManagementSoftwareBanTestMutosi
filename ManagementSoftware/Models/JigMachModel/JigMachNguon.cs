using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models
{
    [Table("JigMachNguon")]
    public class JigMachNguon
    {
        [Key]
        public int JigMachNguonID { get; set; }
        public string JigMachNguonName { get; set; } = "";
        public double DongDien { get; set; }
        public double DienAp { get; set; }
        public double CongSuat { get; set; }
        public uint SoLanTest { get; set; }
        public int TestJigMachID { get; set; }
        public TestJigMach TestJigMach { get; set; }
    }
}
