namespace Homework21.Models
{
	public class Pet
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int BreedId { get; set; }
        public float Age { get; set; }
        public int LocationId { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}

