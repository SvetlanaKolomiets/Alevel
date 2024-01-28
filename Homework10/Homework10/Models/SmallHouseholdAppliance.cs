using Homework10.Enums;

namespace Homework10.Models
{
	public class SmallHouseholdAppliance : ElectricalAppliance
	{
        public SizeType Size { get; set; }

        public SmallHouseholdAppliance()
		{
			Size = SizeType.Small;
		}
	}
}

