using Homework18.Dtos.Responses;

namespace Homework18.Services.Abstractions
{
	public interface IAuthenticationService
	{
        Task<RegisteredUserResponse> RegisterUser(string email, string password = null);
        Task<LoggedInUserResponse> LoginUser(string email, string password = null);
    }
}

