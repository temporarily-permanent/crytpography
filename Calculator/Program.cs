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
            Console.Write(BitConverter.IsLittleEndian);
            
            
            uint a = 0b01000000_00000000_00000000_00010000;
            uint b = 0b01000000_00100100_00000000_00010000;
            uint c = a ^ b;
            Console.WriteLine(Convert.ToString(c, 2));

            
            string input = "Hello, world!";
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            
            Console.WriteLine(SHA_1.SHA1(inputBytes.ToList()));
            
            using (SHA1 SHADotnet = SHA1.Create())
            {
                byte[] hashBytes = SHADotnet.ComputeHash(inputBytes);
                string hash = BitConverter.ToString(hashBytes);
                Console.WriteLine($"SHA1(\"{input}\") = {hash}");
            }
            
            uint H0 = 0x67452301;
            uint H1 = 0xefcdab89;
            uint H2 = 0x98badcfe;
            uint H3 = 0x10325476;
            uint H4 = 0xc3d2e1f0;
            
            uint[] output = new uint[5] { H0, H1, H2, H3, H4 };

// Convert each uint to bytes (big-endian) and concatenate
            /*byte[] bytes = output
                .SelectMany(x => BitConverter.GetBytes(x).Reverse()) // Reverse if you want big-endian
                .ToArray();*/
            byte[] bytes = new byte[20];

            for (int i = 0; i < output.Length; i++)
            {
                byte[] temp = BitConverter.GetBytes(output[i]);
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(temp);
                } // fix endian

                Buffer.BlockCopy(temp, 0, bytes, i * 4, 4);
            }

            string hashString = BitConverter.ToString(bytes).Replace("-", "")/*.ToLowerInvariant()*/;
            Console.WriteLine(hashString);
            
            uint even =   0b10101001011101011000110101100101;
            uint RotLeft = 0b01010010111010110001101011001011;
            Console.WriteLine(Convert.ToString(uint.RotateLeft(even, 1), 2));
            Console.WriteLine(Convert.ToString(RotLeft, 2));
            uint[] charToHexTest = SHA_1.PaddingMessageSHA1(inputBytes.ToList()).ToArray();
            Console.WriteLine(string.Concat(charToHexTest.Select(x => x.ToString("X8"))));
        }
        
        
        public static int Add(int a, int b) => a + b;
    }
}

