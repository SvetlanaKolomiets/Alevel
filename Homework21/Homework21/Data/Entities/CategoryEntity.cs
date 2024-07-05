namespace Homework21.Data.Entities
{
	public class CategoryEntity
	{
		public int Id { get; set; }
		public string CategoryName { get; set; }

        public ICollection<PetEntity> Pet { get; set; }
        public ICollection<BreedEntity> Breeds { get; set; }
    }
}

