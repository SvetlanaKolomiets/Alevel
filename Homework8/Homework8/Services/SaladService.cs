using Homework8.Models;
using Homework8.Services.Abstractions;

namespace Homework8.Services
{
	public class SaladService : ISaladService
    {
        private IVegetableService _vegetableService;
        private Vegetable[] _salad = new Vegetable[0];
        private int _vegetableInASalad = 0;
        private int _totalWeight;
        private Vegetable _vegetable;
        private int _vegetableQuantity;
        private bool _userWantsToContinue = true;
        private double _totalCalories = 0;

        public SaladService(IVegetableService vegetableService)
		{
            _vegetableService = vegetableService;
        }

        public Vegetable ChooseVegetable()
        {
            _vegetable = _vegetableService.ChooseVegetable();
            return _vegetable;
        }

        public bool CheckIfUserWantToContinue()
        {
            if (_vegetable == null || _vegetableQuantity == default)
            {
                _userWantsToContinue = false;
            }
            return _userWantsToContinue;
        }

        public int ChooseVegetableQuantity()
        {
            _vegetableQuantity = _vegetableService.ChooseVegetableQuantity();
            return _vegetableQuantity;
        }

        public int CalculateTotalWeight()
        {
            if (_vegetableQuantity > 0)
            {
                _totalWeight = _vegetable.Weight * _vegetableQuantity;
                return _totalWeight;
            }

            return default;
        }

        public double CalculateCalories(Vegetable vegetable)
        {
            switch (vegetable)
            {
                case Beet beet:
                    return beet.Calories;
                case Сarrot carrot:
                    return carrot.Calories;
                case Radish radish:
                    return radish.Calories;
                case Onion onion:
                    return onion.Calories;
                case Salad salad:
                    return salad.Calories;
                case Tomato tomato:
                    return tomato.Calories;
                case Сucumber cucumber:
                    return cucumber.Calories;
                default:
                    break;
            }

            return default;
        }

        public Vegetable[] MakeASalad()
        {
            int maxWeight = 300;
            int saladWeight = 0;

            Console.WriteLine($"What do you like to put in your salad? " +
                $"Maximum salad weight could be {maxWeight} g {Environment.NewLine}");

            while (_userWantsToContinue && saladWeight < maxWeight)
            {
                _vegetable = this.ChooseVegetable();
                _vegetableQuantity = this.ChooseVegetableQuantity();
                _totalWeight = this.CalculateTotalWeight();

                if (_vegetable != null && _totalWeight + saladWeight <= maxWeight)
                {
                    AddToASalad(_vegetable, _vegetableQuantity);
                    saladWeight += _totalWeight;
                    _totalCalories += this.CalculateCalories(_vegetable);
                    Console.WriteLine($"In your salad: {saladWeight} g and {_totalCalories} calories " +
                        $"(Remaining space: {maxWeight - saladWeight} g){Environment.NewLine}");
                }
                else
                {
                    if (_vegetable == null || _totalWeight == default)
                    {
                        return null;
                    }
                    else
                    {
                        Console.WriteLine("Adding this vegetable exceeds the maximum weight. Please choose another vegetable.");
                    }
                }

                _userWantsToContinue = CheckIfUserWantToContinue();
            }

            return _salad;
        }

        public void AddToASalad(Vegetable vegetable, int quantity)
        {
            Array.Resize(ref _salad, _salad.Length + quantity);
            for (int element = 0; element < quantity; element++)
            {
                _salad[_vegetableInASalad] = vegetable;
                _vegetableInASalad++;
            }
        }
    }
}

