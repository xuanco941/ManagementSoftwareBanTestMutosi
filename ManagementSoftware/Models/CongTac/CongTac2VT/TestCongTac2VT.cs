using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models
{
    [Table("TestCongTac2VT")]
    public class TestCongTac2VT
    {
        [Key]
        public int TestCongTac2VTID { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
