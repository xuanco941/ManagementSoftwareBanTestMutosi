using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models
{
    [Table("BepTu")]
    public class BepTu
    {
        [Key]
        public int BepTuID { get; set; }
        public string BepTuName { get; set; }
        public double DongAC { get; set; }
        public double ApAC { get; set; }
        public double CongSuatAC { get; set; }
        public double NhietDo { get; set; }
        public double ThoiGianSoi { get; set; }
        public int SoLanTest { get; set; }
        public int TestBepTuID { get; set; }
        public TestBepTu TestBepTu { get; set; }
    }
}
