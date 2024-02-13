using Homework11.Collections;
using Homework11.Models;

namespace Homework11.Services
{
	public class PersonService
	{
        private MyCollection<Person> _people;

        public PersonService()
		{
            _people = new MyCollection<Person>();
		}

		public MyCollection<Person> AddPerson(string name, int age)
		{
			_people.Add(
                new Person()
                {
                    Name = name,
                    Age = age
                }
            );

            return _people;
		}

        public void DisplayPeople()
        {
            foreach (var person in _people)
            {
                Console.WriteLine($"Name {person.Name}, age {person.Age}");
            }
        }

        public void SortByAge()
        {
            _people.BubbleSort((person1, person2) => person1.Age.CompareTo(person2.Age));
        }

        public void SortByName()
        {
            _people.BubbleSort((person1, person2) => person1.Name.CompareTo(person2.Name));
        }

        public void SetDefaultPerson(int index, string defaultName, int defaultAge)
        {
            _people.SetDefaulAt(index,
                new Person()
                {
                    Name = defaultName,
                    Age = defaultAge
                }
            );
        }
        
    }
}

