using Homework10.Entities;
using Homework10.Models;
using Homework10.Repositories.Abstractions;
using Homework10.Services.Abstractions;
namespace Homework10.Services
{
	public class ElectricalApplianceService : IElectricalApplianceService
	{
		private IElectricalAppliancesRepository _electricalAppliancesRepository;
        private bool _userWantsToContinue = true;

        public ElectricalApplianceService(IElectricalAppliancesRepository electricalAppliancesRepository)
		{
			_electricalAppliancesRepository = electricalAppliancesRepository;
		}

        public void PrintElectricalAppliances()
		{
			var electricalAppliances = _electricalAppliancesRepository.GenerateElectricalAppliance();
            var number = 1;
			foreach (var electricalApplianceEntity in electricalAppliances)
			{
                var electricalAppliance = this.GetElectricalApplianceByNumber(number - 1);
                Console.Write($"{number} {electricalAppliance.ApplianceType} {electricalAppliance.Name}, " +
                    $"{electricalAppliance.PowerConsumption} kW ");

                switch (electricalAppliance)
                {
                    case Refrigerator refrigerator:
                        Console.Write($"Size: {refrigerator.Size}, Temperature inside: {refrigerator.TemperatureInside} degrees Celsius");
                        break;
                    case Television television:
                        Console.Write($"Size: {television.Size}, Screen diagonal: {television.ScreenDiagonal}''");
                        break;

                    case WashingMachine washingMachine:
                        Console.Write($"Size: {washingMachine.Size}, Number of programs: {washingMachine.NumberOfPrograms}");
                        break;

                    case Dishwasher dishwasher:
                        Console.Write($"Size: {dishwasher.Size}, Number of programs: {dishwasher.NumberOfPrograms}, Capacity of cookware sets: {dishwasher.CapacityOfCookwareSets} ");
                        break;

                    case Microwave microwave:
                        Console.Write($"Size: {microwave.Size}, Capacity: {microwave.Capacity} liters");
                        break;

                    case Kettle kettle:
                        Console.Write($"Size: {kettle.Size}, Capacity: {kettle.Capacity} liters");
                        break;

                    case Iron iron:
                        Console.Write($"Size: {iron.Size}, Cord length: {iron.CordLength} meters");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine();
                number++;
            }
        }

		public ElectricalAppliance GetElectricalApplianceByNumber (int number)
		{
            var electricalAppliances = _electricalAppliancesRepository.GenerateElectricalAppliance();
			if (number >= 0 && number < electricalAppliances.Length)
            {
				var electricalApplianceEntity = _electricalAppliancesRepository.GetElectricalApplianceByIndex(number);
				switch (electricalApplianceEntity)
				{
					case RefrigeratorEntity refrigerator:
						return new Refrigerator(
                            refrigerator.PowerConsumption,
                            refrigerator.Name,
                            refrigerator.IsPluggedIn,
							refrigerator.TemperatureInside
                            );
                    case TelevisionEntity television:
                        return new Television(
                            television.PowerConsumption,
                            television.Name,
                            television.IsPluggedIn,
                            television.ScreenDiagonal
                        );
                    case WashingMachineEntity washingMachine:
                        return new WashingMachine(
                            washingMachine.PowerConsumption,
                            washingMachine.Name,
                            washingMachine.IsPluggedIn,
                            washingMachine.NumberOfPrograms
                        );
                    case DishwasherEntity dishwasher:
                        return new Dishwasher(
                            dishwasher.PowerConsumption,
                            dishwasher.Name,
                            dishwasher.IsPluggedIn,
                            dishwasher.NumberOfPrograms,
                            dishwasher.CapacityOfCookwareSets
                        );
                    case MicrowaveEntity microwave:
                        return new Microwave(
                            microwave.PowerConsumption,
                            microwave.Name,
                            microwave.IsPluggedIn,
                            microwave.Capacity
                        );
                    case KettleEntity kettle:
                        return new Kettle(
                            kettle.PowerConsumption,
                            kettle.Name,
                            kettle.IsPluggedIn,
                            kettle.Capacity
                        );
                    case IronEntity iron:
                        return new Iron(
                            iron.PowerConsumption,
                            iron.Name,
                            iron.IsPluggedIn,
                            iron.CordLength
                        );
                    default:
                        return null;

                }

            }

            return null;
        }
        

        public ElectricalAppliance[] GetElectricalAppliances()
        {
            var electricalAppliancesLength = _electricalAppliancesRepository.GenerateElectricalAppliance().Length;
            ElectricalAppliance[] electricalAppliances = new ElectricalAppliance[electricalAppliancesLength];

            for (int i = 0; i < electricalAppliances.Length; i++)
            {
                electricalAppliances[i] = GetElectricalApplianceByNumber(i);
            }

            return electricalAppliances;
        }

        public ElectricalAppliance ChooseElectricalAppliance()
        {
            var electricalAppliances = _electricalAppliancesRepository.GenerateElectricalAppliance();

            Console.WriteLine($"Choose electrical appliance you want to plug in into a socket or press 'Q' for exit");
            var input = Console.ReadLine();
            while (_userWantsToContinue)
            {
                if (int.TryParse(input, out int inputNumber) && inputNumber <= electricalAppliances.Length
                    && inputNumber > 0)
                {
                    var electricalAppliance = this.GetElectricalApplianceByNumber(inputNumber - 1);
                    return electricalAppliance;
                }
                else if (input.ToUpper() == "Q")
                {
                    _userWantsToContinue = false;
                }
                else if (inputNumber >= electricalAppliances.Length || inputNumber < 1)
                {
                    Console.WriteLine($"Invalid electrical appliance number. Please try again or press 'Q' for exit.");
                    input = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"The entered value was not a number. Try again or press 'Q' for exit.");
                    input = Console.ReadLine();
                }
            }

            return null;
        }



    }
}

