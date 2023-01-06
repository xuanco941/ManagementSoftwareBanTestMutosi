using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models
{
    [Table("JigMachTDS")]

    public class JigMachTDS
    {
        [Key]
        public int JigMachTDSID { get; set; }
        public string JigMachTDSName { get; set; } = "";
        public double ApDC { get; set; }
        public bool Van { get; set; }
        public bool CBApSuat { get; set; }
        public uint SoLanTest { get; set; }

        public int TestJigMachID { get; set; }
        public TestJigMach TestJigMach { get; set; }
    }
}
