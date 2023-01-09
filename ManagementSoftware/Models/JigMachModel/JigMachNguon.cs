﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models.JigMachModel
{
    [Table("JigMachNguon")]
    public class JigMachNguon
    {
        [Key]
        public int JigMachNguonID { get; set; }
        public string JigMachNguonName { get; set; } = "";
        public double DienApDC { get; set; }
        public double DongDienDC { get; set; }
        public double CongSuat { get; set; }
        public uint ThoiGian { get; set; }
        public ushort LanTestThu { get; set; }
        public int TestJigMachID { get; set; }
        public TestJigMach TestJigMach { get; set; }
    }
}
