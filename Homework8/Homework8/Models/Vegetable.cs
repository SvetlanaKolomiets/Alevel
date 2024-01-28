namespace Homework8.Models
{
	public abstract class Vegetable
	{
		public string Name { get; set; }
		public int Weight { get; set; }

		public Vegetable(string name, int weight)
		{
			Name = name;
			Weight = weight;
		}
	}
}

