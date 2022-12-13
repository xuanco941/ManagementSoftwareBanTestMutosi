using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models
{
    [Table("BauNong")]
    public class BauNong
    {
        [Key]
        public int BauNongID { get; set; }
        public string BauNongName { get; set; }
        public double DongDienAC { get; set; }
        public double NhietDo { get; set; }
        public ushort SoLanTest { get; set; }
        public ushort NhietDoNgatCBNhiet { get; set; }
        public bool CBNhietThanBauNong { get; set; }
        public int TestBauNongID { get; set; }
        public TestBauNong TestBauNong { get; set; }
    }
}
