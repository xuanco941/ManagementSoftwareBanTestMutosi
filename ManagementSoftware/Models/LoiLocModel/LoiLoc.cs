using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models.LoiLocModel
{
    [Table("LoiLoc")]
    public class LoiLoc
    {
        [Key]
        public int LoiLocID { get; set; }
        public string LoiLocName { get; set; } = "";
        public ushort SoLanTest { get; set; }
        public double ApSuatTest { get; set; }
        public uint ThoiGianNen { get; set; } //s
        public uint ThoiGianXa { get; set; } //s
        public uint ThoiGianGiu { get; set; } //s
        public DateTime CreateAt { get; set; }
        public bool isError { get; set; }
        public string Error { get; set; } = Common.NOT_ERROR_STR;
        public bool isOn { get; set; }




    }
}
