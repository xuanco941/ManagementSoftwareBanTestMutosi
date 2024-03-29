﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models.NguonModel
{
    [Table("Nguon")]
    public class Nguon
    {
        [Key]
        public int NguonID { get; set; }
        public string NguonName { get; set; } = "";
        public double DienApDC { get; set; } // double
        public double DongDC { get; set; } // double
        public double CongSuat { get; set; } //double
        public uint ThoiGianTest { get; set; } // uint
        public ushort LanTestThu { get; set; } //ushort 
        public bool Error_Dong { get; set; }
        public bool Error_Ap { get; set; }
        public string Error { get; set; } = Common.NOT_ERROR_STR;
        public bool isOn { get; set; }
        public int TestNguonID { get; set; }
        public TestNguon TestNguon { get; set; }
    }
}
