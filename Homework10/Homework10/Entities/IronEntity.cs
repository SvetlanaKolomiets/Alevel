using Homework10.Enums;

namespace Homework10.Entities
{
	public class IronEntity : SmallHouseholdApplianceEntity
	{
        public double CordLength { get; set; }

        public IronEntity()
        {
            Size = SizeType.Small;
            ApplianceType = ApplianceType.Iron;
        }
    }
}

