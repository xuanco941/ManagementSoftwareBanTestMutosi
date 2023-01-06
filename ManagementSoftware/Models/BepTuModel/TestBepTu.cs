using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models.BepTuModel
{
    [Table("TestBepTu")]
    public class TestBepTu
    {
        [Key]
        public int TestBepTuID { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
