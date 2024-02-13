using Homework11.Services;

namespace Homework11;

class Program
{
    static void Main(string[] args)
    {
        var app = new Startup(new PersonService());
        app.Run();

    }
}

