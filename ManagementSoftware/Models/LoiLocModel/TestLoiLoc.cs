using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models.LoiLocModel
{
    [Table("TestLoiLoc")]
    public class TestLoiLoc
    {
        [Key]
        public int TestLoiLocID { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
