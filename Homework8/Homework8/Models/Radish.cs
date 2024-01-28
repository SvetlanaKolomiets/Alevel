using Homework8.Enums;

namespace Homework8.Models
{
	public class Radish : RootVegetable
	{
        public double Calories { get; set; }

        public Radish(string name, int weight, ShapeType shape, string color, double calories) :
            base(name, weight, shape, color)
		{
            Calories = calories;
        }
	}
}

