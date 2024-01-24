namespace Homework7.Models
{
	public abstract class Sweet
	{
        public string Name { get; set; }
        public int Weight { get; set; }

        protected Sweet(string name, int weight)
		{
			Name = name;
			Weight = weight;
		}

		
	}
}

