namespace Homework14_LINQ;

class Program
{
    static void Main(string[] args)
    {
        List<Contact> contacts = new List<Contact>
        {
            new Contact {Name = "Andrii", PhoneNumber = "380976766999"},
            new Contact {Name = "Vladislav", PhoneNumber = "380998909911"},
            new Contact {Name = "Petr", PhoneNumber = "380667712345"},
            new Contact {Name = "Denis", PhoneNumber = "380931209491"},
            new Contact {Name = "Georgii", PhoneNumber = "380630013481"}
        };

        var result = contacts.FirstOrDefault(x => x.Name.ToLower().Contains('a'));

        Console.WriteLine($"Name - {result.Name}, phone number - {result.PhoneNumber}");

        var result1 = contacts.Select(x => x.PhoneNumber);

        foreach (var phoneNumber in result1)
        {
            Console.WriteLine(phoneNumber);
        }

        var result2 = contacts.Where((x, i) => i % 2 != 0);

        foreach (var contact in result2)
        {
            Console.WriteLine($"Name - {contact.Name}, phone number - {contact.PhoneNumber}");
        }

        Console.WriteLine();

        var result3 = contacts.OrderBy(x => x.Name.Length).Skip(1);

        foreach (var contact in result3)
        {
            Console.WriteLine($"Name - {contact.Name}, phone number - {contact.PhoneNumber}");
        }

        Console.WriteLine();

        var result4 = contacts.OrderByDescending(x => x.PhoneNumber);

        foreach (var contact in result4)
        {
            Console.WriteLine($"Name - {contact.Name}, phone number - {contact.PhoneNumber}");
        }

        Console.WriteLine();

        var result5 = contacts.TakeWhile((x, i) => i < 3);

        foreach (var contact in result5)
        {
            Console.WriteLine($"Name - {contact.Name}, phone number - {contact.PhoneNumber}");
        }
    }
}

