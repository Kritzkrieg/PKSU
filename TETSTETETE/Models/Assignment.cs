using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TETSTETETE.Models
{
    public class Assignment
    {
        public int ID { get; set; }
        public string Text { get; set; }
    }

    public class MySqlConnection : DbContext
    {
        public DbSet<Assignment> Assignments { get; set; }
    }


}