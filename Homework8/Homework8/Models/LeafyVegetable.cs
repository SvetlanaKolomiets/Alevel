using Homework8.Enums;

namespace Homework8.Models
{
	public class LeafyVegetable : Vegetable
	{
        public SaladType SaladType { get; set; }
        public string Color { get; set; }

        public LeafyVegetable(string name, int weight, SaladType saladType, string color) : base(name, weight)
        {
            SaladType = saladType;
            Color = color;
		}
	}
}

