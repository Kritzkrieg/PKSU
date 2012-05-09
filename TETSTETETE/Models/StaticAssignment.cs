using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Web;
using MySql.Data.MySqlClient;
using MySql;


namespace ELearning.Models
{
    public class StaticAssignment
    {
        private StudentAssignmentConnection db = new StudentAssignmentConnection();
        public int Answer
        {
            get;
            set;
        }

        public int FinalAnswer
        {
            get;
            set;
        }

        public int TheoryAnswer
        {
            get;
            set;
        }

        public void SolveAssignment()
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
}