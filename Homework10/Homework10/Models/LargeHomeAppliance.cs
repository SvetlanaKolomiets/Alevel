using Homework10.Enums;

namespace Homework10.Models
{
	public class LargeHomeAppliance : ElectricalAppliance
	{
		public SizeType Size { get; set; }

        public LargeHomeAppliance()
		{
			Size = SizeType.Large;
		}
	}
}

