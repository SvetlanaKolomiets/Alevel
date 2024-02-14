namespace Collection.Models
{
	public class Order : IComparable<Order>
	{
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsEmergency { get; set; }

        public int CompareTo(Order? otherOrder)
        {
            if (otherOrder == null)
            {
                return 1;
            }

            if (this.IsEmergency && !otherOrder.IsEmergency)
            {
                return -1;
            }
            else if (!this.IsEmergency && otherOrder.IsEmergency)
            {
                return 1;
            }
            return CreatedAt.CompareTo(otherOrder?.CreatedAt);
        }

        public override string ToString()
        {
            return $"Order id: {Id} was created at {CreatedAt}. Is order emergency: {IsEmergency}";
        }
    }
}

