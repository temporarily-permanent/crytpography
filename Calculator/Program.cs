// See https://aka.ms/new-console-template for more information

namespace Calculator
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(578%512);
            Math.Round(3.98, 0, MidpointRounding.AwayFromZero);
        }
        
        public static int Add(int a, int b) => a + b;
    }
}

