using Homework12.Services.Abstractions;

namespace Homework12
{
	public class Startup
	{
        private readonly IContactService _contactService;

        public Startup(IContactService contactService)
		{
            _contactService = contactService;
		}

		public void Run()
		{
            AddContactToList();
            GetContacts();
        }

        public void AddContactToList()
        {
            var firstName = _contactService.GetContactFirstName();
            var lastName = _contactService.GetContactLastName();
            var phoneNumber = _contactService.GetContactPhoneNumber();

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName)
                || string.IsNullOrEmpty(phoneNumber))
            {
                Console.WriteLine("Invalid input. Contact is not added.");
                return;
            }

            _contactService.AddContact(firstName, lastName, phoneNumber);
        }

        public void GetContacts()
        {
            var contacts = _contactService.GetContacts();
            var grouppedContacts = _contactService.GroupContactsByAlphabet(contacts);
            _contactService.PrintContacts(grouppedContacts);
            Console.ReadLine();
        }
    }
}

