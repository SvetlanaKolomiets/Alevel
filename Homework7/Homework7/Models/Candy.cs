using Homework7.Enums;

namespace Homework7.Models
{
	public class Candy : Sweet
	{
		public FormType Form { get; set; }

		public Candy(string name, int weight, FormType form) : base(name, weight)
		{
			Form = form;
		}
	}
}
