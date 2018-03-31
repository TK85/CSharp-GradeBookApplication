using System;
using System.Linq;
using GradeBook.Enums;


namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override void CalculateStatistics()
        {
            int numberofStudents = 5;
            if (Students.Count < numberofStudents)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            int numberofStudents = 5;
            if (Students.Count < numberofStudents)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade");
                return;
            }

            base.CalculateStudentStatistics(name);
        }

        public override char GetLetterGrade (double averageGrade)
        {
            int minimumNumberofStudents = 5;

            if (Students.Count < minimumNumberofStudents)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students or more");
            }
            else
            {
                var threshold = (int)Math.Ceiling(Students.Count * 0.2); // 0.2 represents 20%
                var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList(); // LINQ expression, foreach loop can be utilized

                if (grades[threshold - 1] <= averageGrade)
                    return 'A';
                else if (grades[(threshold * 2) - 1] <= averageGrade)
                    return 'B';
                else if (grades[(threshold * 3) - 1] <= averageGrade)
                    return 'C';
                else if (grades[(threshold * 4) - 1] <= averageGrade)
                    return 'D';
                else
                    return 'F';
            }

        }
    }
}
