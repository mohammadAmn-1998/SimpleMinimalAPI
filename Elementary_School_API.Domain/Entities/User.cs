using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elementary_School_API.Domain.SeedWorks.Base;

namespace Elementary_School_API.Domain.Entities
{
	public class User : EntityBase
	{
		
		public string? UserName { get; set; }

		public string? Password { get; set; }

	}
}
