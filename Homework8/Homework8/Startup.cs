using Homework8.Services.Abstractions;
namespace Homework8
{
	public class Startup
	{
        private readonly IVegetableService _vegetableService;
        private readonly ISaladService _saladService;

        public Startup(IVegetableService vegetableService, ISaladService saladService)
		{
			_vegetableService = vegetableService;
            _saladService = saladService;

        }

        public void Run()
        {
            _vegetableService.PrintVegetables();
            _saladService.MakeASalad();

            _vegetableService.SearchForAVegetable();
        }

    }
}

