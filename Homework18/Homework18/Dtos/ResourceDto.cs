using Newtonsoft.Json;

namespace Homework18.Dtos
{
	public class ResourceDto
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public string Color { get; set; }
        [JsonProperty(PropertyName = "pantone_value")]
        public string Pantone { get; set; }
    }
}

