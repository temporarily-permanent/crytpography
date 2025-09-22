using System;
namespace Calculator.Cryptography;

public class SHA_1
{
	public static string SHA1(List<byte> Input)
	{
		//https://nvlpubs.nist.gov/nistpubs/FIPS/NIST.FIPS.180-4.pdf
		//SHA-1 constants
		const uint K1 = 0x5a827999;
		const uint K2 = 0x6ed9eba1;
		const uint K3 = 0x8f1bbcdc;
		const uint K4 = 0xca62c1d6;
		
		//initial hashing values
		uint H0 = 0x67452301;
		uint H1 = 0xefcdab89;
		uint H2 = 0x98badcfe;
		uint H3 = 0x10325476;
		uint H4 = 0xc3d2e1f0;
		
		//done padding message
		List<uint> paddedMessage = PaddingMessageSHA1(Input);
		for (int i = 0; i >= paddedMessage.Count / 64; i++)
		{
			//todo Prepare the message schedule
			int currentBlockIndex = i * 16;
			uint[] messageSchedule = PrepareMessageScheduleSHA1(paddedMessage.Slice(currentBlockIndex, 16));

			//Initialize working variables
			uint a = H0, b = H1, c = H2, d = H3, e = H4, T;

			//Compute intermediate hash
			for (int j = 0; j < 20; j++)
			{
				T = uint.RotateLeft(a,5) + Ch(b,c,d) + e + K1 + messageSchedule[j];
				e = d; d = c; c = uint.RotateLeft(b, 30); b = a; a = T;
			}
			
			for (int j = 20; j < 40; j++)
			{
				T = uint.RotateLeft(a,5) + Parity(b,c,d) + e + K2 + messageSchedule[j];
				e = d; d = c; c = uint.RotateLeft(b, 30); b = a; a = T;
			}
			for (int j = 40; j < 60; j++)
			{
				T = uint.RotateLeft(a,5) + Maj(b,c,d) + e + K3 + messageSchedule[j];
				e = d; d = c; c = uint.RotateLeft(b, 30); b = a; a = T;
			}
			for (int j = 60; j < 80; j++)
			{
				T = uint.RotateLeft(a,5) + Parity(b,c,d) + e + K4 + messageSchedule[j];
				e = d; d = c; c = uint.RotateLeft(b, 30); b = a; a = T;
			}

			//compute intermediate hash
			H0 = a + H0; H1 = b + H1; H2 = c + H2; H3 = d + H3; H4 = e + H4;
		}

		return H0.ToString() + H1.ToString() + H2.ToString() + H3.ToString() + H4.ToString();
	}

	private static uint Ch(uint a, uint b, uint c)
	{
		return (a & b) | (~b & c);
	}
	private static uint Parity(uint a, uint b, uint c)
	{
		return a | b | c;
	}
	private static uint Maj(uint a, uint b, uint c)
	{
		return (a & b) | (a & c) | (b & c);
	}

	public static uint[] PrepareMessageScheduleSHA1(List<uint> Input)
	{
		uint[] output = new uint[80];
		//copy current block into message schedule
		for (int j = 0 ; j < 16; j++)
		{
			output[j] = Input[j];
		}

		//fill 16 <= t <= 80 out
		for (int h = 16; h < 80; h++)
		{
			output[h] = uint.RotateLeft(output[h - 3] | output[h - 8] | output[h - 14] | output[h - 16], 1);
		}
		return output;
	}


	public static List<uint> PaddingMessageSHA1(List<byte> Input)
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
		
		//return output.ToList();
		
		//convert to list<uint> to work with 32-bit words later
		uint[] output2 = new uint[output.Length / 4] ;

		for (int i = 0; i < output.Length / 4; i++)
		{
			int j = i * 4;
			output2[i] =
				((uint)output[j]     << 24) |
				((uint)output[j + 1] << 16) |
				((uint)output[j + 2] <<  8) |
					   output[j + 3]        ;
		}
		return output2.ToList();
	}
}