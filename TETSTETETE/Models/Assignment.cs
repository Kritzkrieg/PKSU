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

        [Display(Name = "Emne")]
        string subjectId;

        public string SubjectId
        {
            get { return subjectId; }
            set { subjectId = value; }
        }
        
        [Required]
        [Display(Name = "Opgaveformulering")]
        public string Text { get; set; }

        /*----------Teori----------*/

        [Display(Name = "Teoriopgave formulering")]
        public string tText { get; set; }

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

        [Display(Name = "Mellemregningsopgave formulering")]
        public string mText { get; set; }

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

        [Display(Name = "Facitopgave formulering")]
        public string fText { get; set; }

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
            if (assignment.Text      == null){ assignment.Text      = ""; }
            if (assignment.SubjectId == null){ assignment.SubjectId = ""; }
            if (assignment.mText     == null){ assignment.mText     = ""; }
            if (assignment.Option1   == null){ assignment.Option1   = ""; }
            if (assignment.Option2   == null){ assignment.Option2   = ""; }
            if (assignment.Option3   == null){ assignment.Option3   = ""; }
            if (assignment.Option4   == null){ assignment.Option4   = ""; }
            if (assignment.fText     == null){ assignment.fText     = ""; }
            if (assignment.fOption1  == null){ assignment.fOption1  = ""; }
            if (assignment.fOption2  == null){ assignment.fOption2  = ""; }
            if (assignment.fOption3  == null){ assignment.fOption3  = ""; }
            if (assignment.fOption4  == null){ assignment.fOption4  = ""; }
            if (assignment.tText     == null){ assignment.tText     = ""; }
            if (assignment.tOption1  == null){ assignment.tOption1  = ""; }
            if (assignment.tOption2  == null){ assignment.tOption2  = ""; }
            if (assignment.tOption3  == null){ assignment.tOption3  = ""; }
            if (assignment.tOption4  == null){ assignment.tOption4  = ""; }
            return assignment;
        }

        public static int NumberOfAssignmentsSubject(string UserName, string Subject)
        {
            using (MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                con.Open();
                var cmd = new MySqlCommand("SELECT COUNT(UserName), subject FROM studentassignment LEFT OUTER JOIN assignments ON studentassignment.ID = assignments.ID WHERE Username = @UserName AND subject = @Subject", con);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Subject", Subject);
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        int number = r.GetInt32(0);
                        return number;
                    }
                }
            }
            return 1;
        }

        public static Assignment GetAssignment(string UserName)
        {
            using (MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                con.Open();
                var cmd = new MySqlCommand("SELECT a.ID, subject, Text, mText, Option1, Option2, Option3, Option4, TrueOption, fText, fOption1, fOption2, fOption3, fOption4, TruefOption, tText, tOption1, tOption2, tOption3, tOption4, TruetOption FROM assignments AS a LEFT OUTER JOIN (SELECT * FROM studentassignment WHERE UserName = ?) AS o ON a.id = o.id WHERE o.id IS null ORDER BY rand() limit 1", con);
                cmd.Parameters.AddWithValue("?", UserName);
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        var RandomAssignment = new Assignment();
                        RandomAssignment.ID          = r.GetInt32(0);
                        RandomAssignment.SubjectId   = r.GetString(1);
                        RandomAssignment.Text        = r.GetString(2);
                        RandomAssignment.mText       = r.GetString(3);
                        RandomAssignment.Option1     = r.GetString(4);
                        RandomAssignment.Option2     = r.GetString(5);
                        RandomAssignment.Option3     = r.GetString(6);
                        RandomAssignment.Option4     = r.GetString(7);
                        RandomAssignment.TrueOption  = r.GetInt32(8);
                        RandomAssignment.fText       = r.GetString(9);
                        RandomAssignment.fOption1    = r.GetString(10);
                        RandomAssignment.fOption2    = r.GetString(11);
                        RandomAssignment.fOption3    = r.GetString(12);
                        RandomAssignment.fOption4    = r.GetString(13);
                        RandomAssignment.TruefOption = r.GetInt32(14);
                        RandomAssignment.tText       = r.GetString(15);
                        RandomAssignment.tOption1    = r.GetString(16);
                        RandomAssignment.tOption2    = r.GetString(17);
                        RandomAssignment.tOption3    = r.GetString(18);
                        RandomAssignment.tOption4    = r.GetString(19);
                        RandomAssignment.TruetOption = r.GetInt32(20);
                        return RandomAssignment;
                    }
                    Assignment assign = new Assignment();
                    return assign;
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
                var cmd = new MySqlCommand("UPDATE assignments SET subject=@subject, Text=@Text, mText=@mText, Option1=@Option1, Option2=@Option2, Option3=@Option3, Option4=@Option4, trueOption=@trueOption, fText=@fText, fOption1=@fOption1, fOption2=@fOption2, fOption3=@fOption3, fOption4=@fOption4, truefOption=@truefOption, tText=@tText, tOption1=@tOption1, tOption2=@tOption2, tOption3=@tOption3, tOption4=@tOption4, truetOption=@truetOption WHERE ID=@ID", con);
                cmd.Parameters.AddWithValue("@ID",          assignment.ID);
                cmd.Parameters.AddWithValue("@subject",     assignment.SubjectId);
                cmd.Parameters.AddWithValue("@Text",        assignment.Text);
                cmd.Parameters.AddWithValue("@mText",       assignment.mText);
                cmd.Parameters.AddWithValue("@Option1",     assignment.Option1);
                cmd.Parameters.AddWithValue("@Option2",     assignment.Option2);
                cmd.Parameters.AddWithValue("@Option3",     assignment.Option3);
                cmd.Parameters.AddWithValue("@Option4",     assignment.Option4);
                cmd.Parameters.AddWithValue("@trueOption",  assignment.TrueOption);
                cmd.Parameters.AddWithValue("@fText",       assignment.fText);
                cmd.Parameters.AddWithValue("@fOption1",    assignment.fOption1);
                cmd.Parameters.AddWithValue("@fOption2",    assignment.fOption2);
                cmd.Parameters.AddWithValue("@fOption3",    assignment.fOption3);
                cmd.Parameters.AddWithValue("@fOption4",    assignment.fOption4);
                cmd.Parameters.AddWithValue("@truefOption", assignment.TruefOption);
                cmd.Parameters.AddWithValue("@tText",       assignment.tText);
                cmd.Parameters.AddWithValue("@tOption1",    assignment.tOption1);
                cmd.Parameters.AddWithValue("@tOption2",    assignment.tOption2);
                cmd.Parameters.AddWithValue("@tOption3",    assignment.tOption3);
                cmd.Parameters.AddWithValue("@tOption4",    assignment.tOption4);
                cmd.Parameters.AddWithValue("@truetOption", assignment.TruetOption);
                cmd.ExecuteNonQuery();
            }
        }

        public static void AddAssignment(Assignment assignment)
        {
            assignment = Assignment.checkAssignment(assignment);
            using (MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                con.Open();
                var cmd = new MySqlCommand("INSERT INTO assignments VALUES (null, @subject, @Text, @mText, @Option1, @Option2, @Option3, @Option4, @trueOption, @fText, @fOption1, @fOption2, @fOption3, @fOption4, @truefOption, @tText, @tOption1, @tOption2, @tOption3, @tOption4, @truetOption)", con);
                cmd.Parameters.AddWithValue("@ID",          assignment.ID);
                cmd.Parameters.AddWithValue("@subject",     assignment.SubjectId);
                cmd.Parameters.AddWithValue("@Text",        assignment.Text);
                cmd.Parameters.AddWithValue("@mText",       assignment.mText);
                cmd.Parameters.AddWithValue("@Option1",     assignment.Option1);
                cmd.Parameters.AddWithValue("@Option2",     assignment.Option2);
                cmd.Parameters.AddWithValue("@Option3",     assignment.Option3);
                cmd.Parameters.AddWithValue("@Option4",     assignment.Option4);
                cmd.Parameters.AddWithValue("@trueOption",  assignment.TrueOption);
                cmd.Parameters.AddWithValue("@fText",       assignment.fText);
                cmd.Parameters.AddWithValue("@fOption1",    assignment.fOption1);
                cmd.Parameters.AddWithValue("@fOption2",    assignment.fOption2);
                cmd.Parameters.AddWithValue("@fOption3",    assignment.fOption3);
                cmd.Parameters.AddWithValue("@fOption4",    assignment.fOption4);
                cmd.Parameters.AddWithValue("@truefOption", assignment.TruefOption);
                cmd.Parameters.AddWithValue("@tText",       assignment.tText);
                cmd.Parameters.AddWithValue("@tOption1",    assignment.tOption1);
                cmd.Parameters.AddWithValue("@tOption2",    assignment.tOption2);
                cmd.Parameters.AddWithValue("@tOption3",    assignment.tOption3);
                cmd.Parameters.AddWithValue("@tOption4",    assignment.tOption4);
                cmd.Parameters.AddWithValue("@truetOption", assignment.TruetOption);
                cmd.ExecuteNonQuery();
            }

        }
        public static Assignment GetSpecificAssignment(int id)
        {
            using (MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                con.Open();
                var cmd = new MySqlCommand("SELECT ID, subject, Text, mText, Option1, Option2, Option3, Option4, trueOption, fText, fOption1, fOption2, fOption3, fOption4, truefOption, tText, tOption1, tOption2, tOption3, tOption4, truetOption FROM assignments WHERE ID = ?", con);
                cmd.Parameters.AddWithValue("?", id);
                using (var r = cmd.ExecuteReader())
                {
                        var SpecificAssignment = new Assignment();
                    if (r.Read())
                    {
                        SpecificAssignment.ID          = r.GetInt32(0);
                        SpecificAssignment.SubjectId   = r.GetString(1);
                        SpecificAssignment.Text        = r.GetString(2);
                        SpecificAssignment.mText       = r.GetString(3);
                        SpecificAssignment.Option1     = r.GetString(4);
                        SpecificAssignment.Option2     = r.GetString(5);
                        SpecificAssignment.Option3     = r.GetString(6);
                        SpecificAssignment.Option4     = r.GetString(7);
                        SpecificAssignment.TrueOption  = r.GetInt32(8);
                        SpecificAssignment.fText       = r.GetString(9);
                        SpecificAssignment.fOption1    = r.GetString(10);
                        SpecificAssignment.fOption2    = r.GetString(11);
                        SpecificAssignment.fOption3    = r.GetString(12);
                        SpecificAssignment.fOption4    = r.GetString(13);
                        SpecificAssignment.TruefOption = r.GetInt32(14);
                        SpecificAssignment.tText       = r.GetString(15);
                        SpecificAssignment.tOption1    = r.GetString(16);
                        SpecificAssignment.tOption2    = r.GetString(17);
                        SpecificAssignment.tOption3    = r.GetString(18);
                        SpecificAssignment.tOption4    = r.GetString(19);
                        SpecificAssignment.TruetOption = r.GetInt32(20);
                    }
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
                var cmd = new MySqlCommand("SELECT ID, subject, Text, mText, Option1, Option2, Option3, Option4, trueOption, fText, fOption1, fOption2, fOption3, fOption4, truefOption, tText, tOption1, tOption2, tOption3, tOption4, truetOption FROM assignments", con);
                using (var r = cmd.ExecuteReader()) 
                {
                    while (r.Read())
                    {
                        var RandomAssignment = new Assignment();
                        RandomAssignment.ID = r.GetInt32(0);
                        RandomAssignment.SubjectId   = r.GetString(1);
                        RandomAssignment.Text        = r.GetString(2);
                        RandomAssignment.mText       = r.GetString(3);
                        RandomAssignment.Option1     = r.GetString(4);
                        RandomAssignment.Option2     = r.GetString(5);
                        RandomAssignment.Option3     = r.GetString(6);
                        RandomAssignment.Option4     = r.GetString(7);
                        RandomAssignment.TrueOption  = r.GetInt32(8);
                        RandomAssignment.fText       = r.GetString(9);
                        RandomAssignment.fOption1    = r.GetString(10);
                        RandomAssignment.fOption2    = r.GetString(11);
                        RandomAssignment.fOption3    = r.GetString(12);
                        RandomAssignment.fOption4    = r.GetString(13);
                        RandomAssignment.TruefOption = r.GetInt32(14);
                        RandomAssignment.tText       = r.GetString(15);
                        RandomAssignment.tOption1    = r.GetString(16);
                        RandomAssignment.tOption2    = r.GetString(17);
                        RandomAssignment.tOption3    = r.GetString(18);
                        RandomAssignment.tOption4    = r.GetString(19);
                        RandomAssignment.TruetOption = r.GetInt32(20);
                        assignmentList.Add(RandomAssignment);
                    }
                    return assignmentList;
                }
            }
        }

        public static List<string> GetSubjects()
        {
            List<string> subjects = new List<string>();
            using (MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                con.Open();
                var cmd = new MySqlCommand("SELECT DISTINCT(subject) FROM subjects", con);
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        if (!r.GetString(0).Equals("0"))
                        {
                            subjects.Add(r.GetString(0));
                        }
                    }
                }
            }
            return subjects;
        }

        public static string GetSubject(int ID)
        {
            using (MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                con.Open();
                var cmd = new MySqlCommand("SELECT subject FROM assignments WHERE ID=@ID", con);
                cmd.Parameters.AddWithValue("@ID", ID);
                var r = cmd.ExecuteReader();
                if (r.Read())
                {
                    return r.GetString(0);
                }
            }
            return "";
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
                cmd.Parameters.AddWithValue("@DateTime", DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@OptionTaken1", TheoryAnswer);
                cmd.Parameters.AddWithValue("@OptionTaken2", Answer);
                cmd.Parameters.AddWithValue("@OptionTaken3", FinalAnswer);

                int i = 0;
                bool theorybool = false;
                if (TheoryAnswer == gAssignment.TruetOption)
                {
                    i++;
                    theorybool = true;
                }
                cmd.Parameters.AddWithValue("@Solved1", theorybool);

                bool answerbool = false;
                if (Answer == gAssignment.TrueOption)
                {
                    i++;
                    answerbool = true;
                }
                cmd.Parameters.AddWithValue("@Solved2", answerbool);

                bool finalbool = false;
                if (FinalAnswer == gAssignment.TruefOption)
                {
                    i++;
                    finalbool = true;
                }
                cmd.Parameters.AddWithValue("@Solved3", finalbool);

                cmd.ExecuteNonQuery();

                int count = 1;
                if (gAssignment.TruetOption.Equals(5)) { count++; }
                if (gAssignment.TrueOption.Equals(5)) { count++; }

                int AddedPoints = 80 + (120 * i);
                if (i == count) { AddedPoints = AddedPoints + 80; }

                var cmd2 = new MySqlCommand("UPDATE userpoints SET Points=Points+@AddedPoints WHERE UserName=@UserName2", con);
                cmd.Parameters.AddWithValue("@AddedPoints", AddedPoints);
                cmd.Parameters.AddWithValue("@UserName2", UserName);
                cmd.ExecuteNonQuery();
            }
        }
    }
}