using Homework10.Enums;

namespace Homework10.Entities
{
	public class TelevisionEntity : LargeHomeApplianceEntity
    {
        public int ScreenDiagonal { get; set; }

        public TelevisionEntity()
        {
            Size = SizeType.Large;
            ApplianceType = ApplianceType.Television;
        }
    }
}

