namespace Collection.Entities
{
	public class OrderEntity
	{
		public Guid Id { get; set; }
		public DateTime CreatedAt { get; set; }
		public bool IsEmergency { get; set; }
    }
}

