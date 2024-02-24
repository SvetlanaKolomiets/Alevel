using homework16.Enums;

namespace homework16.Services
{
	public class ClosingEventHandler
	{
        public void HandleClosing(object sender, State state)
        {
            if (state == State.Ok)
            {
                Console.WriteLine("The operation has been confirmed");
            }
            else if (state == State.Cancel)
            {
                Console.WriteLine("The operation was rejected");
            }
        }
    }
}

