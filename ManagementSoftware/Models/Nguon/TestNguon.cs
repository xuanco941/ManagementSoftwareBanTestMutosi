using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models
{
    [Table("TestNguon")]
    public class TestNguon
    {
        [Key]
        public int TestNguonID { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
