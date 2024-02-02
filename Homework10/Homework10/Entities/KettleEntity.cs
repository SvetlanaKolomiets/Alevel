using Homework10.Enums;

namespace Homework10.Entities
{
	public class KettleEntity : SmallHouseholdApplianceEntity
	{
        public double Capacity { get; set; }

        public KettleEntity()
        {
            Size = SizeType.Small;
            ApplianceType = ApplianceType.Kettle;
        }
    }
}

