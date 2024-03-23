using Elementary_School_API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary_School_API.Domain.DTOs.Score
{
	public class ScoreDto
	{


		public int Id { get; set; }

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

		public DateTime CreationDate { get; set; }

		public DateTime? UpdateDate { get; set; }

		public bool IsDeleted { get; set; }

	}
}
