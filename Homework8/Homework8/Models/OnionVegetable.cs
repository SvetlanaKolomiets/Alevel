using Homework8.Enums;

namespace Homework8.Models
{
	public class OnionVegetable : Vegetable
	{
        public OnionType OnionType { get; set; }
        public string Color { get; set; }

        public OnionVegetable(string name, int weight, OnionType onionType, string color) : base(name, weight)
        {
            OnionType = onionType;
            Color = color;
		}
	}
}

