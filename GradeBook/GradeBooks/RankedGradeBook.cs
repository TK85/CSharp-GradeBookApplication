﻿using System;
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

        public override char GetLetterGrade (double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students or more");
            }

            var threshold = (int)Math.Ceiling(Students.Count * 0.2); // 0.2 represents 20%
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList(); // Linq expression, foreach loop can be utilized

            if (grades[threshold - 1]  <= averageGrade)
                return 'A';
            else if (grades[threshold*2 - 1] <= averageGrade)
                return 'B';
            else if (grades[threshold*3 - 1] <= averageGrade)
                return 'C';
            else if (grades[threshold*4 - 1] <= averageGrade)
                return 'D';
            else
                return 'F';

            // return base.GetLetterGrade(averageGrade); // not needed?

        }
    }
}