using Homework10.Enums;

namespace Homework10.Models
{
	public class WashingMachine : LargeHomeAppliance
	{
		public int NumberOfPrograms { get; set; }

        public WashingMachine(int powerConsumption, string name, bool isPluggedIn, int numberOfPrograms)
        {
            PowerConsumption = powerConsumption;
            Name = name;
            IsPluggedIn = isPluggedIn;
            Size = SizeType.Large;
            NumberOfPrograms = numberOfPrograms;
            ApplianceType = ApplianceType.WashingMachine;
        }
    }
}

