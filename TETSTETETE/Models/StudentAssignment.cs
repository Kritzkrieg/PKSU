using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ELearning.Models
{
    public class StudentAssignment
    {
            public int userID { get; set; }
            public int ID { get; set; }
            public DateTime DateTime { get; set; }
            public int optionTaken { get; set; }
        }

        public class StudentAssignmentConnection : DbContext
        {
            public DbSet<StudentAssignment> StudentAssignments { get; set; }
        }
    }
