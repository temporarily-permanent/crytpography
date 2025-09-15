// See https://aka.ms/new-console-template for more information

namespace Calculator
{
    public class Program
    {
        public static void Main()
        {
            byte[] nullTest = new byte[1234];
            Console.WriteLine(578%512);
            Console.WriteLine(nullTest[34]);
            nullTest[34] = 0;
            Console.WriteLine(nullTest[34]);
            int b = 6; 
            byte[] aaa =  BitConverter.GetBytes(b) ;
            foreach (var d in aaa)
            {
                Console.WriteLine(d.ToString("X2"));
            }
        }
        
        
        public static int Add(int a, int b) => a + b;
    }
}

