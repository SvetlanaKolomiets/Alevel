using Homework8.Enums;

namespace Homework8.Models
{
	public class Onion : OnionVegetable
	{
        public double Calories { get; set; }

        public Onion(string name, int weight, OnionType onionType, string color, double calories) :
            base(name, weight, onionType, color)
        {
            Calories = calories;
		}
	}
}

