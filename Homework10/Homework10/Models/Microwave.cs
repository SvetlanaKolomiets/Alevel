using Homework10.Enums;

namespace Homework10.Models
{
	public class Microwave : SmallHouseholdAppliance
	{
		public double Capacity { get; set; }

        public Microwave(int powerConsumption, string name, bool isPluggedIn, double capacity)
        {
            PowerConsumption = powerConsumption;
            Name = name;
            IsPluggedIn = isPluggedIn;
            Size = SizeType.Small;
            Capacity = capacity;
            ApplianceType = ApplianceType.Microwave;
        }
    }
}

