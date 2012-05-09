﻿using System;
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
            using (MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                con.Open();
                var cmd = new MySqlCommand("INSERT INTO studentassignment VALUES ('LOL', 2, 'ROFL', 1, 1, 1, true, true, true, null)", con);
                //cmd.Parameters.AddWithValue("id", null); //Null because we want database to generate primary key
                //cmd.Parameters.AddWithValue("name", name.ToString());
                //cmd.Parameters.AddWithValue("year", year.ToString());

                cmd.ExecuteNonQuery();
            }
        }
    }

    public class AssignmentConnection : DbContext
    {
        public DbSet<Assignment> Assignments { get; set; }
    }
}