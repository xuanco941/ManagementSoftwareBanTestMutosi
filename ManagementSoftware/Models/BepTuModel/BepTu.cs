using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models.BepTuModel
{
    [Table("BepTu")]
    public class BepTu
    {
        [Key]
        public int BepTuID { get; set; }
        public string BepTuName { get; set; } = "";
        public double DienAp { get; set; }
        public double DongDien { get; set; }
        public double CongSuat { get; set; }
        public double NhietDo { get; set; }
        public double CongSuatTieuThu { get; set; }
        public bool TrangThai { get; set; }
        public int LanTestThu { get; set; }
        public bool isError { get; set; }
        public string Error { get; set; } = "Không";
        public int TestBepTuID { get; set; }
        public TestBepTu TestBepTu { get; set; }
    }
}
