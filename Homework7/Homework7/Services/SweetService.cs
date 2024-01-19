using Homework7.Entities;
using Homework7.Repositories;
using Homework7.Models;

namespace Homework7.Services
{
    public class SweetService : ISearch
    {
        private SweetsRepository _sweetsRepository;
        private bool _userWantsToContinue = true;
        public SweetService(SweetsRepository sweetsRepository)
        {
            _sweetsRepository = sweetsRepository;
        }


        public void PrintSweet()
        {
            var number = 1;
            foreach (var sweet in _sweetsRepository.GenerateSweets())
            {
                Console.Write($"{number} {sweet.Name} {sweet.Weight} g ");

                switch (sweet)
                {
                    case ChocolateCandyEntity chocolateCandy:
                        Console.Write($"Form: {chocolateCandy.Form} Chocolate type: {chocolateCandy.ChocolateType}");
                        break;
                    case CandyEntity candy:
                        Console.Write($"Form: {candy.Form}");
                        break;
                    case CookieWithFillingEntity cookieWithFilling:
                        Console.Write($"Form: {cookieWithFilling.Form} Filling: {cookieWithFilling.Filling}");
                        break;
                    case CookieEntity cookie:
                        Console.Write($"Form: {cookie.Form}");
                        break;
                }
                Console.WriteLine();
                number++;
            }
        }

        public Sweet ChooseSweet()
        {
            Console.WriteLine($"Choose candy number you want to add to a gift or press 'Q' for exit");
            var input = Console.ReadLine();
            while (_userWantsToContinue)
            {
                if (int.TryParse(input, out int inputNumber) && inputNumber <= _sweetsRepository.GenerateSweets().Length
                    && inputNumber > 0)
                {
                    var sweet = GetSweetByNumber(inputNumber);
                    return sweet;
                }
                else if (input.ToUpper() == "Q")
                {
                    _userWantsToContinue = false;
                }
                else if (inputNumber >= _sweetsRepository.GenerateSweets().Length || inputNumber < 1)
                {
                    Console.WriteLine($"Invalid candy number. Please try again or press 'Q' for exit.");
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

        public int SweetQuantity()
        {

            while (_userWantsToContinue)
            {
                Console.WriteLine($"Choose how much sweets do you want to add to a gift: ");
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
            return 0;
        }

        public Sweet GetSweetByNumber(int number)
        {
            if (number >= 0 && number <= _sweetsRepository.GenerateSweets().Length)
            {
                var sweetEntity = _sweetsRepository.GetCandyByIndex(number-1);
                switch (sweetEntity)
                {
                    case ChocolateCandyEntity chocolateCandy:
                        return new ChocolateСandy(
                            chocolateCandy.Name,
                            chocolateCandy.Weight,
                            chocolateCandy.Form,
                            chocolateCandy.ChocolateType
                        );
                    case CandyEntity candy:
                        return new Candy(
                            candy.Name,
                            candy.Weight,
                            candy.Form
                        );
                    case CookieWithFillingEntity cookieWithFilling:
                        return new CookieWithFilling(
                            cookieWithFilling.Name,
                            cookieWithFilling.Weight,
                            cookieWithFilling.Form,
                            cookieWithFilling.Filling
                        );
                    case CookieEntity cookie:
                        return new Сookie(
                            cookie.Name,
                            cookie.Weight,
                            cookie.Form
                        );
                    default:
                        return null;
                }
            }

            return null;
        }

        public void SearchSweets(int weight)
        {
            var sweets = _sweetsRepository.GenerateSweets();
            var isSweetFound = false;
            for (int element = 0; element < sweets.Length; element++)
            {
                if (sweets[element].Weight == weight)
                {
                    var foundSweet = GetSweetByNumber(element + 1);
                    Console.WriteLine($"Name: {foundSweet.Name} Weight: {foundSweet.Weight}");
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
            var sweets = _sweetsRepository.GenerateSweets();
            var isSweetFound = false;
            for (int element = 0; element < sweets.Length; element++)
            {
                if (sweets[element].Name == name)
                {
                    var foundSweet = GetSweetByNumber(element + 1);
                    Console.WriteLine($"Name: {foundSweet.Name} Weight: {foundSweet.Weight}");
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
