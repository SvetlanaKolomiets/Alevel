using Homework18.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Homework18.Config;
using Homework18.Dtos;
using Homework18.Dtos.Responses;
using Homework18.Dtos.Requests;
namespace Homework18.Services
{
	public class UserService : IUserService
	{
		private readonly IInternalHttpClientService _httpClientService;
		private readonly ILogger<UserService> _logger;
		private readonly ApiOption _options;
		private readonly string _userApi = "api/users/";
        private readonly string _unknownApi = "api/unknown/";

        public UserService(
			IInternalHttpClientService httpClientService,
			IOptions<ApiOption> options,
			ILogger<UserService> logger)
		{
			_httpClientService = httpClientService;
			_logger = logger;
			_options = options.Value;
        }

		public async Task<UserDto> GetUserById(int id)
        {
			var result = await _httpClientService.SendAsync<BaseResponse<UserDto>,
				object>($"{_options.Host}{_userApi}{id}", HttpMethod.Get);

			if (result?.Data != null)
			{
				_logger.LogInformation($"User with id = {result?.Data.Id} was created");
			}

			return result?.Data;
        }

        public async Task<List<UserDto>> GetUserListByPage(int pageNumber)
        {
            var result = await _httpClientService.SendAsync<ListUserResponse,
                object>($"{_options.Host}api/users?page={pageNumber}", HttpMethod.Get);

            if (result?.Users != null)
            {
                _logger.LogInformation($"{result.Total} users were created");
            }

            return result?.Users;
        }

        public async Task<UserResponse> CreateUser(string name, string job)
        {
			var result = await _httpClientService.SendAsync<UserResponse, UserRequest>(
				$"{_options.Host}{_userApi}",
				HttpMethod.Post,
				new UserRequest()
				{
					Job = job,
					Name = name
				});

			if (result != null)
			{
				_logger.LogInformation($"User with id = {result?.Id} was created");
			}

			return result;
        }

        public async Task<List<ResourceDto>> GetResourceList()
        {
            var result = await _httpClientService.SendAsync<ListResourceResponse,
                object>($"{_options.Host}{_unknownApi}", HttpMethod.Get);

            if (result?.Resources != null)
            {
                _logger.LogInformation($"{result.Total} resources were created");
            }

            return result?.Resources;
        }

        public async Task<ResourceDto> GetResourceById(int id)
        {
            var result = await _httpClientService.SendAsync<BaseResponse<ResourceDto>,
                object>($"{_options.Host}{_unknownApi}{id}", HttpMethod.Get);

            if (result?.Data != null)
            {
                _logger.LogInformation($"Resource with id = {result?.Data.Id} was created");
            }

            return result?.Data;
        }

        public async Task<UpdateUserResponse> UpdateUserByPut(int id, string name, string job)
        {
            var result = await _httpClientService.SendAsync<UpdateUserResponse, UserRequest>(
                $"{_options.Host}{_userApi}{id}",
                HttpMethod.Put,
                new UserRequest()
                {
                    Job = job,
                    Name = name
                });

            if (result != null)
            {
                _logger.LogInformation($"{result.Name} job was updated on {result.Job} by PUT");
            }

            return result;
        }

        public async Task<UpdateUserResponse> UpdateUserByPatch(int id, string name, string job)
        {
            var result = await _httpClientService.SendAsync<UpdateUserResponse, UserRequest>(
                $"{_options.Host}{_userApi}{id}",
                HttpMethod.Patch,
                new UserRequest()
                {
                    Job = job,
                    Name = name
                });

            if (result != null)
            {
                _logger.LogInformation($"{result.Name} job was updated on {result.Job} by PATCH");
            }

            return result;
        }

        public async Task<UserDto> DeleteUserById(int id)
        {
            var result = await _httpClientService.SendAsync<object,
                object>($"{_options.Host}{_userApi}{id}", HttpMethod.Delete);

            if (result == null)
            {
                _logger.LogInformation($"User with id = {id} was deleted");
            }

            return default;
        }

        public async Task<RegisteredUserResponse> RegisterUser(string email, string password = null)
        {
            var result = await _httpClientService.SendAsync<RegisteredUserResponse, AuthenticatedUserRequest>(
                $"{_options.Host}api/register",
                HttpMethod.Post,
                new AuthenticatedUserRequest()
                {
                    Email = email,
                    Password = password
                });

            if (result != null)
            {
                _logger.LogInformation($"User was registered with {result?.Id} id ");
            }

            return result;
        }

        public async Task<LoggedInUserResponse> LoginUser(string email, string password = null)
        {
            var result = await _httpClientService.SendAsync<LoggedInUserResponse, AuthenticatedUserRequest>(
                $"{_options.Host}api/login",
                HttpMethod.Post,
                new AuthenticatedUserRequest()
                {
                    Email = email,
                    Password = password
                });

            if (result != null)
            {
                _logger.LogInformation($"User was logged in with {result?.Token} token ");
            }

            return result;
        }

        public async Task<List<UserDto>> GetUserListWithDelay(int delay)
        {
            var result = await _httpClientService.SendAsync<ListUserResponse,
                object>($"{_options.Host}api/users?delay={delay}", HttpMethod.Get);

            if (result?.Users != null)
            {
                _logger.LogInformation($"{result.Total} users were created");
            }

            return result?.Users;
        }
    }
}

