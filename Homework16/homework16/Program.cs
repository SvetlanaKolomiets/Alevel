using homework16.Services;

namespace homework16;

class Program
{
    static async Task Main(string[] args)
    {
        var messageBox = new MessageBox();

        ClosingEventHandler handler = new ClosingEventHandler();

        messageBox.Closed += handler.HandleClosing;

        messageBox.Open();

        Console.ReadLine();
    }
}

