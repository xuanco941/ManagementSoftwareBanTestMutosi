using ManagementSoftware.Models.NguonModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models.LedModel
{
    [Table("Led")]
    public class Led
    {
        [Key]
        public int LedID { get; set; }
        public string LedName { get; set; } = "";
        public bool TrangThai { get; set; }
        public uint ThoiGianTest { get; set; } // uint
        public ushort LanTestThu { get; set; } //ushort 
        public bool isError { get; set; }
        public string Error { get; set; } = "Không";

        public int TestLedID { get; set; }
        public TestLed TestLed { get; set; }
    }
}
