namespace Homework23.Data.Entities
{
    public class PetEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }

        public CategoryEntity Category { get; set; }
        public int BreedId { get; set; }

        public BreedEntity Breed { get; set; }
        public int Age { get; set; }
        public int LocationId { get; set; }
        public LocationEntity Location { get; set; }
        public string? ImageUrl { get; set; }
        public string? Description { get; set; }
    }
}

