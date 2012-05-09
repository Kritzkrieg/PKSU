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
                var cmd = new MySqlCommand("INSERT INTO studentassignment VALUES (@username, @ID, @DateTime, @OptionTaken1, @OptionTaken2, @OptionTaken3, @Solved1, @Solved2, @Solved3, null)", con);
                cmd.Parameters.AddWithValue("@UserName", "Henning");
                cmd.Parameters.AddWithValue("@ID", 2);
                cmd.Parameters.AddWithValue("@DateTime", "lol");
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
}