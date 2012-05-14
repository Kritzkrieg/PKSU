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

        public int TruetOption { get; set; }

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

        public int TruefOption { get; set; }

        public static Assignment GetAssignment()
        {
            using (MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                con.Open();
                var cmd = new MySqlCommand("SELECT a.ID, Text, Option1, Option2, Option3, Option4, TrueOption, fOption1, fOption2, fOption3, fOption4, TruefOption, tOption1, tOption2, tOption3, tOption4, TruetOption FROM assignments AS a LEFT OUTER JOIN studentassignment AS o ON a.id = o.id WHERE o.id IS null ORDER BY rand() limit 1");
                using (var r = cmd.ExecuteReader())
                {
                    r.Read();
                    var RandomAssignment = new Assignment();
                    RandomAssignment.ID = r.GetInt32(0);
                    RandomAssignment.Text = r.GetString(1);
                    RandomAssignment.Option1 = r.GetString(2);
                    RandomAssignment.Option2 = r.GetString(3);
                    RandomAssignment.Option3 = r.GetString(4);
                    RandomAssignment.Option4 = r.GetString(5);
                    RandomAssignment.TrueOption = r.GetInt32(6);
                    RandomAssignment.fOption1 = r.GetString(7);
                    RandomAssignment.fOption2 = r.GetString(8);
                    RandomAssignment.fOption3 = r.GetString(9);
                    RandomAssignment.fOption4 = r.GetString(10);
                    RandomAssignment.TruefOption = r.GetInt32(11);
                    RandomAssignment.tOption1 = r.GetString(12);
                    RandomAssignment.tOption2 = r.GetString(13);
                    RandomAssignment.tOption3 = r.GetString(14);
                    RandomAssignment.tOption4 = r.GetString(15);
                    RandomAssignment.TruetOption = r.GetInt32(16);
                    return RandomAssignment;
                }
            }
        }

        public void SolveAssignment()
        {
            using (MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                con.Open();
                var cmd = new MySqlCommand("INSERT INTO studentassignment VALUES (@username, @ID, @DateTime, @OptionTaken1, @OptionTaken2, @OptionTaken3, @Solved1, @Solved2, @Solved3, null)", con);
                cmd.Parameters.AddWithValue("@UserName", "Henning");
                cmd.Parameters.AddWithValue("@ID", 2);
                cmd.Parameters.AddWithValue("@DateTime", DateTime.Now.ToString().Substring(0, 10));
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

    //Next class is for Database/Model clashes
    //public class MyInitializer : DropCreateDatabaseIfModelChanges<AssignmentConnection> { }

    public class GivenAssignment
    {
        public Assignment gAssignment { get; set; }
        public int TheoryAnswer { get; set; }
        public int Answer { get; set; }
        public int FinalAnswer { get; set; }
    }
}