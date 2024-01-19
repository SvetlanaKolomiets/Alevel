using Homework7.Enums;

namespace Homework7.Models
{
	public class CookieWithFilling : Сookie
    {
        public FillingType Filling { get; set; }

        public CookieWithFilling(string name, int weight, FormType form, FillingType filling) : base(name, weight, form)
        {
            Filling = filling;
        }
    }
}

