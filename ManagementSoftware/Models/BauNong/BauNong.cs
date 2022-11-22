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
        public double DongAC { get; set; }
        public double NhietDo { get; set; }
        public double ThoiGianNgat { get; set; }
        public double CBNhietThanBauNong { get; set; }
        public int TestBauNongID { get; set; }
        public TestBauNong TestBauNong { get; set; }
    }
}
