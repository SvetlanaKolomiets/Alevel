using Homework10.Enums;

namespace Homework10.Models
{
	public class Kettle : SmallHouseholdAppliance
	{
        public double Capacity { get; set; }

        public Kettle(int powerConsumption, string name, bool isPluggedIn, double capacity)
        {
            PowerConsumption = powerConsumption;
            Name = name;
            IsPluggedIn = isPluggedIn;
            Size = SizeType.Small;
            Capacity = capacity;
            ApplianceType = ApplianceType.Kettle;
        }
    }
}

