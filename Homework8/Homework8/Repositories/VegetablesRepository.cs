using Homework8.Enums;
using Homework8.Entities;
using Homework8.Repositories.Abstractions;

namespace Homework8.Repositories
{
	public class VegetablesRepository : IVegetablesRepository
	{
		private VegetableEntity[] _vegetables = new VegetableEntity[11];

		public VegetableEntity[] GenerateVegetables()
		{
			_vegetables[0] = new BeetEntity()
			{
				Name = "Beet",
				Weight = 25,
				Shape = ShapeType.Round,
				Color = "Purple",
				Calories = 100.5
			};
            _vegetables[1] = new CarrotEntity()
            {
                Name = "Carrot",
                Weight = 14,
                Shape = ShapeType.Elongated,
                Color = "Orange",
                Calories = 60
            };
            _vegetables[2] = new RadishEntity()
            {
                Name = "Radish",
                Weight = 20,
                Shape = ShapeType.Elongated,
                Color = "Red",
                Calories = 4
            };
            _vegetables[3] = new OnionEntity()
            {
                Name = "Onion",
                Weight = 15,
                OnionType = OnionType.Onion,
                Color = "Yellow",
                Calories = 30
            };
            _vegetables[4] = new OnionEntity()
            {
                Name = "Green onion",
                Weight = 5,
                OnionType = OnionType.Green,
                Color = "Green",
                Calories = 5
            };
            _vegetables[5] = new OnionEntity()
            {
                Name = "Shallote onion",
                Weight = 12,
                OnionType = OnionType.Shallots,
                Color = "Yellow",
                Calories = 18.3
            };
            _vegetables[6] = new SaladEntity()
            {
                Name = "Salad leaf",
                Weight = 5,
                SaladType = SaladType.Leaf,
                Color = "Green",
                Calories = 1.5
            };
            _vegetables[7] = new SaladEntity()
            {
                Name = "Romaine salad",
                Weight = 10,
                SaladType = SaladType.Romaine,
                Color = "Green",
                Calories = 4
            };
            _vegetables[8] = new SaladEntity()
            {
                Name = "Radicchio salad",
                Weight = 9,
                SaladType = SaladType.Radicchio,
                Color = "Purple",
                Calories = 2.7
            };
            _vegetables[9] = new TomatoEntity()
            {
                Name = "Tomato",
                Weight = 90,
                Shape = ShapeType.Round,
                Color = "Red",
                Calories = 17.7
            };
            _vegetables[10] = new CucumberEntity()
            {
                Name = "Cucumber",
                Weight = 100,
                Shape = ShapeType.Elongated,
                Color = "Green",
                Calories = 18.3
            };

            return _vegetables;
        }

        public VegetableEntity GetVegetableByIndex(int index)
        {
            if (index >= 0 && index < _vegetables.Length)
            {
                return _vegetables[index];
            }

            return null;
        }

        public VegetableEntity GetVegetableByName(string name)
        {
            foreach (var vegetable in _vegetables)
            {
                if (vegetable.Name == name)
                {
                    return vegetable;
                }
            }

            return null;
        }
    }
	
}

