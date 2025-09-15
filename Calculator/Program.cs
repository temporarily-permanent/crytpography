// See https://aka.ms/new-console-template for more information
using Calculator.Cryptography;
    
namespace Calculator
{
    public class Program
    {
        public static void Main()
        {
            List<byte> input =
            [
                104, 97, 108, 108, 111, 44, 32, 104,
                111, 101, 32, 103, 97, 97, 116, 32,
                104, 101, 116, 32, 101, 114, 109, 101,
                101, 
            ];
            
            byte[] nullTest = new byte[1234];
           // Console.WriteLine(578%512);
           // Console.WriteLine(nullTest[34]);
            nullTest[34] = 0;
            //Console.WriteLine(nullTest[34]);
            int b = 6; 
            byte[] aaa =  BitConverter.GetBytes((ulong)input.Count); 
            Console.WriteLine((ulong)input.Count);
            foreach (var d in aaa)
            {
                Console.WriteLine(d.ToString("X2"));
               
                
            }
        }
        
        
        public static int Add(int a, int b) => a + b;
    }
}

