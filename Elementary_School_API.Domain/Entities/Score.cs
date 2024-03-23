using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elementary_School_API.Domain.SeedWorks.Base;

namespace Elementary_School_API.Domain.Entities
{
	public class Score : EntityBase
	{
		

		public int StudentId { get; set; }

		public double Math { get; set; }

		public double Reading { get; set; }

		public double Language { get; set; }

		public double Spelling { get; set; }

		public double Writing { get; set; }

		public double Science { get; set; }

		public double Art { get; set; }

		public double PhysicalEducation { get; set; }

		public Quarter Quarter { get; set; }

		[ForeignKey(nameof(StudentId))]
		public Student? Student { get; set; }
	}

	public enum Quarter
	{
		QuarterOne = 1,
		QuarterTwo = 2,
		QuarterThree = 3,
		QuarterFour = 4
	}
}
