using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Elementary_School_API.Domain.DTOs.Score;

namespace Elementary_School_API.Domain.DTOs.Student
{
	public class StudentDto
	{
		public int Id { get; set; }

		public int StudentNumber { get; set; }

		public string? FirstName { get; set; }

		public string? LastName { get; set; }

		public string? FatherName { get; set; }

		public DateTime? DateOfBirth { get; set; }

		public string? NationalCode { get; set; }

		public DateTime CreationDate { get; set; }

		public DateTime? UpdateDate { get; set; }

		public bool IsDeleted { get; set; }
		
		public List<ScoreDto?>? Scores { get; set; }

		

	}
}
