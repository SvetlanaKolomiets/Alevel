namespace Homework14_Events
{
	public class Calculator
	{
        public delegate void CalculationEventHandler(object sender, EventArgs args);

        public delegate int Calculation(int x, int y);

        public event CalculationEventHandler Calculate;

        public int Addition(int x, int y)
        {
            var result = x + y;
            if (Calculate != null)
            {
                OnCalculate(EventArgs.Empty);
            }
            
            return result;
        }

        protected virtual void OnCalculate(EventArgs e)
        {
            Calculate.Invoke(this, e);
        }


        public static int Wrapper(Calculation calculation, int x, int y)
        {
            return CalculateSum(calculation, x, y);
        }

        public static int CalculateSum(Calculation calculation, int x, int y)
        {
            try
            {
                return calculation(x, y);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return default;
            }
        }
    }
}

