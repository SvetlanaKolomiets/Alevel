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
				object>($"{_options.Host}{Constants.UserUrl}{id}", HttpMethod.Get);

			if (result?.Data != null)
			{
				_logger.LogInformation($"User with id = {result?.Data.Id} was found");
			}
            else
            {
                _logger.LogInformation($"User with id = {id} was not found");
            }

			return result?.Data;
        }

        public async Task<UserDto[]> GetUserListByPage(int pageNumber)
        {
            var result = await _httpClientService.SendAsync<BaseResponse<UserDto[]>,
                object>($"{_options.Host}api/users?page={pageNumber}", HttpMethod.Get);

            if (result?.Data != null)
            {
                _logger.LogInformation($"{result.Total} users were created");
            }

            return result?.Data;
        }

        public async Task<UserResponse> CreateUser(string name, string job)
        {
			var result = await _httpClientService.SendAsync<UserResponse, UserRequest>(
				$"{_options.Host}{Constants.UserUrl}",
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

        

        public async Task<UpdatedUserResponse> UpdateUserByPut(int id, string name, string job)
        {
            var result = await _httpClientService.SendAsync<UpdatedUserResponse, UserRequest>(
                $"{_options.Host}{Constants.UserUrl}{id}",
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

        public async Task<UpdatedUserResponse> UpdateUserByPatch(int id, string name, string job)
        {
            var result = await _httpClientService.SendAsync<UpdatedUserResponse, UserRequest>(
                $"{_options.Host}{Constants.UserUrl}{id}",
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
                object>($"{_options.Host}{Constants.UserUrl}{id}", HttpMethod.Delete);

            if (result == null)
            {
                _logger.LogInformation($"User with id = {id} was deleted");
            }

            return default;
        }

        public async Task<UserDto[]> GetUserListWithDelay(int delay)
        {
            var result = await _httpClientService.SendAsync<BaseResponse<UserDto[]>,
                object>($"{_options.Host}api/users?delay={delay}", HttpMethod.Get);

            if (result?.Data != null)
            {
                _logger.LogInformation($"{result.Total} users were created");
            }

            return result?.Data;
        }
    }
}

