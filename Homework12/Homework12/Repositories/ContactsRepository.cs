using Homework12.Entities;
using Homework12.Repositories.Abstractions;

namespace Homework12.Repositories
{
	public class ContactsRepository : IContactsRepository
    {
		private List<ContactEntity> _contacts = new List<ContactEntity>();

		public ContactsRepository()
		{
			_contacts = new List<ContactEntity>()
			{
				new ContactEntity()
				{
					FirstName = "John",
					LastName = "Smith",
					PhoneNumber = "380956718789"
				},
                new ContactEntity()
                {
                    FirstName = "Sarah",
                    LastName = "Williams",
                    PhoneNumber = "15551234567"
                },
                new ContactEntity()
                {
                    FirstName = "Ashley",
                    LastName = "Brown",
                    PhoneNumber = "33612345678"
                },
                new ContactEntity()
                {
                    FirstName = "Іван",
                    LastName = "Іванов",
                    PhoneNumber = "280631234882"
                },
                new ContactEntity()
                {
                    FirstName = "Василь",
                    LastName = "Петренко",
                    PhoneNumber = "+380992345678"
                },
                new ContactEntity()
                {
                    FirstName = "Євген",
                    LastName = "Бабенко",
                    PhoneNumber = "0941234908"
                },
            };
        }


        public ContactEntity AddContact(string firstName, string lastName, string phoneNumber)
		{
			ContactEntity contactEntity = new ContactEntity()
			{
				FirstName = firstName,
				LastName = lastName,
				PhoneNumber = phoneNumber
			};

			_contacts.Add(contactEntity);

			return contactEntity;
        }

        public List<ContactEntity> GetContacts()
		{
			return _contacts;
		}

        
    }
}

