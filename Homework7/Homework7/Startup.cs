using Homework7.Services;
using Homework7.Repositories;
using Homework7.ExtensionMethods;

namespace Homework7
{
    public class Startup
    {
        private SweetService _sweetService;
        private GiftService _giftService;
        private ISearch _searchService;
        public Startup()
        {
            _sweetService = new SweetService(new SweetsRepository());
            _giftService = new GiftService(_sweetService);
        }

        private void ChooseSearchService()
        {
            Console.WriteLine("Choose 'S' for searching in sweets or 'G' for searching in the gift");
            var userInput = Console.ReadLine();

            switch (userInput.ToUpper())
            {
                case "S":
                    _searchService = _sweetService;
                    break;
                case "G":
                    _searchService = _giftService;
                    break;
                default:
                    _searchService = null;
                    break;
            }
        }

        private void SearchForASweet()
        {
            if (_searchService != null)
            {
                Console.WriteLine($"Enter candy weight or name you want to find ");
                var searchInput = Console.ReadLine();
                if (int.TryParse(searchInput, out int searchNumber))
                {
                    _searchService.SearchSweets(searchNumber);
                }
                else
                {
                    _searchService.SearchSweets(searchInput);
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'S' or 'G'.");
                ChooseSearchService();

            }
        }

        public void Run()
        {
            _sweetService.PrintSweet();
            GiftExtension.PrintSortedWeights(_giftService);
            this.ChooseSearchService();
            this.SearchForASweet();
            Console.ReadLine();
        }
    }
}

