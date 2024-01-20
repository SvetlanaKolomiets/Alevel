using Homework7.Models;
using Homework7.Services;
namespace Homework7.ExtensionMethods
{
    public static class GiftExtension 
    {
        public static int[] CompareTo(this GiftService giftService)
        {
            var gifts = giftService.CreateAGift();
            int[] arrayForSorting = new int[gifts.Length];
            int index = 0;
            foreach (Sweet gift in gifts)
            {
                arrayForSorting[index] = gift.Weight;
                index++;
            }
            Array.Sort(arrayForSorting);
            return arrayForSorting;
        }

        public static void PrintSortedWeights(this GiftService giftService)
        {
            var sortedWeights = giftService.CompareTo();

            Console.WriteLine("Sorted weights:");

            foreach (var weight in sortedWeights)
            {
                Console.WriteLine(weight);
            }
        }
    }
}
