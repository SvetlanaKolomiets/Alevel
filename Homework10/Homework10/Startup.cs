using Homework10.ExtensionMethods;
using Homework10.Services.Abstractions;
namespace Homework10
{
	public class Startup
	{
		private readonly IElectricalApplianceService _electricalApplianceService;
		private readonly IPluggingInIntoASocketService _pluggingInIntoASocketService;

        public Startup(
			IElectricalApplianceService electricalApplianceService,
			IPluggingInIntoASocketService pluggingInIntoASocketService
			)
		{
			_electricalApplianceService = electricalApplianceService;
			_pluggingInIntoASocketService = pluggingInIntoASocketService;
        }

        public void Run()
		{
			_electricalApplianceService.PrintElectricalAppliances();
			_pluggingInIntoASocketService.PlugInElectricalAppliances();
            ElectricalApplianceExtension.PrintSortedPowerConsumption(_electricalApplianceService);
			ElectricalApplianceExtension.SearchForAElectricalAppliance(_electricalApplianceService);
        }

    }
}

