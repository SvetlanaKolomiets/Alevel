using Homework18.Config;
using Homework18.Dtos;
using Homework18.Dtos.Responses;
using Homework18.Services.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Homework18.Services
{
	public class ResourceService : IResourceService
    {
        private readonly IInternalHttpClientService _httpClientService;
        private readonly ILogger<UserService> _logger;
        private readonly ApiOption _options;

        public ResourceService(
            IInternalHttpClientService httpClientService,
            IOptions<ApiOption> options,
            ILogger<UserService> logger)
		{
            _httpClientService = httpClientService;
            _logger = logger;
            _options = options.Value;
        }

        public async Task<ResourceDto[]> GetResourceList()
        {
            var result = await _httpClientService.SendAsync<BaseResponse<ResourceDto[]>,
                object>($"{_options.Host}{Constants.UnknownApi}", HttpMethod.Get);

            if (result?.Data != null)
            {
                _logger.LogInformation($"{result.Total} resources were created");
            }

            return result?.Data;
        }

        public async Task<ResourceDto> GetResourceById(int id)
        {
            var result = await _httpClientService.SendAsync<BaseResponse<ResourceDto>,
                object>($"{_options.Host}{Constants.UnknownApi}{id}", HttpMethod.Get);

            if (result?.Data != null)
            {
                _logger.LogInformation($"Resource with id = {result?.Data.Id} was found");
            }
            else
            {
                _logger.LogInformation($"Resource with id = {id} was not found");
            }

            return result?.Data;
        }
    }
}

