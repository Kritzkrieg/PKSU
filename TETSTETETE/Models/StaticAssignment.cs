using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            StudentAssignment studentassignment;
            studentassignment = new StudentAssignment();
            studentassignment.DateTime = DateTime.Now;
            studentassignment.ID = 23;
            studentassignment.OptionTaken1 = TheoryAnswer;
            studentassignment.OptionTaken2 = Answer;
            studentassignment.OptionTaken3 = FinalAnswer;
            studentassignment.Solved1 = false;
            studentassignment.Solved2 = false;
            studentassignment.Solved3 = true;
            db.StudentAssignments.Add(studentassignment);
            db.SaveChanges();
        }
    }
}