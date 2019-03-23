using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
	public class RankedGradeBook : BaseGradeBook
	{
		public RankedGradeBook(string name)
			:base(name)
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
				}
			}
		}
	}
}
