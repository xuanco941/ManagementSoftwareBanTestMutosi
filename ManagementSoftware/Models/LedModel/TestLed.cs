using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models.LedModel
{
    [Table("TestLed")]
    public class TestLed
    {
        [Key]
        public int TestLedID { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
