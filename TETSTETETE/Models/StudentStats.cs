using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ELearning.Models
{
    public class StudentStats
    {
        public int userID { get; set; }
        public int Points { get; set; }
    }

    public class StudentStatsConnection : DbContext
    {
        public DbSet<StudentStats> StudentStats { get; set; }
    }
}
