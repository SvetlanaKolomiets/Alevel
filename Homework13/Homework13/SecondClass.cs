namespace Homework13
{
    public static class SecondClass
    {
        public delegate int Multiply(int x, int y);

        public delegate bool ResultDelegate(int x);

        public static int result;

        public static ResultDelegate Calc(Multiply multiply, int x, int y)
        {
            result = multiply(x, y);
            Console.WriteLine(result);
            return Result;
        }

        public static bool Result(int x)
        {
            var number = result % x;

            if (number == 0)
            {
                return true;
            }

            return false;
        }
    }
}
