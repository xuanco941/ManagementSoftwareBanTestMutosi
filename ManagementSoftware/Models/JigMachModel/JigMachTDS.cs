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
        public bool Error_Van_DT { get; set; }
        public string Error { get; set; } = Common.NOT_ERROR_STR;
        public bool isOn { get; set; }
        public int TestJigMachTDSID { get; set; }
        public TestJigMachTDS TestJigMachTDS { get; set; }
    }
}
