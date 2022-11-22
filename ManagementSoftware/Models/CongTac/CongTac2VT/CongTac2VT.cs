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
        public int JigCongTac2VTID { get; set; }
        public JigCongTac2VT JigCongTac2VT { get; set; }
    }
}
