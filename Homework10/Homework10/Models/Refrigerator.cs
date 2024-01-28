using Homework10.Enums;

namespace Homework10.Models
{
	public class Refrigerator : LargeHomeAppliance
	{
        public int TemperatureInside { get; set; }

        public Refrigerator(int powerConsumption, string name, bool isPluggedIn, int temperatureInside)
        {
            PowerConsumption = powerConsumption;
            Name = name;
            IsPluggedIn = isPluggedIn;
            Size = SizeType.Large;
            TemperatureInside = temperatureInside;
            ApplianceType = ApplianceType.Refrigerator;
        }
    }
}

