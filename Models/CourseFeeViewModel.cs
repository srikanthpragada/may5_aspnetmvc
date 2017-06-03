using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Models
{
    public class CourseFeeViewModel
    {
        public int BaseFee{ get; set; }
        public string Timings { get; set; }
        public bool OldStudent { get; set; }
        public int CourseFee { get; set; }

    }
}