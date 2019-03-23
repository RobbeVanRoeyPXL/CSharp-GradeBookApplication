using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
	public class RankedGradeBook : BaseGradeBook
	{
		public RankedGradeBook(string name, bool isWeighted)
			:base(name, isWeighted)
		{
			Type = GradeBookType.Ranked;
		}

		public override char GetLetterGrade(double averageGrade)
		{
			if (Students.Count < 5)
			{
				throw new InvalidOperationException();
			}
			else
			{
				int threshold = (int)Math.Ceiling(Students.Count * .2);
				List<double> grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

				if (grades[threshold - 1] <= averageGrade)
				{
					return 'A';
				}
				else if (grades[2 * threshold - 1] <= averageGrade)
				{
					return 'B';
				}
				else if (grades[3 * threshold - 1] <= averageGrade)
				{
					return 'C';
				}
				else if (grades[4 * threshold - 1] <= averageGrade)
				{
					return 'D';
				} else
				{
					return 'F';
				}
			}
		}

		public override void CalculateStatistics()
		{
			if (Students.Count < 5)
			{
				Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
			}
			else
			{
				base.CalculateStatistics();
			}
		}

		public override void CalculateStudentStatistics(string name)
		{
			if (Students.Count < 5)
			{
				Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
			}
			else
			{
				base.CalculateStudentStatistics(name);
			}
		}
	}
}
