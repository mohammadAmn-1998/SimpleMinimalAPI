using Elementary_School_API.Domain.DTOs.User;

namespace Elementary_School_API.BLL.Services.Interfaces;

public interface IUserService
{

	Task<int> CreateUserAsync(UserDto dto);

	Task<bool> CheckUserNameExists(string userName);

	Task<UserDto?> GetUserByUserNameAndPassword(string userName, string password);




}