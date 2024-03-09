using Newtonsoft.Json;

namespace Homework18.Dtos.Responses
{
	public class ListResourceResponse
	{
        [JsonProperty(PropertyName = "page")]
        public string Page { get; set; }
        [JsonProperty(PropertyName = "per_page")]
        public string PerPage { get; set; }
        [JsonProperty(PropertyName = "total")]
        public string Total { get; set; }
        [JsonProperty(PropertyName = "total_pages")]
        public string TotalPages { get; set; }
        [JsonProperty(PropertyName = "data")]
        public List<ResourceDto> Resources { get; set; }
    }
}

