using Homework7.Enums;

namespace Homework7.Models
{
	public class ChocolateСandy : Candy
	{
		public ChocolateType ChocolateType { get; set; }

		public ChocolateСandy(string name, int weight, FormType form, ChocolateType chocolateType) : base(name, weight, form)
        {
            ChocolateType = chocolateType;
		}
       
    }
}
