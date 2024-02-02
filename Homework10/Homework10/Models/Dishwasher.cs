using Homework10.Enums;

namespace Homework10.Models
{
	public class Dishwasher : LargeHomeAppliance
	{
		public int NumberOfPrograms { get; set; }
		public int CapacityOfCookwareSets { get; set; }

        public Dishwasher(int powerConsumption, string name, bool isPluggedIn, int numberOfPrograms, int capacityOfCookwareSets)
        {
            PowerConsumption = powerConsumption;
            Name = name;
            IsPluggedIn = isPluggedIn;
            Size = SizeType.Large;
            NumberOfPrograms = numberOfPrograms;
            CapacityOfCookwareSets = capacityOfCookwareSets;
            ApplianceType = ApplianceType.Dishwasher;
        }
    }
}

