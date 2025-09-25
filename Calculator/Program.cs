// See https://aka.ms/new-console-template for more information

using System.Text;
using System.Security.Cryptography;
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

            
            string input = "Hello, world!";
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            
            Console.WriteLine(Cryptography.SHA_1.SHA1(inputBytes.ToList()));
            
            using (SHA1 SHADotnet = SHA1.Create())
            {
                byte[] hashBytes = SHADotnet.ComputeHash(inputBytes);
                string hash = BitConverter.ToString(hashBytes);
                Console.WriteLine($"SHA1(\"{input}\") = {hash}");
            }
        }
        
        
        public static int Add(int a, int b) => a + b;
    }
}

