using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    [Table("courses")]
    public class DBCourse
    {
        [Key]
        public int Id { get; set; }

        [Column]
        [StringLength (20,  MinimumLength =4, ErrorMessage ="Invalid Course Name")]
        public String Name { get; set; }

        [Column]
        [Range (10,100, ErrorMessage ="Invalid Course Duration")]
        public int Duration { get; set; }

        [Column]
        [Range(500, 100000, ErrorMessage = "Invalid Fee Duration")]
        public int Fee { get; set; }

    }
}