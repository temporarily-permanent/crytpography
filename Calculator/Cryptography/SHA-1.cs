using System;
namespace Calculator.Cryptography;

public class SHA_1
{
	public static List<byte> SHA1(List<byte> Input)
	{
		//SHA-1 constants
		//K1 5a827999
		//K2 6ed9eba1
		//K3 8f1bbcdc
		//K4 ca62c1d6
		
		//initial hashing values
		uint H0 = 0x67452301;
		uint H1 = 0xefcdab89;
		uint H2 = 0x98badcfe;
		uint H3 = 0x10325476;
		uint H4 = 0xc3d2e1f0;
		
		//done padding message
		List<byte> paddedMessage = PaddingMessageSHA1(Input);
		
		//todo parsing the message
		paddedMessage.
		
		//todo Prepare the message schedule
		throw new NotImplementedException();
	}

	public static List<byte> PaddingMessageSHA1(List<byte> Input)
	{
		//size of output is determined here and should not change
		byte[] output = new byte[(int)Math.Ceiling((double)Input.Count / 64) * 64];

		// fillng out output with 1's for debuging
		for (int i = 0; i < output.Length; i++)
		{
			output[i] = 0b11111111;
		}
		
		//copy message over
		for (int i = 0; i < Input.Count; i++)
		{
			output[i] = Input[i];
		}
		
		// calculate amount of 0 needed in padding, it's called k cause that's how it's called in the specification
		int excess = Input.Count % 64;
		int k = 64 - 8 - excess;
		int lastIndex = Input.Count + k;
		
		int index = Input.Count;
		output[index] = 0b10000000;
		index++;

		//fill out the rest of zero's
		for (int i = index; i < lastIndex; i++)
		{
			output[i] = 0b00000000;
		}
		
		//set size of message in message
		byte[] inputSize = BitConverter.GetBytes((long)(Input.Count * 8));
		Array.Reverse(inputSize);

		for (int i = 0; i < 8; i++)
		{
			Console.WriteLine(i);
			output[lastIndex + i] = inputSize[i];
		}
		
		return output.ToList();
	}
}