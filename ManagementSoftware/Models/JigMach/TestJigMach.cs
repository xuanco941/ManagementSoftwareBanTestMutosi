using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models.JigMach
{
    [Table("TestJigMach")]
    public class TestJigMach
    {
        [Key]
        public int TestJigMachID { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
