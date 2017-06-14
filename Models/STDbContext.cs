using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class STDbContext : DbContext 
    {
        public STDbContext() : base("name=localdb")
        {

        }

        public virtual DbSet<DBCourse> Courses { get; set; }
    }
}