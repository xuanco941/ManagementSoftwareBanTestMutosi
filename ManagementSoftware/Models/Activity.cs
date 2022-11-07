using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSoftware.Models
{
    [Table("Activity")]
    public class Activity
    {
        [Key]
        public int ActivityID { get; set; }
        [MaxLength]
        public string ActivityName { get; set; }
        [MaxLength]
        public string? Description { get; set; }
        [StringLength(100)]
        public string? Username { get; set; }
        public DateTime CreateAt { get; set; }

        public Activity(string activityName, string? description, string? username)
        {
            ActivityName = activityName;
            Description = description;
            Username = username;
        }

        public Activity(int activityID, string activityName, string? description, string? username, DateTime createAt)
        {
            ActivityID = activityID;
            ActivityName = activityName;
            Description = description;
            Username = username;
            CreateAt = createAt;
        }
    }
}
