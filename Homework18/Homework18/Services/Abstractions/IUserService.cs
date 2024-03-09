using Homework18.Dtos;
using Homework18.Dtos.Responses;
namespace Homework18.Services.Abstractions
{
	public interface IUserService
	{
		Task<UserDto> GetUserById(int id);
		Task<UserResponse> CreateUser(string name, string job);
        Task<List<UserDto>> GetUserListByPage(int pageNumber);
		Task<List<ResourceDto>> GetResourceList();
		Task<ResourceDto> GetResourceById(int id);
		Task<UpdateUserResponse> UpdateUserByPut(int id, string name, string job);
		Task<UpdateUserResponse> UpdateUserByPatch(int id, string name, string job);
		Task<UserDto> DeleteUserById(int id);
		Task<RegisteredUserResponse> RegisterUser(string email, string password = null);
		Task<LoggedInUserResponse> LoginUser(string email, string password = null);
		Task<List<UserDto>> GetUserListWithDelay(int delay);
    }
}

