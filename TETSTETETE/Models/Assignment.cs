using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

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

        public string tTrueOption { get; set; }
        public int TheoryAnswer { get; set; }

        /*----------Mellemregning----------*/

        [Display(Name = "Mellemregning 1")]
        public string Option1 { get; set; }

        [Display(Name = "Mellemregning 2")]
        public string Option2 { get; set; }

        [Display(Name = "Mellemregning 3")]
        public string Option3 { get; set; }

        [Display(Name = "Mellemregning 4")]
        public string Option4 { get; set; }

        public string TrueOption { get; set; }
        public int Answer { get; set; }

        /*----------Facit----------*/

        [Display(Name = "Svar 1")]
        public string fOption1 { get; set; }

        [Display(Name = "Svar 2")]
        public string fOption2 { get; set; }

        [Display(Name = "Svar 3")]
        public string fOption3 { get; set; }

        [Display(Name = "Svar 4")]
        public string fOption4 { get; set; }

        public string fTrueOption { get; set; }
        public int FinalAnswer { get; set; }


        public void SolveAssignment(int userID, int ID, int Option1, int Option2, int Option3, bool Solved1, bool Solved2, bool Solved3)
        {
            StudentAssignment studentassignment;
            studentassignment = new StudentAssignment();
            studentassignment.DateTime = DateTime.Now;
            studentassignment.ID = ID;
            studentassignment.OptionTaken1 = Option1;
            studentassignment.OptionTaken2 = Option2;
            studentassignment.OptionTaken3 = Option3;
            studentassignment.Solved1 = Solved1;
            studentassignment.Solved2 = Solved2;
            studentassignment.Solved3 = Solved3;
            db.StudentAssignments.Add(studentassignment);
            db.SaveChanges();
        }
    }

    public class AssignmentConnection : DbContext
    {
        public DbSet<Assignment> Assignments { get; set; }
    }
}