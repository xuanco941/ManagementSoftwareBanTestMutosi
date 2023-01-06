using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models.CongTacModel
{
    [Table("TestCongTac")]
    public class TestCongTac
    {
        [Key]
        public int TestCongTacID { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
