using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elementary_School_API.BLL.Services.Interfaces;
using Elementary_School_API.BLL.Services.SeedWorks.Base;
using Elementary_School_API.Domain.DTOs.User;
using Elementary_School_API.Domain.Entities;
using Elementary_School_API.Domain.Interfaces;
using Elementary_School_API.Infrastructure.Repositories.Interfaces;
using Microsoft.Identity.Client;

namespace Elementary_School_API.BLL.Services.Impeliments
{
	public class UserService : Service<User> , IUserService
	{
		private IUserRepository repository;

		public UserService(IUserRepository repository) : base(repository)
		{
			this.repository = repository;
		}


		public async Task<int> CreateUserAsync(UserDto dto)
		{
			 return await repository.CreateAsync(new User
			{
				Id = 0,
				CreationDate = DateTime.Now,
				UpdateDate = null,
				IsDeleted = false,
				UserName = dto.UserName,
				Password = dto.Password
			});
		}

		public async Task<bool> CheckUserNameExists(string userName)
		{
			var users = await repository.GetAllAsync(false);

			return users != null && users!.Any(u => u.UserName == userName);
		}

		public async Task<UserDto?> GetUserByUserNameAndPassword(string userName, string password)
		{
			var users = await repository.GetAllAsync(false);

			var currentUser = users?.FirstOrDefault(u => u.UserName == userName && u.Password == password);

			if(currentUser == null) return null;

			return new UserDto
			{
				Id = currentUser.Id,
				UserName = currentUser.UserName,
				Password = currentUser.Password,
				CreationTime = currentUser.CreationDate,
				UpdateTime = currentUser.UpdateDate,
				IsDeleted = currentUser.IsDeleted
			};

		}
	}
}
