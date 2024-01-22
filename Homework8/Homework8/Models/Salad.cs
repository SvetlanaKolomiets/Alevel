using Homework8.Enums;

namespace Homework8.Models
{
	public class Salad : LeafyVegetable
	{
        public double Calories { get; set; }

        public Salad(string name, int weight, SaladType saladType, string color, double calories) :
            base(name, weight, saladType, color)
        {
            Calories = calories;
		}
	}
}

