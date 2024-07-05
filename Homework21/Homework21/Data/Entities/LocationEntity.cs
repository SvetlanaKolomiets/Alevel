namespace Homework21.Data.Entities
{
	public class LocationEntity
	{
		public int Id { get; set; }
		public string LocationName { get; set; }

        public ICollection<PetEntity> Pet { get; set; }
    }
}

