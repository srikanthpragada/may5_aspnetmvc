using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    [Table (Name ="sales")]
    public class Sale
    {
        [Column ( Name ="invno", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Invno { get; set; }

        [Column(Name = "prodid")]
        public int Product { get; set; }

        [Column(Name = "qty")]
        public int Qty { get; set; }

        [Column(Name = "amount")]
        public decimal Amount { get; set; }

        [Column(Name = "transdate")]
        public DateTime TransDate { get; set; }
    }
}