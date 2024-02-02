using Homework10.Enums;

namespace Homework10.Entities
{
	public class WashingMachineEntity : LargeHomeApplianceEntity
	{
        public int NumberOfPrograms { get; set; }

        public WashingMachineEntity()
        {
            Size = SizeType.Large;
            ApplianceType = ApplianceType.WashingMachine;
        }
    }
}

