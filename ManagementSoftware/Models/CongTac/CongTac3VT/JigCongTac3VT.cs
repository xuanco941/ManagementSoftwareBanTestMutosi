using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models
{
    [Table("JigCongTac3VT")]
    public class JigCongTac3VT
    {
        [Key]
        public int JigCongTac3VTID { get; set; }
        public int JigCongTac3VTName { get; set; }
        public int TestCongTac3VTID { get; set; }
        public TestCongTac3VT TestCongTac3VT { get; set; }

    }
}
