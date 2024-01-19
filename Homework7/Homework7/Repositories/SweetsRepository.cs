using Homework7.Entities;
using Homework7.Enums;

namespace Homework7.Repositories
{
    public class SweetsRepository
    {
        private SweetEntity[] _sweets = new SweetEntity[10];
        public SweetsRepository()
        {
        }

        public SweetEntity[] GenerateSweets()
        {
            _sweets[0] = new ChocolateCandyEntity()
            {
                Name = "Raffaello",
                Weight = 20,
                Form = FormType.Circle,
                ChocolateType = ChocolateType.White
            };
            _sweets[1] = new CandyEntity()
            {
                Name = "Rachki",
                Weight = 15,
                Form = FormType.Square
            };
            _sweets[2] = new ChocolateCandyEntity()
            {
                Name = "Choco Lapki",
                Weight = 10,
                Form = FormType.Square,
                ChocolateType = ChocolateType.Dark
            };
            _sweets[3] = new ChocolateCandyEntity()
            {
                Name = "Lindor",
                Weight = 25,
                Form = FormType.Circle,
                ChocolateType = ChocolateType.Milk
            };
            _sweets[4] = new CookieEntity()
            {
                Name = "Maria",
                Weight = 5,
                Form = FormType.Circle
            };
            _sweets[5] = new CookieWithFillingEntity()
            {
                Name = "Ulker Biskrem",
                Weight = 10,
                Form = FormType.Circle,
                Filling = FillingType.Chocolate
            };
            _sweets[6] = new CookieEntity()
            {
                Name = "For coffee",
                Weight = 7,
                Form = FormType.Square
            };
            _sweets[7] = new CookieWithFillingEntity()
            {
                Name = "Oreo",
                Weight = 15,
                Form = FormType.Circle,
                Filling = FillingType.Cream
            };
            _sweets[8] = new CookieWithFillingEntity()
            {
                Name = "Kontik",
                Weight = 50,
                Form = FormType.Circle,
                Filling = FillingType.Caramel
            };
            _sweets[9] = new CookieEntity()
            {
                Name = "Biskotti",
                Weight = 100,
                Form = FormType.Square
            };
            return _sweets;
        }

        public SweetEntity GetCandyByIndex(int index)
        {
            if (index >= 0 && index < _sweets.Length)
            {
                return _sweets[index];
            }
            return null;
        }
    }
}
