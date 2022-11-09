using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models.JigMach
{
    [Table("JigMachTDS")]

    public class JigMachTDS
    {
        [Key]
        public int JigMachTDSID { get; set; }
        public int JigMachTDSNumber { get; set; }
        public double ApDC { get; set; }
        public bool Van { get; set; }
        public bool CBApSuat { get; set; }
        public DateTime CreateAt { get; set; }
        public int TestJigMachID { get; set; }
        public TestJigMach TestJigMach { get; set; }
    }
}
