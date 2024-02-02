using Homework10.Models;
using Homework10.Services.Abstractions;
using Homework10.Enums;

namespace Homework10.ExtensionMethods
{
	public static class ElectricalApplianceExtension
	{
        public static ElectricalAppliance[] SortPowerConsumption(this IElectricalApplianceService electricalApplianceService)
        {
            var electricalAppliances = electricalApplianceService.GetElectricalAppliances();

            Array.Sort(electricalAppliances, (x, y) => y.PowerConsumption.CompareTo(x.PowerConsumption));

            return electricalAppliances;

        }

        public static void PrintSortedPowerConsumption(this IElectricalApplianceService electricalApplianceService)
        {
            var sortedPowerConsumpions = electricalApplianceService.SortPowerConsumption();

            Console.WriteLine("Sorting electrical appliances starting with the highest energy consumption:");

            foreach (var electricalAppliance in sortedPowerConsumpions)
            {
                Console.WriteLine($"{electricalAppliance.ApplianceType} {electricalAppliance.Name} " +
                    $"consume {electricalAppliance.PowerConsumption} KW");
            }
        }

        public static void SearchElectricalAppliances(this IElectricalApplianceService electricalApplianceService, int powerConsumption)
        {
            var electricalAppliances = electricalApplianceService.GetElectricalAppliances();
            var isElectricalApplianceFound = false;
            for (int element = 0; element < electricalAppliances.Length; element++)
            {
                if (electricalAppliances[element].PowerConsumption == powerConsumption)
                {
                    var electricalApplianceFound = electricalApplianceService.GetElectricalApplianceByNumber(element);
                    Console.WriteLine($"{electricalApplianceFound.ApplianceType} {electricalApplianceFound.Name}, " +
                        $"Power consumption: {electricalApplianceFound.PowerConsumption} KW");
                    isElectricalApplianceFound = true;
                }
            }

            if (!isElectricalApplianceFound)
            {
                Console.WriteLine($"Can't find electrical appliances");
            }
        }

        public static void SearchElectricalAppliances(this IElectricalApplianceService electricalApplianceService, ApplianceType applianceType)
        {
            var electricalAppliances = electricalApplianceService.GetElectricalAppliances();
            var isElectricalApplianceFound = false;
            for (int element = 0; element < electricalAppliances.Length; element++)
            {
                if (electricalAppliances[element].ApplianceType == applianceType)
                {
                    var electricalApplianceFound = electricalApplianceService.GetElectricalApplianceByNumber(element);
                    Console.WriteLine($"{electricalApplianceFound.ApplianceType} {electricalApplianceFound.Name}, " +
                        $"Power consumption: {electricalApplianceFound.PowerConsumption} KW");
                    isElectricalApplianceFound = true;
                }
            }

            if (!isElectricalApplianceFound)
            {
                Console.WriteLine($"Can't find electrical appliances");
            }
        }

        public static void SearchForAElectricalAppliance(this IElectricalApplianceService electricalApplianceService)
        {
            Console.WriteLine($"Enter electrical appliance's power consumption or type you want to find ");
            var searchInput = Console.ReadLine();
            if (int.TryParse(searchInput, out int searchNumber))
            {
                electricalApplianceService.SearchElectricalAppliances(searchNumber);
            }
            else if (Enum.TryParse<ApplianceType>(searchInput, out var applianceType))
            {
                electricalApplianceService.SearchElectricalAppliances(applianceType);
            }
            else
            {
                Console.WriteLine($"Invalid input. Please enter a valid number or appliance type.");
            }
            Console.ReadLine();
        }
    }
}

