using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ELearning.Models
{
    public class Assignment
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string TrueOption { get; set; }
        public int Answer { get; set; }
    }

    public class MySqlConnection : DbContext
    {
        public DbSet<Assignment> Assignments { get; set; }
    }


}