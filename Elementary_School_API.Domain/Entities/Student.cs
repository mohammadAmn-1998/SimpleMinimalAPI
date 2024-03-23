using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elementary_School_API.Domain.SeedWorks.Base;

namespace Elementary_School_API.Domain.Entities
{
	public class Student : EntityBase
	{
		[MaxLength(9)]
		public int StudentNumber { get; set; }

		[MaxLength(50)]
		public string? FirstName { get; set; }

		[MaxLength(50)]
		public string? LastName { get; set; }

		[MaxLength(50)]
		public string? FatherName { get; set; }

		public DateTime? DateOfBirth { get; set; }

		[MaxLength(10)]
		public string? NationalCode { get; set; }


		[InverseProperty("Student")]
		public ICollection<Score>? Scores { get; set; }

	}
}
