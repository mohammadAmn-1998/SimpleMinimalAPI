using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elementary_School_API.Domain.SeedWorks.Base
{
	public class EntityBase
	{

		public int Id { get; set; }

		public DateTime CreationDate { get; set; }

		public DateTime? UpdateDate { get; set; }

		public bool IsDeleted { get; set; }

	}
}
