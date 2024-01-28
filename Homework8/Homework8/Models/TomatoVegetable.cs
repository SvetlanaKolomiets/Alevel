using Homework8.Enums;

namespace Homework8.Models
{
	public class TomatoVegetable : Vegetable
	{
        public ShapeType Shape { get; set; }
        public string Color { get; set; }

        public TomatoVegetable(string name, int weight, ShapeType shape, string color) : base(name, weight)
        {
            Shape = shape;
            Color = color;
        }
	}
}

