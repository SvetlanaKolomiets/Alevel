using Homework10.Entities;
using Homework10.Repositories.Abstractions;
namespace Homework10.Repositories
{
	public class ElectricalAppliancesRepository : IElectricalAppliancesRepository
	{
		private ElectricalApplianceEntity[] _electricalAppliances = new ElectricalApplianceEntity[7];

        public ElectricalApplianceEntity[] GenerateElectricalAppliance()
        {
            _electricalAppliances[0] = new RefrigeratorEntity()
            {
                PowerConsumption = 55,
                Name = "Bosch",
                IsPluggedIn = false,
                TemperatureInside = 6
            };
            _electricalAppliances[1] = new TelevisionEntity()
            {
                PowerConsumption = 22,
                Name = "Samsung",
                IsPluggedIn = false,
                ScreenDiagonal = 55
            };
            _electricalAppliances[2] = new WashingMachineEntity()
            {
                PowerConsumption = 4,
                Name = "LG",
                IsPluggedIn = false,
                NumberOfPrograms = 10
            };
            _electricalAppliances[3] = new DishwasherEntity()
            {
                PowerConsumption = 2,
                Name = "Whirlpool",
                IsPluggedIn = false,
                NumberOfPrograms = 6,
                CapacityOfCookwareSets = 14
            };
            _electricalAppliances[4] = new MicrowaveEntity()
            {
                PowerConsumption = 3,
                Name = "Panasonic",
                IsPluggedIn = false,
                Capacity = 20
            };
            _electricalAppliances[5] = new KettleEntity()
            {
                PowerConsumption = 4,
                Name = "Bosch",
                IsPluggedIn = false,
                Capacity = 1.7
            };
            _electricalAppliances[6] = new IronEntity()
            {
                PowerConsumption = 7,
                Name = "Tefal",
                IsPluggedIn = false,
                CordLength = 1.5
            };

            return _electricalAppliances;
        }

        public ElectricalApplianceEntity GetElectricalApplianceByIndex(int index)
        {
            if(index >= 0 && index < _electricalAppliances.Length)
            {
                return _electricalAppliances[index];
            }

            return null;
        }
    }
}

