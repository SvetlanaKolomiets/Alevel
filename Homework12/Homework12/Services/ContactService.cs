using System.Globalization;
using System.Text.RegularExpressions;
using Homework12.Models;
using Homework12.Repositories.Abstractions;
using Homework12.Services.Abstractions;

namespace Homework12.Services
{
	public class ContactService : IContactService
    {
		private readonly IContactsRepository _contactsRepository;

        public ContactService(IContactsRepository contactsRepository)
		{
			_contactsRepository = contactsRepository;
		}

        public string GetContactFirstName()
        {
            var userWantsToContinue = true;
            var firstName = "";
            while (userWantsToContinue)
            {
                Console.WriteLine("Enter contact first name or enter 'Q' for exit");
                var input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    firstName = input?.Trim();
                    userWantsToContinue = false;
                }
                else if (input.ToUpper() == "Q")
                {
                    userWantsToContinue = false;
                }
            }

            return firstName;
        }

        public string GetContactLastName()
        {
            var userWantsToContinue = true;
            var lastName = "";
            while (userWantsToContinue)
            {
                Console.WriteLine("Enter contact last name or enter 'Q' for exit");
                var input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    lastName = input?.Trim();
                    userWantsToContinue = false;
                }
                else if (input.ToUpper() == "Q")
                {
                    userWantsToContinue = false;
                }
            }

            return lastName;
        }

        public string GetContactPhoneNumber()
        {
            var userWantsToContinue = true;
            var phoneNumber = "";
            while (userWantsToContinue)
            {
                Console.WriteLine("Enter contact phone number in international " +
                    "format:(for example, 1234567890) or enter 'Q' for exit");
                var input = Console.ReadLine();
                var pattern = @"^\d{1,4}\s?\d{1,15}$";
                if (Regex.IsMatch(input, pattern))
                {
                    phoneNumber = input;
                    userWantsToContinue = false;
                }
                else if (input.ToUpper() == "Q")
                {
                    userWantsToContinue = false;
                }
                else
                {
                    Console.WriteLine("Incorrect number");
                }
            }

            return phoneNumber;
        }

        public void AddContact(string firstName, string lastName, string phoneNumber)
        {

            _contactsRepository.AddContact(firstName, lastName, phoneNumber);
        }

        public List<Contact> GetContacts()
        {
            var contactEntities = _contactsRepository.GetContacts();

            var contacts = new List<Contact>();

            foreach (var contactEntity in contactEntities)
            {
                contacts.Add(new Contact()
                {
                    FirstName = contactEntity.FirstName,
                    LastName = contactEntity.LastName,
                    PhoneNumber = contactEntity.PhoneNumber
                });
            }

            return contacts;
        }

        public CultureInfo GetCultureInfo()
        {
            var userWantsToContinue = true;
            CultureInfo currentCulture = null;
            while (userWantsToContinue)
            {
                Console.WriteLine($"Choose language for displaying contacts and " +
                    $"enter in the console or enter 'Q' for exit: {Environment.NewLine}" +
                $"en {Environment.NewLine}ua {Environment.NewLine}Language: ");
                var input = Console.ReadLine();
                switch (input?.ToLower()?.Trim())
                {
                    case "en":
                        currentCulture = new CultureInfo("en-US");
                        userWantsToContinue = false;
                        break;
                    case "ua":
                        currentCulture = new CultureInfo("uk-UA");
                        userWantsToContinue = false;
                        break;
                    case "q":
                        userWantsToContinue = false;
                        break;
                    default:
                        Console.WriteLine("There is currently no support for this language. " +
                            "English will be set as default");
                        currentCulture = new CultureInfo("en-US");
                        break;
                }
            }

            return currentCulture;
        }

        public List<Contact> SortingByParameter(List<Contact> contacts, CultureInfo culture, string sortingParameter)
        {
            CompareInfo compareInfo = culture.CompareInfo;
            switch (sortingParameter)
            {
                case "firstName":
                    contacts.Sort((s1, s2) => compareInfo.Compare(s1.FirstName, s2.FirstName, CompareOptions.StringSort));
                    break;
                case "lastName":
                    contacts.Sort((s1, s2) => compareInfo.Compare(s1.LastName, s2.LastName, CompareOptions.StringSort));
                    break;
                case "phoneNumber":
                    contacts.Sort((s1, s2) => compareInfo.Compare(s1.PhoneNumber, s2.PhoneNumber, CompareOptions.StringSort));
                    break;
                default:
                    return null;
            }

            return contacts;
        }

        public string ChooseSortingParameter()
        {
            var userWantsToContinue = true;
            var sortingParameter = "";

            while (userWantsToContinue)
            {
                Console.WriteLine("By what parameter do you want to sort the contact list? " +
                    "Enter 1 for first name, enter 2 for last name, enter 3 for number. " +
                    "Enter 'Q' to exit");

                var input = Console.ReadLine().Trim().ToUpper();

                switch (input)
                {
                    case "1":
                        sortingParameter = "firstName";
                        userWantsToContinue = false;
                        break;
                    case "2":
                        sortingParameter = "lastName";
                        userWantsToContinue = false;
                        break;
                    case "3":
                        sortingParameter = "phoneNumber";
                        userWantsToContinue = false;
                        break;
                    case "Q":
                        userWantsToContinue = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect parameter number. Choose from 1 to 3 or enter 'Q' to exit");
                        break;
                }
            }

            return sortingParameter;
        }

        public char GetFirstLetter(string item, CultureInfo culture)
        {
            if (!string.IsNullOrEmpty(item))
            {
                if (culture.Name == "en-US")
                {
                    return this.SortingForEnglishLanguage(item);
                }
                else if (culture.Name == "uk-UA")
                {
                    return this.SortingForUkrainianLanguage(item);
                }
            }
            return '#';
        }

        public char SortingForEnglishLanguage(string item)
        {
            char firstChar = char.ToUpper(item[0]);

            if ((firstChar >= 'A' && firstChar <= 'Z') || char.IsDigit(firstChar))
            {
                return firstChar;
            }
            else
            {
                return '#';
            }
        }

        public char SortingForUkrainianLanguage(string item)
        {
            char firstChar = char.ToUpper(item[0]);

            if ((firstChar >= '\u0410' && firstChar <= '\u044F')|| firstChar == 'І'
                || firstChar == 'Ї' || firstChar == 'Є' || firstChar == 'Ґ' || char.IsDigit(firstChar))
            {
                return firstChar;
            }
            else
            {
                return '#';
            }
        }

        public char GetFirstLetterForParameter(Contact contact, string sortingParameter, CultureInfo culture)
        {
            var item = "";
            switch (sortingParameter)
            {
                case "firstName":
                    item = contact.FirstName;
                    break;
                case "lastName":
                    item = contact.LastName;
                    break;
                case "phoneNumber":
                    item = contact.PhoneNumber;
                    break;
                default:
                    return default;
            }
            return GetFirstLetter(item, culture);
        }

        public Dictionary<char, List<Contact>> GroupContactsByAlphabet(List<Contact> contacts)
        {
            Dictionary<char, List<Contact>> contactItems = new Dictionary<char, List<Contact>>();
            var cultureInfo = this.GetCultureInfo();
            var sortingParameter = this.ChooseSortingParameter();
            contacts = this.SortingByParameter(contacts, cultureInfo, sortingParameter);

            foreach (var contact in contacts)
            {
                char firstChar = this.GetFirstLetterForParameter(contact, sortingParameter, cultureInfo);
                if (!contactItems.ContainsKey(firstChar))
                {
                    contactItems[firstChar] = new List<Contact>();
                }

                contactItems[firstChar].Add(contact);
            }

            return contactItems;
        }

        public void PrintContacts(Dictionary<char, List<Contact>> contactItems)
        {
            foreach (var key in contactItems)
            {
                Console.WriteLine($"{key.Key}");
                foreach (var contact in key.Value)
                {
                    Console.WriteLine($"  {contact.FirstName} {contact.LastName} - {contact.PhoneNumber}");
                }
                Console.WriteLine();
            }
        }
    }
}

