using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Student_App.Models;
using System.Data.Entity;

namespace Student_App.Models
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> students { get; set; }
    }
}