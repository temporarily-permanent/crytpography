// See https://aka.ms/new-console-template for more information
using Calculator.Cryptography;
    
namespace Calculator
{
    public class Program
    {
        public static void Main()
        {

            uint a = 0b01000000_00000000_00000000_00010000;
            uint b = 0b01000000_00100100_00000000_00010000;
            uint c = a ^ b;
            Console.WriteLine(Convert.ToString(c, 2));
        }
        
        
        public static int Add(int a, int b) => a + b;
    }
}

