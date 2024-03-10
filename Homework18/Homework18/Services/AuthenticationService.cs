using Homework18.Config;
using Homework18.Dtos.Requests;
using Homework18.Dtos.Responses;
using Homework18.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Homework18.Services
{
	public class AuthenticationService : IAuthenticationService
    {
        private readonly IInternalHttpClientService _httpClientService;
        private readonly ILogger<UserService> _logger;
        private readonly ApiOption _options;

        public AuthenticationService(
            IInternalHttpClientService httpClientService,
            IOptions<ApiOption> options,
            ILogger<UserService> logger)
		{
            _httpClientService = httpClientService;
            _logger = logger;
            _options = options.Value;
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

            if (result?.Id != null)
            {
                _logger.LogInformation($"User was registered with {result?.Id} id ");
            }
            else
            {
                _logger.LogInformation($"Registration was unsuccessful");
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

            if (!string.IsNullOrEmpty(result?.Token))
            {
                _logger.LogInformation($"User was logged in with {result?.Token} token ");
            }
            else
            {
                _logger.LogInformation($"Login was unsuccessful");
            }

            return result;
        }
    }
}

