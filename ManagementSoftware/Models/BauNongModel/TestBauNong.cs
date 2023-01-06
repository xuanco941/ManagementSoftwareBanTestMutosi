using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models.BauNongModel
{
    [Table("TestBauNong")]
    public class TestBauNong
    {
        [Key]
        public int TestBauNongID { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
