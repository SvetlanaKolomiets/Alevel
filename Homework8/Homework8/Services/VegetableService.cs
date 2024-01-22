using Homework8.Models;
using Homework8.Repositories.Abstractions;
using Homework8.Entities;
using Homework8.Services.Abstractions;
using Homework8.ExtensionMethods;

namespace Homework8.Services
{
	public class VegetableService : IVegetableService
    {
		private IVegetablesRepository _vegetablesRepository;
        private bool _userWantsToContinue = true;

        public VegetableService(IVegetablesRepository vegetablesRepository)
		{
			_vegetablesRepository = vegetablesRepository;
        }

        public void PrintVegetables()
        {
            var vegetables = GenerateVegetables();
            var number = 1;
            foreach (var vegetableEntity in vegetables)
            {
                var vegetable = this.GetVegetableByNumber(number - 1);
                Console.Write($"{number} {vegetable.Name}, {vegetable.Weight} g ");

                switch (vegetable)
                {
                    case Beet beet:
                        Console.Write($"Form: {beet.Shape}, Color: {beet.Color}, Calories: {beet.Calories}");
                        break;
                    case Сarrot carrot:
                        Console.Write($"Form: {carrot.Shape}, Color: {carrot.Color}, Calories: {carrot.Calories}");
                        break;
                    case Radish radish:
                        Console.Write($"Form: {radish.Shape}, Color: {radish.Color}, Calories: {radish.Calories}");
                        break;
                    case Onion onion:
                        Console.Write($"Onion type: {onion.OnionType}, Color: {onion.Color}, Calories: {onion.Calories}");
                        break;
                    case Salad salad:
                        Console.Write($"Salad type: {salad.SaladType}, Color: {salad.Color}, Calories: {salad.Calories}");
                        break;
                    case Tomato tomato:
                        Console.Write($"Form: {tomato.Shape}, Color: {tomato.Color}, Calories: {tomato.Calories}");
                        break;
                    case Сucumber сucumber:
                        Console.Write($"Form: {сucumber.Shape}, Color: {сucumber.Color}, Calories: {сucumber.Calories}");
                        break;
                }
                Console.WriteLine();
                Console.WriteLine();
                number++;
            }
        }

        public VegetableEntity[] GenerateVegetables()
        {
            var vegetables = _vegetablesRepository.GenerateVegetables();
            return vegetables;
        }

        public VegetableEntity GetVegetableEntity(int number)
        {
            var vegetable = _vegetablesRepository.GetVegetableByIndex(number);
            return vegetable;
        }

        public Vegetable GetVegetableByNumber(int number)
        {
            var vegetables = GenerateVegetables();
            if (number >= 0 && number <= vegetables.Length)
            {
                var vegetableEntity = this.GetVegetableEntity(number);
                switch (vegetableEntity)
                {
                    case BeetEntity beet:
                        return new Beet(
                            beet.Name,
                            beet.Weight,
                            beet.Shape,
                            beet.Color,
                            beet.Calories
                        );
                    case CarrotEntity carrot:
                        return new Сarrot(
                            carrot.Name,
                            carrot.Weight,
                            carrot.Shape,
                            carrot.Color,
                            carrot.Calories
                        );
                    case RadishEntity radish:
                        return new Radish(
                            radish.Name,
                            radish.Weight,
                            radish.Shape,
                            radish.Color,
                            radish.Calories
                        );

                    case OnionEntity onion:
                        return new Onion(
                            onion.Name,
                            onion.Weight,
                            onion.OnionType,
                            onion.Color,
                            onion.Calories
                        );

                    case SaladEntity salad:
                        return new Salad(
                            salad.Name,
                            salad.Weight,
                            salad.SaladType,
                            salad.Color,
                            salad.Calories
                        );

                    case TomatoEntity tomato:
                        return new Tomato(
                            tomato.Name,
                            tomato.Weight,
                            tomato.Shape,
                            tomato.Color,
                            tomato.Calories
                        );

                    case CucumberEntity cucumber:
                        return new Сucumber(
                            cucumber.Name,
                            cucumber.Weight,
                            cucumber.Shape,
                            cucumber.Color,
                            cucumber.Calories
                        );
                    default:
                        return null;
                }
            }

            return null;
        }

        public Vegetable ChooseVegetable()
        {
            var vegetables = _vegetablesRepository.GenerateVegetables();
            Console.WriteLine($"Choose vegetable number you want to add to a salad or press 'Q' for exit");
            var input = Console.ReadLine();
            while (_userWantsToContinue)
            {
                if (int.TryParse(input, out int inputNumber) && inputNumber <= vegetables.Length
                    && inputNumber > 0)
                {
                    var vegetable = GetVegetableByNumber(inputNumber - 1);
                    return vegetable;
                }
                else if (input.ToUpper() == "Q")
                {
                    _userWantsToContinue = false;
                }
                else if (inputNumber >= vegetables.Length || inputNumber < 1)
                {
                    Console.WriteLine($"Invalid vegetable number. Please try again or press 'Q' for exit.");
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

        public int ChooseVegetableQuantity()
        {

            while (_userWantsToContinue)
            {
                Console.WriteLine($"Choose how much choosen vegetable do you want to add to a salad: ");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int inputNumber) && inputNumber > 0)
                {
                    return inputNumber;
                }
                else if (input.ToUpper() == "Q")
                {
                    _userWantsToContinue = false;
                }
                else
                {
                    Console.WriteLine($"The entered value was not a correct number. Try again or press 'Q' for exit. {input}");
                }
            }
            return default;
        }

        public void SearchForAVegetable()
        {
            Console.WriteLine($"Enter vegetable weight or name you want to find ");
            var searchInput = Console.ReadLine();
            if (int.TryParse(searchInput, out int searchNumber))
            {
                this.SearchVegetables(searchNumber);
            }
            else
            {
                this.SearchVegetables(searchInput);
            }
            Console.ReadLine();
        }
    }
}

