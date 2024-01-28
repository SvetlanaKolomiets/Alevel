using Homework10.Enums;

namespace Homework10.Models
{
	public class ElectricalAppliance
	{
		public int PowerConsumption { get; set; }
		public string Name { get; set; }
		public bool IsPluggedIn { get; set; }
		public ApplianceType ApplianceType { get; set; }
	}
}

