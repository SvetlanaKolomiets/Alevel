using Homework7.Enums;

namespace Homework7.Models
{
	public class Сookie : Sweet
    {
        public FormType Form { get; set; }

        public Сookie(string name, int weight, FormType form) : base(name, weight)
        {
            Form = form;
        }
    }
}

