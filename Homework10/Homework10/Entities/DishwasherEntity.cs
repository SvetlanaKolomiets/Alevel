using Homework10.Enums;

namespace Homework10.Entities
{
	public class DishwasherEntity : LargeHomeApplianceEntity
	{
        public int NumberOfPrograms { get; set; }
        public int CapacityOfCookwareSets { get; set; }

        public DishwasherEntity()
        {
            Size = SizeType.Large;
            ApplianceType = ApplianceType.Dishwasher;
        }
    }
}

