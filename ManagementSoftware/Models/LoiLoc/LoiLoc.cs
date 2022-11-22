using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models
{
    [Table("LoiLoc")]
    public class LoiLoc
    {
        [Key]
        public int LoiLocID { get; set; }
        public string LoiLocName { get; set; }
        public int SoLanTest { get; set; }
        public double ApSuatTest { get; set; }
        public double ThoiGianNen { get; set; }
        public double ThoiGianXa { get; set; }
        public double ThoiGianGiu { get; set; }
        public int TestLoiLocID { get; set; }
        public TestLoiLoc TestLoiLoc { get; set; }
    }
}
