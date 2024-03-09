using Newtonsoft.Json;

namespace Homework18.Dtos.Requests
{
	public class AuthenticatedUserRequest
	{
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}

