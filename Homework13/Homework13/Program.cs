using static Homework13.FirstClass;
using static Homework13.SecondClass;

namespace Homework13;

class Program
{
    static void Main(string[] args)
    {
        Show show = Show;
        Multiply multiply = Multiply;
        ResultDelegate result = Result;
        result = Calc(multiply, 3, 3);
        var showResult = Result(2);
        Show(showResult);
    }

    public static void Show(bool result)
    {
        Console.WriteLine($"{result}");
    }
}


