using Homework18.Dtos;
using Homework18.Dtos.Responses;
namespace Homework18.Services.Abstractions
{
	public interface IUserService
	{
		Task<UserDto> GetUserById(int id);
        Task<UserResponse> CreateUser(string name, string job);
		Task<UserDto[]> GetUserListByPage(int pageNumber);
        Task<UpdatedUserResponse> UpdateUserByPut(int id, string name, string job);
		Task<UpdatedUserResponse> UpdateUserByPatch(int id, string name, string job);
		Task<UserDto> DeleteUserById(int id);
        Task<UserDto[]> GetUserListWithDelay(int delay);
    }
}

