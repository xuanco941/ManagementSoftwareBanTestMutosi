using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models
{
    [Table("CongTac2VT")]
    public class CongTac2VT
    {
        [Key]
        public int CongTac2VTID { get; set; }
        public string CongTac2VTName { get; set; }
        public int SoLanTest { get; set; }
        public bool TrangThai { get; set; }
        public string JigCongTac2VTName { get; set; }
        public int TestCongTac2VTID { get; set; }
        public TestCongTac2VT TestCongTac2VT { get; set; }
    }
}
