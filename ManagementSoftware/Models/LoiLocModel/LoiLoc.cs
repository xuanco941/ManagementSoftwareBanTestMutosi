using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models.LoiLocModel
{
    [Table("LoiLoc")]
    public class LoiLoc
    {
        [Key]
        public int LoiLocID { get; set; }
        public string LoiLocName { get; set; } = "";
        public ushort SoLanTest { get; set; }
        public double ApSuatTest { get; set; }
        public uint ThoiGianNen { get; set; } //ms
        public uint ThoiGianXa { get; set; } //ms
        public uint ThoiGianGiu { get; set; } //ms
        public int TestLoiLocID { get; set; }
        public TestLoiLoc TestLoiLoc { get; set; }
    }
}
