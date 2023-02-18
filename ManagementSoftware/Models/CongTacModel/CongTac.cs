using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models.CongTacModel
{

    [Table("CongTac")]
    public class CongTac
    {
        [Key]
        public int CongTacID { get; set; }
        public string CongTacName { get; set; } = "";
        public ushort LanTestThu { get; set; }
        public bool TrangThai { get; set; }
        public string JigCongTac { get; set; } = "";
        public bool isError { get; set; }
        public string Error { get; set; } = Common.NOT_ERROR_STR;
        public bool isOn { get; set; }
        public int TestCongTacID { get; set; }
        public TestCongTac TestCongTac { get; set; }
    }
}
