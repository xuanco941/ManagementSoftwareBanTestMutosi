using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models
{
    [Table("TestCongTac3VT")]
    public class TestCongTac3VT
    {
        [Key]
        public int TestCongTac3VTID { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
