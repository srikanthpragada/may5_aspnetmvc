using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class User
    {
        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage ="Username must be 4 to 10 chars")]
        public string UserName { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Password must be 4 to 8 chars")]
        public string Password { get; set; }
    }
}