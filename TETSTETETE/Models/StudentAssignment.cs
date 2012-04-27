using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Security;

namespace ELearning.Models
{
    public class StudentAssignment
    {
            public string UserName { get; set; }
            public int ID { get; set; }
            public int DateTime { get; set; }
            public int optionTaken { get; set; }
        }

    public class StudentAssignmentUser
    {
        public System.Collections.Generic.IEnumerable<ELearning.Models.StudentAssignment> studentassignment { get; set; }
        public MembershipUser user { get; set; }
 
    }

        public class StudentAssignmentConnection : DbContext
        {
            public DbSet<StudentAssignment> StudentAssignments { get; set; }
        }
    }
