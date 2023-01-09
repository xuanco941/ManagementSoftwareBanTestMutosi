using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models.JigMachModel
{
    [Table("JigMachTDS")]

    public class JigMachTDS
    {
        [Key]
        public int JigMachTDSID { get; set; }
        public string JigMachTDSName { get; set; } = "";
        public bool VanDienTu { get; set; }
        public bool VanApCao { get; set; }
        public uint ThoiGian { get; set; }
        public ushort LanTestThu { get; set; }
        public int TestJigMachID { get; set; }
        public TestJigMach TestJigMach { get; set; }
    }
}
