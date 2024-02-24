using homework16.Enums;

namespace homework16.Services
{
	public class MessageBox
	{
        public delegate void ClosingEventHandler(object sender, State state);

        public event ClosingEventHandler Closed;

        public async void Open()
        {
            var random = new Random();
            var number = random.Next(0, 2);
            State state = (State)number;

            Console.WriteLine("Window is open");
            await Task.Delay(3000);
            Console.WriteLine("Window is closed by the user");
            if (Closed != null)
            {
                OnClosed(state);
            }
        }

        protected virtual void OnClosed(State state)
        {
            Closed.Invoke(this, state);
        }
    }
}


