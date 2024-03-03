using Homework12.Entities;

namespace Homework12.Repositories.Abstractions
{
	public interface IContactsRepository
	{
        ContactEntity AddContact(string firstName, string lastName, string phoneNumber);
        List<ContactEntity> GetContacts();
    }
}

