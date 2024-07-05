namespace Homework21.Data.Entities
{
	public class BreedEntity
	{
		public int Id { get; set; }
		public string BreedName { get; set; }
		public int CategoryId { get; set; }

        public CategoryEntity Category { get; set; }
        public ICollection<PetEntity> Pet { get; set; }
    }
}

