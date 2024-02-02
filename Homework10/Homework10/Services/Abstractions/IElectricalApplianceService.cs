using Homework10.Models;

namespace Homework10.Services.Abstractions
{
	public interface IElectricalApplianceService
	{
        void PrintElectricalAppliances();
        ElectricalAppliance GetElectricalApplianceByNumber(int number);
        ElectricalAppliance ChooseElectricalAppliance();
        ElectricalAppliance[] GetElectricalAppliances();
    }
}

