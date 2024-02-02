using Homework10.Enums;

namespace Homework10.Models
{
	public class Iron : SmallHouseholdAppliance
	{
		public double CordLength { get; set; }

        public Iron(int powerConsumption, string name, bool isPluggedIn, double cordLength)
        {
            PowerConsumption = powerConsumption;
            Name = name;
            IsPluggedIn = isPluggedIn;
            Size = SizeType.Small;
            CordLength = cordLength;
            ApplianceType = ApplianceType.Iron;
        }
    }
}

