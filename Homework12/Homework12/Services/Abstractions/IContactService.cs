using Homework12.Models;
using System.Globalization;

namespace Homework12.Services.Abstractions
{
    public interface IContactService
    {
        string GetContactFirstName();
        string GetContactLastName();
        string GetContactPhoneNumber();
        void AddContact(string firstName, string lastName, string phoneNumber);
        List<Contact> GetContacts();
        CultureInfo GetCultureInfo();
        List<Contact> SortingByParameter(List<Contact> contacts, CultureInfo culture, string sortingParameter);
        string ChooseSortingParameter();
        char GetFirstLetter(string item, CultureInfo culture);
        char SortingForEnglishLanguage(string item);
        char SortingForUkrainianLanguage(string item);
        char GetFirstLetterForParameter(Contact contact, string sortingParameter, CultureInfo culture);
        Dictionary<char, List<Contact>> GroupContactsByAlphabet(List<Contact> contacts);
        void PrintContacts(Dictionary<char, List<Contact>> contactItems);
    }
}