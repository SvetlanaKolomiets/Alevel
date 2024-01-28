using Homework8.Enums;

namespace Homework8.Models
{
	public class Beet : RootVegetable
	{
		public double Calories { get; set; }

		public Beet(string name, int weight, ShapeType shape, string color, double calories) :
			base(name, weight, shape, color)
        {
			Calories = calories;
		}
	}
}

