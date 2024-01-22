using Homework8.Services;

namespace Homework8.ExtensionMethods
{
    public static class VegetableExtension
    {
        public static void SearchVegetables(this VegetableService vegetableService, int weight)
        {
            var vegetables = vegetableService.GenerateVegetables();
            var isVegetableFound = false;
            for (int element = 0; element < vegetables.Length; element++)
            {
                if (vegetables[element].Weight == weight)
                {
                    var foundVegetable = vegetableService.GetVegetableByNumber(element);
                    Console.WriteLine($"Name: {foundVegetable.Name} Weight: {foundVegetable.Weight}");
                    isVegetableFound = true;
                }
            }

            if (!isVegetableFound)
            {
                Console.WriteLine($"Can't find vegetables");
            }
        }

        public static void SearchVegetables(this VegetableService vegetableService, string name)
        {
            var vegetables = vegetableService.GenerateVegetables();
            var isVegetableFound = false;
            for (int element = 0; element < vegetables.Length; element++)
            {
                if (vegetables[element].Name == name)
                {
                    var foundVegetable = vegetableService.GetVegetableByNumber(element);
                    Console.WriteLine($"Name: {foundVegetable.Name} Weight: {foundVegetable.Weight}");
                    isVegetableFound = true;
                }
            }

            if (!isVegetableFound)
            {
                Console.WriteLine($"Can't find vegetables");
            }
        }
        
    }

}

