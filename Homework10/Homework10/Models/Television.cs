using Homework10.Enums;

namespace Homework10.Models
{
	public class Television : LargeHomeAppliance
	{
		public int ScreenDiagonal { get; set; }

        public Television(int powerConsumption, string name, bool isPluggedIn, int screenDiagonal)
        {
            PowerConsumption = powerConsumption;
            Name = name;
            IsPluggedIn = isPluggedIn;
            Size = SizeType.Large;
            ScreenDiagonal = screenDiagonal;
            ApplianceType = ApplianceType.Television;
        }
    }
}

