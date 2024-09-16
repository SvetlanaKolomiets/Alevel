using static Homework14_Events.Calculator;

namespace Homework14_Events;

class Program
{
    static void Main(string[] args)
    {
        var calculate = new Calculator();

        FirstEventHandler firstHandler = new FirstEventHandler();

        SecondEventHandler secondHandler = new SecondEventHandler();

        calculate.Calculate += firstHandler.HandleCalculation;

        calculate.Calculate += secondHandler.HandleCalculation;

        Calculation calculation = calculate.Addition;

        var result = Wrapper(calculation, 10, 5) + Wrapper(calculation, 17, 8);

        Console.WriteLine(result);

    }
}



