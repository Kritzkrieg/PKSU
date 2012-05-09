using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Security;
using MySql.Data;
using MySql.Web;
using MySql.Data.MySqlClient;
using MySql;

namespace ELearning.Models
{
    public class StudentAssignment
    {
        public string UserName { get; set; }
        public int ID { get; set; }
        public String DateTime { get; set; }
        public int OptionTaken1 { get; set; }
        public int OptionTaken2 { get; set; }
        public int OptionTaken3 { get; set; }
        public bool Solved1 { get; set; }
        public bool Solved2 { get; set; }
        public bool Solved3 { get; set; }

        public static List<StudentAssignment> GetStudentsAssignments(string name)
        {
            List<StudentAssignment> Sas = new List<StudentAssignment>();

            using (MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                con.Open();
                var cmd = new MySqlCommand("SELECT ID, DateTime, OptionTaken1, OptionTaken2, OptionTaken3, Solved1, Solved2, Solved3 FROM StudentAssignment WHERE UserName = ?", con);
                cmd.Parameters.AddWithValue("?", name);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        var StudentsAssignments = new StudentAssignment();
                        StudentsAssignments.UserName = name;
                        StudentsAssignments.ID = r.GetInt32(0);
                        StudentsAssignments.DateTime = r.GetString(1);
                        StudentsAssignments.OptionTaken1 = r.GetInt32(2);
                        StudentsAssignments.OptionTaken2 = r.GetInt32(3);
                        StudentsAssignments.OptionTaken3 = r.GetInt32(4);
                        StudentsAssignments.Solved1 = r.GetBoolean(5);
                        StudentsAssignments.Solved2 = r.GetBoolean(6);
                        StudentsAssignments.Solved3 = r.GetBoolean(7);
                        Sas.Add(StudentsAssignments);
                    }
                    return Sas;
                }
            }

        }
    }
    public class StudentAssignmentUser
    {
        public List<StudentAssignment> studentassignment { get; set; }
        public MembershipUser user { get; set; }
 
    }

        public class StudentAssignmentConnection : DbContext
        {
            public DbSet<StudentAssignment> StudentAssignments { get; set; }
        }
    }
