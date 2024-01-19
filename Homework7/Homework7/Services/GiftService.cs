using Homework7.Models;
namespace Homework7.Services
{
	public class GiftService : ISearch
    {
		private SweetService _sweetService;
        private Sweet[] _gift = new Sweet[0];
        private int _sweetsInAGift = 0;
        public GiftService(SweetService sweetService)
		{
			_sweetService = sweetService;
		}

        public Sweet[] CreateAGift()
        {
            int maxWeight = 200;
            int giftWeight = 0;

            do
            {
                var sweet = _sweetService.ChooseSweet();
                var sweetQuantity = _sweetService.SweetQuantity();
                if (sweet == null || sweetQuantity == 0)
                {
                    return _gift;
                }
                var totalWeight = sweet.Weight * sweetQuantity;

                if (sweet != null && totalWeight + giftWeight <= maxWeight)
                {
                    AddToGift(sweet, sweetQuantity);
                    giftWeight += totalWeight;
                    Console.WriteLine($"In your gift: {giftWeight} g (Remaining space: {maxWeight - giftWeight} g)");
                }
                else if (sweet == null)
                {
                    return null;
                }
                else
                {
                    Console.WriteLine("Adding this sweet exceeds the maximum weight. Please choose another sweet.");
                }

            } while (giftWeight < maxWeight);

            return _gift;
        }

        private void AddToGift(Sweet sweet, int quantity)
        {
            Array.Resize(ref _gift, _gift.Length + quantity);
            for (int element = 0; element < quantity; element++)
            {
                _gift[_sweetsInAGift] = sweet;
                _sweetsInAGift++;
            }
        }


        private Sweet GetSweetInGifts(int index)
        {
            if (index >= 0 && index < _gift.Length)
            {
                return _gift[index];
            }
            return null;
        }

        public void SearchSweets(int weight)
        {
            var isSweetFound = false;
            for (int element = 0; element < _gift.Length; element++)
            {
                if (_gift[element].Weight == weight)
                {
                    var foundSweet = GetSweetInGifts(element);
                    Console.WriteLine($"Name: {foundSweet.Name} Weight: {foundSweet.Weight} g");
                    isSweetFound = true;
                }
            }

            if (!isSweetFound)
            {
                Console.WriteLine($"Can't find sweets");
            }
        }

        public void SearchSweets(string name)
        {
            var isSweetFound = false;
            for (int element = 0; element < _gift.Length; element++)
            {
                if (_gift[element].Name == name)
                {
                    var foundSweet = GetSweetInGifts(element);
                    Console.WriteLine($"Name: {foundSweet.Name} Weight: {foundSweet.Weight} g");
                    isSweetFound = true;
                }
            }

            if (!isSweetFound)
            {
                Console.WriteLine($"Can't find sweets");
            }
        }
    }
}

