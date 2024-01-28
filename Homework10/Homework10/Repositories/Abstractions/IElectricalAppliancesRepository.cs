using Homework10.Entities;

namespace Homework10.Repositories.Abstractions
{
	public interface IElectricalAppliancesRepository
	{
        ElectricalApplianceEntity[] GenerateElectricalAppliance();
        ElectricalApplianceEntity GetElectricalApplianceByIndex(int index);
    }
}

