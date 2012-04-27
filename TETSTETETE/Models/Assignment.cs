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
        public int ID { get; set; }

        [Display(Name = "Opgaveformulering")]
        public string Text { get; set; }

        /*----------Mellemregning----------*/

        [Display(Name = "Svarmulighed 1")]
        public string Option1 { get; set; }

        [Display(Name = "Svarmulighed 2")]
        public string Option2 { get; set; }

        [Display(Name = "Svarmulighed 3")]
        public string Option3 { get; set; }

        [Display(Name = "Svarmulighed 4")]
        public string Option4 { get; set; }

        public string TrueOption { get; set; }
        public int Answer { get; set; }

        /*----------Facit----------*/

        [Display(Name = "Svarmulighed 1")]
        public string fOption1 { get; set; }

        [Display(Name = "Svarmulighed 2")]
        public string fOption2 { get; set; }

        [Display(Name = "Svarmulighed 3")]
        public string fOption3 { get; set; }

        [Display(Name = "Svarmulighed 4")]
        public string fOption4 { get; set; }

        public string fTrueOption { get; set; }
        public int FinalAnswer { get; set; }

        /*----------Teori----------*/

        [Display(Name = "Svarmulighed 1")]
        public string tOption1 { get; set; }

        [Display(Name = "Svarmulighed 2")]
        public string tOption2 { get; set; }

        [Display(Name = "Svarmulighed 3")]
        public string tOption3 { get; set; }

        [Display(Name = "Svarmulighed 4")]
        public string tOption4 { get; set; }
        
        public string tTrueOption { get; set; }
        public int TheoryAnswer { get; set; }
    }

    public class MySqlConnection : DbContext
    {
        public DbSet<Assignment> Assignments { get; set; }
    }


}