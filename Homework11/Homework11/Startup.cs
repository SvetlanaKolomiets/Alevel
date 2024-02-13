using Homework11.Services;

namespace Homework11
{
	public class Startup
	{
        private PersonService _personService;

		public Startup(PersonService personService)
		{
            _personService = personService;
		}

		public void Run()
		{
            _personService.AddPerson("Kate", 29);
            _personService.AddPerson("Andrii", 41);
            _personService.AddPerson("Julia", 35);

            _personService.DisplayPeople();

            Console.WriteLine();

            _personService.SortByAge();

            _personService.DisplayPeople();

            Console.WriteLine();

            _personService.SortByName();

            _personService.DisplayPeople();

            Console.WriteLine();

            _personService.SetDefaultPerson(0, "Sveta", 28);

            _personService.DisplayPeople();
        }
	}
}

