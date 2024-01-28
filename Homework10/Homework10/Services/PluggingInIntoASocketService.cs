using Homework10.Models;
using Homework10.Services.Abstractions;
namespace Homework10.Services
{
	public class PluggingInAppliancesService : IPluggingInIntoASocketService
	{
		private IElectricalApplianceService _electricalApplianceService;
        private ElectricalAppliance[] _pluggedInElectricalAppliances = new ElectricalAppliance[0];
        private int _pluggedInApplianceNumber = 0;
        private bool _userWantsToContinue = true;
        private ElectricalAppliance _electricalAppliance;

        public PluggingInAppliancesService(IElectricalApplianceService electricalApplianceService)
		{
			_electricalApplianceService = electricalApplianceService;
        }

        public ElectricalAppliance ChooseElectricalAppliance()
        {
            var _electricalAppliance = _electricalApplianceService.ChooseElectricalAppliance();
            return _electricalAppliance;
        }

        public bool CheckIfUserWantToContinue()
        {
            if (_electricalAppliance == null || _electricalAppliance == default)
            {
                _userWantsToContinue = false;
            }
            return _userWantsToContinue;
        }

        public ElectricalAppliance[] PlugInElectricalAppliances()
        {
            var maxQuantityOfAppliances = _electricalApplianceService.GetElectricalAppliances().Length;
            var pluggedInApplianceQuantity = 0;
            var totalPowerConsumption = 0;
            Console.WriteLine($"What electrical appliance do you like to plug in? " +
                $"Maximum quantity of plugged in electrical appliances could be {maxQuantityOfAppliances} {Environment.NewLine}");
            while (_userWantsToContinue && pluggedInApplianceQuantity < maxQuantityOfAppliances)
            {
                _electricalAppliance = this.ChooseElectricalAppliance();
                var isApplianceAlreadyPluggedIn = this.IsApplianceAlreadyPluggedIn(_electricalAppliance);

                if (_electricalAppliance != null && pluggedInApplianceQuantity <= maxQuantityOfAppliances && !isApplianceAlreadyPluggedIn)
                {
                    AddToAPluggedInAppliances(_electricalAppliance);
                    pluggedInApplianceQuantity++;
                    totalPowerConsumption += _electricalAppliance.PowerConsumption;
                    Console.WriteLine($"You plugged in: {pluggedInApplianceQuantity} appliances and " +
                        $"using power consumption {totalPowerConsumption} kilowatt in total " +
                        $"(You can plug in: {maxQuantityOfAppliances - pluggedInApplianceQuantity} more appliances){Environment.NewLine}");
                }
                else
                {
                    if (_electricalAppliance == null)
                    {
                        return null;
                    }
                    else if (isApplianceAlreadyPluggedIn)
                    {
                        Console.WriteLine("This appliance is already plugged in. Choose another appliance");
                    }
                }

                _userWantsToContinue = CheckIfUserWantToContinue();
            }

            return _pluggedInElectricalAppliances;
        }

        public bool IsApplianceAlreadyPluggedIn(ElectricalAppliance electricalAppliance)
        {
            bool isAlreadyPluggedIn = false;

            foreach (var pluggedInAppliance in _pluggedInElectricalAppliances)
            {
                if (electricalAppliance != null && pluggedInAppliance.ApplianceType == electricalAppliance.ApplianceType)
                {
                    isAlreadyPluggedIn = true;
                    break;
                }
            }

            return isAlreadyPluggedIn;
        }

        public void AddToAPluggedInAppliances(ElectricalAppliance electricalAppliance)
        {
            Array.Resize(ref _pluggedInElectricalAppliances, _pluggedInElectricalAppliances.Length + 1);
            _pluggedInElectricalAppliances[_pluggedInApplianceNumber] = electricalAppliance;
            _pluggedInElectricalAppliances[_pluggedInApplianceNumber].IsPluggedIn = true;
            _pluggedInApplianceNumber++;
        }
    }
}

