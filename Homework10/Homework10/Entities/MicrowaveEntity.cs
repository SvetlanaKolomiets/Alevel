using Homework10.Enums;

namespace Homework10.Entities
{
	public class MicrowaveEntity : SmallHouseholdApplianceEntity
	{
        public double Capacity { get; set; }

        public MicrowaveEntity()
        {
            Size = SizeType.Small;
            ApplianceType = ApplianceType.Microwave;
        }
    }
}

