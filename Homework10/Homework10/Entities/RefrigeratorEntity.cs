using Homework10.Enums;

namespace Homework10.Entities
{
	public class RefrigeratorEntity : LargeHomeApplianceEntity
	{
        public int TemperatureInside { get; set; }

        public RefrigeratorEntity()
        {
            Size = SizeType.Large;
            ApplianceType = ApplianceType.Refrigerator;
        }
    }
}

