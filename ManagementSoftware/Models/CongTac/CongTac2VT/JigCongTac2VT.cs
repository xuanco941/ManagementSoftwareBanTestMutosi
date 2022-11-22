using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models
{
    [Table("JigCongTac2VT")]
    public class JigCongTac2VT
    {
        [Key]
        public int JigCongTac2VTID { get; set; }
        public int JigCongTac2VTName { get; set; }
        public int TestCongTac2VTID { get; set; }
        public TestCongTac2VT TestCongTac2VT { get; set; }

    }
}
