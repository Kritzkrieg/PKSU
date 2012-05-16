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

        public static Assignment checkAssignment(Assignment assignment)
        {
            if (assignment.Text == null)
            {
                assignment.Text = "";
            }
            if (assignment.Option1 == null)
            {
                assignment.Option1 = "";
            }
            if (assignment.Option2 == null)
            {
                assignment.Option2 = "";
            }
            if (assignment.Option3 == null)
            {
                assignment.Option3 = "";
            }
            if (assignment.Option4 == null)
            {
                assignment.Option4 = "";
            }
            if (assignment.fOption1 == null)
            {
                assignment.fOption1 = "";
            }
            if (assignment.fOption2 == null)
            {
                assignment.fOption2 = "";
            }
            if (assignment.fOption3 == null)
            {
                assignment.fOption3 = "";
            }
            if (assignment.fOption4 == null)
            {
                assignment.fOption4 = "";
            }
            if (assignment.tOption1 == null)
            {
                assignment.tOption1 = "";
            }
            if (assignment.tOption2 == null)
            {
                assignment.tOption2 = "";
            }
            if (assignment.tOption3 == null)
            {
                assignment.tOption3 = "";
            }
            if (assignment.tOption4 == null)
            {
                assignment.tOption4 = "";
            }
            return assignment;

        }

        public static Assignment GetAssignment(string UserName)
        {
            using (MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                con.Open();
                var cmd = new MySqlCommand("SELECT a.ID, Text, Option1, Option2, Option3, Option4, TrueOption, fOption1, fOption2, fOption3, fOption4, TruefOption, tOption1, tOption2, tOption3, tOption4, TruetOption FROM assignments AS a LEFT OUTER JOIN (SELECT * FROM studentassignment WHERE UserName = ?) AS o ON a.id = o.id WHERE o.id IS null ORDER BY rand() limit 1", con);
                cmd.Parameters.AddWithValue("?", UserName);
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
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
                        return RandomAssignment;
                    }
                    Assignment ass = new Assignment();
                    return ass;
                }
            }


        }

        public static void DeleteAssignment(int id)
        {
            using (MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                con.Open();
                var cmd = new MySqlCommand("DELETE from assignments WHERE id = ?", con);
                cmd.Parameters.AddWithValue("?", id);
                cmd.ExecuteNonQuery();
            }

        }

        public static void EditAssignment(Assignment assignment)
        {
            assignment = Assignment.checkAssignment(assignment);
            using (MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                con.Open();
                var cmd = new MySqlCommand("UPDATE assignments SET Text=@Text, Option1=@Option1, Option3=@Option3, Option4=@Option4, trueOption=@trueOption, fOption1=@fOption1, fOption2=@fOption2, fOption3=@fOption3, fOption4=@fOption4, truefOption=@truefOption, tOption1=@tOption1, tOption2=@tOption2, tOption3=@tOption3, tOption4=@tOption4, truetOption=@trueOption WHERE ID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", assignment.ID);
                cmd.Parameters.AddWithValue("@Text", assignment.ID);
                cmd.Parameters.AddWithValue("@Option1", assignment.ID);
                cmd.Parameters.AddWithValue("@Option2", assignment.ID);
                cmd.Parameters.AddWithValue("@Option3", assignment.ID);
                cmd.Parameters.AddWithValue("@Option4", assignment.ID);
                cmd.Parameters.AddWithValue("@trueOption", assignment.ID);
                cmd.Parameters.AddWithValue("@fOption1", assignment.ID);
                cmd.Parameters.AddWithValue("@fOption2", assignment.ID);
                cmd.Parameters.AddWithValue("@fOption3", assignment.ID);
                cmd.Parameters.AddWithValue("@fOption4", assignment.ID);
                cmd.Parameters.AddWithValue("@truefOption", assignment.ID);
                cmd.Parameters.AddWithValue("@tOption1", assignment.ID);
                cmd.Parameters.AddWithValue("@tOption2", assignment.ID);
                cmd.Parameters.AddWithValue("@tOption3", assignment.ID);
                cmd.Parameters.AddWithValue("@tOption4", assignment.ID);
                cmd.Parameters.AddWithValue("@truetOption", assignment.ID);
                cmd.ExecuteNonQuery();
            }
        }

        public static void AddAssignment(Assignment assignment)
        {
            assignment = Assignment.checkAssignment(assignment);
            using (MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                con.Open();
                var cmd = new MySqlCommand("INSERT INTO assignments VALUES (@ID, @Text, @Option1, @Option2, @Option3, @Option4, @trueOption, @fOption1, @fOption2, @fOption3, @fOption4, @truefOption, @tOption1, @tOption2, @tOption3, @tOption4, @truetOption)", con);
                cmd.Parameters.AddWithValue("@ID", assignment.ID);
                cmd.Parameters.AddWithValue("@Text", assignment.Text);
                cmd.Parameters.AddWithValue("@Option1", assignment.Option1);
                cmd.Parameters.AddWithValue("@Option2", assignment.Option2);
                cmd.Parameters.AddWithValue("@Option3", assignment.Option3);
                cmd.Parameters.AddWithValue("@Option4", assignment.Option4);
                cmd.Parameters.AddWithValue("@trueOption", assignment.TrueOption);
                cmd.Parameters.AddWithValue("@fOption1", assignment.fOption1);
                cmd.Parameters.AddWithValue("@fOption2", assignment.fOption2);
                cmd.Parameters.AddWithValue("@fOption3", assignment.fOption3);
                cmd.Parameters.AddWithValue("@fOption4", assignment.fOption4);
                cmd.Parameters.AddWithValue("@truefOption", assignment.TruefOption);
                cmd.Parameters.AddWithValue("@tOption1", assignment.tOption1);
                cmd.Parameters.AddWithValue("@tOption2", assignment.tOption2);
                cmd.Parameters.AddWithValue("@tOption3", assignment.tOption3);
                cmd.Parameters.AddWithValue("@tOption4", assignment.tOption4);
                cmd.Parameters.AddWithValue("@truetOption", assignment.TruetOption);
                cmd.ExecuteNonQuery();
            }

        }
        public static Assignment GetSpecificAssignment(int id)
        {
            using (MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                con.Open();
                var cmd = new MySqlCommand("SELECT ID, Text, Option1, Option2, Option3, Option4, trueOption, fOption1, fOption2, fOption3, fOption4, truefOption, tOption1, tOption2, tOption3, tOption4, truetOption FROM assignments WHERE ID = ?", con);
                cmd.Parameters.AddWithValue("?", id);
                using (var r = cmd.ExecuteReader())
                {
                    r.Read();
                    var SpecificAssignment = new Assignment();
                    SpecificAssignment.ID = r.GetInt32(0);
                    SpecificAssignment.Text = r.GetString(1);
                    SpecificAssignment.Option1 = r.GetString(2);
                    SpecificAssignment.Option2 = r.GetString(3);
                    SpecificAssignment.Option3 = r.GetString(4);
                    SpecificAssignment.Option4 = r.GetString(5);
                    SpecificAssignment.TrueOption = r.GetInt32(6);
                    SpecificAssignment.fOption1 = r.GetString(7);
                    SpecificAssignment.fOption2 = r.GetString(8);
                    SpecificAssignment.fOption3 = r.GetString(9);
                    SpecificAssignment.fOption4 = r.GetString(10);
                    SpecificAssignment.TruefOption = r.GetInt32(11);
                    SpecificAssignment.tOption1 = r.GetString(12);
                    SpecificAssignment.tOption2 = r.GetString(13);
                    SpecificAssignment.tOption3 = r.GetString(14);
                    SpecificAssignment.tOption4 = r.GetString(15);
                    SpecificAssignment.TruetOption = r.GetInt32(16);
                    return SpecificAssignment;
                }
            }


        }


        public static List<Assignment> GetAllAssignments()
        {
            List<Assignment> assignmentList = new List<Assignment>();
            using (MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {   
                con.Open();
                var cmd = new MySqlCommand("SELECT ID, Text, Option1, Option2, Option3, Option4, trueOption, fOption1, fOption2, fOption3, fOption4, truefOption, tOption1, tOption2, tOption3, tOption4, truetOption FROM assignments", con);
                using (var r = cmd.ExecuteReader()) 
                {
                    while (r.Read())
                    {
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
                        assignmentList.Add(RandomAssignment);
                    }
                    return assignmentList;
                }
            }
        }

       

    }


    public class GivenAssignment
    {
        public Assignment gAssignment { get; set; }
        public int TheoryAnswer { get; set; }
        public int Answer { get; set; }
        public int FinalAnswer { get; set; }
        public int assignmentID { get; set; }

         public void SolveAssignment(string UserName)
        {
            using (MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                con.Open();
                var cmd = new MySqlCommand("INSERT INTO studentassignment VALUES (@username, @ID, @DateTime, @OptionTaken1, @OptionTaken2, @OptionTaken3, @Solved1, @Solved2, @Solved3, null)", con);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@ID", gAssignment.ID);
                cmd.Parameters.AddWithValue("@DateTime", DateTime.Now.ToString().Substring(0, 10));
                cmd.Parameters.AddWithValue("@OptionTaken1", TheoryAnswer);
                cmd.Parameters.AddWithValue("@OptionTaken2", Answer);
                cmd.Parameters.AddWithValue("@OptionTaken3", FinalAnswer);
                 bool theorybool = false;
                if (TheoryAnswer == gAssignment.TruetOption) {
                    theorybool = true;
                }
                cmd.Parameters.AddWithValue("@Solved1", theorybool);
                bool answerbool = false;
                if (Answer == gAssignment.TrueOption)
                {
                    answerbool = true;
                }
                cmd.Parameters.AddWithValue("@Solved2", answerbool);
                bool finalbool = false;
                if (FinalAnswer == gAssignment.TruefOption)
                {
                    finalbool = true;
                }
                cmd.Parameters.AddWithValue("@Solved3", finalbool);
                cmd.ExecuteNonQuery();
            }
        }
    }
}