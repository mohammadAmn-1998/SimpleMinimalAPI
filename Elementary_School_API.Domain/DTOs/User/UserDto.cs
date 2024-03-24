using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary_School_API.Domain.DTOs.User
{
	public class UserDto
	{

		public int Id { get; set; }

		public string? UserName { get; set; }

		public string? Password { get; set; }

		public DateTime CreationTime { get; set; }

		public DateTime? UpdateTime { get; set; }

		public bool IsDeleted { get; set; }

	}
}
