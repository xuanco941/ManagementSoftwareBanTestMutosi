using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models
{
    [Table("CongTac3VT")]
    public class CongTac3VT
    {
        [Key]
        public int CongTac3VTID { get; set; }
        public string CongTac3VTName { get; set; }
        public int SoLanTest { get; set; }
        public bool TrangThai1 { get; set; }
        public bool TrangThai2 { get; set; }
        public string JigCongTac3VTName { get; set; }
        public int TestCongTac3VTID { get; set; }
        public TestCongTac3VT TestCongTac3VT { get; set; }
    }
}
