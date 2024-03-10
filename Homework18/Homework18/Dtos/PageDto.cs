using Newtonsoft.Json;

namespace Homework18.Dtos
{
	public class PageDto
	{
        public int Page { get; set; }
        [JsonProperty(PropertyName = "per_page")]
        public int PerPage { get; set; }
        public int Total { get; set; }
        [JsonProperty(PropertyName = "total_pages")]
        public int TotalPages { get; set; }
    }
}

