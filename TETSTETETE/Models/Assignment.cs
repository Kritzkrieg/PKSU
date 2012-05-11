using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using MySql.Web;
using MySql.Data.MySqlClient;
using MySql;

namespace ELearning.Models
{
    public class Assignment
    {
        private StudentAssignmentConnection db = new StudentAssignmentConnection();

        public int ID { get; set; }

        [Display(Name = "Opgaveformulering")]
        public string Text { get; set; }

        /*----------Teori----------*/

        [Display(Name = "Teori 1")]
        public string tOption1 { get; set; }

        [Display(Name = "Teori 2")]
        public string tOption2 { get; set; }

        [Display(Name = "Teori 3")]
        public string tOption3 { get; set; }

        [Display(Name = "Teori 4")]
        public string tOption4 { get; set; }

        public int truetOption { get; set; }

        /*----------Mellemregning----------*/

        [Display(Name = "Mellemregning 1")]
        public string Option1 { get; set; }

        [Display(Name = "Mellemregning 2")]
        public string Option2 { get; set; }

        [Display(Name = "Mellemregning 3")]
        public string Option3 { get; set; }

        [Display(Name = "Mellemregning 4")]
        public string Option4 { get; set; }

        public int TrueOption { get; set; }

        /*----------Facit----------*/

        [Display(Name = "Svar 1")]
        public string fOption1 { get; set; }

        [Display(Name = "Svar 2")]
        public string fOption2 { get; set; }

        [Display(Name = "Svar 3")]
        public string fOption3 { get; set; }

        [Display(Name = "Svar 4")]
        public string fOption4 { get; set; }

        public int truefOption { get; set; }

        public void SolveAssignment()
        {
            using (MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                con.Open();
                //var bob = new MySqlCommand("select * from assignments WHERE id != (SELECT id FROM studentassignment) order by rand() limit 1");
                var cmd = new MySqlCommand("INSERT INTO studentassignment VALUES (@username, @ID, @DateTime, @OptionTaken1, @OptionTaken2, @OptionTaken3, @Solved1, @Solved2, @Solved3, null)", con);
                cmd.Parameters.AddWithValue("@UserName", "Henning");
                cmd.Parameters.AddWithValue("@ID", 2);
                cmd.Parameters.AddWithValue("@DateTime", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@OptionTaken1", 2);
                cmd.Parameters.AddWithValue("@OptionTaken2", 3);
                cmd.Parameters.AddWithValue("@OptionTaken3", 2);
                cmd.Parameters.AddWithValue("@Solved1", true);
                cmd.Parameters.AddWithValue("@Solved2", false);
                cmd.Parameters.AddWithValue("@Solved3", true);
                cmd.ExecuteNonQuery();
            }
        }

    }

    public class AssignmentConnection : DbContext
    {
        public DbSet<Assignment> Assignments { get; set; }
    }

    public class GivenAssignment
    {
        public Assignment gAssignment { get; set; }
        public int TheoryAnswer { get; set; }
        public int Answer { get; set; }
        public int FinalAnswer { get; set; }
    }
}