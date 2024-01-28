using Homework10.Models;

namespace Homework10.Services.Abstractions
{
	public interface IPluggingInIntoASocketService
	{
        ElectricalAppliance ChooseElectricalAppliance();
        bool CheckIfUserWantToContinue();
        ElectricalAppliance[] PlugInElectricalAppliances();
        void AddToAPluggedInAppliances(ElectricalAppliance electricalAppliance);
        bool IsApplianceAlreadyPluggedIn(ElectricalAppliance electricalAppliance);
    }
}

