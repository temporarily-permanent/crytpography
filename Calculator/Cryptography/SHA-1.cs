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
		
		List<uint> paddedMessage = PaddingMessageSHA1(Input);
		for (int i = 0; i < paddedMessage.Count / 16; i++)
		{
			//Prepare the message schedule
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
		
		uint[] output = {H0, H1, H2, H3, H4};
		return string.Concat(output.Select(x => x.ToString("X8")));
	}

	public static string SHA256(List<byte> Input)
	{
		uint[] K =
		{
			0x428a2f98, 0x71374491, 0xb5c0fbcf, 0xe9b5dba5,
			0x3956c25b, 0x59f111f1, 0x923f82a4, 0xab1c5ed5,
			0xd807aa98, 0x12835b01, 0x243185be, 0x550c7dc3,
			0x72be5d74, 0x80deb1fe, 0x9bdc06a7, 0xc19bf174,
			0xe49b69c1, 0xefbe4786, 0x0fc19dc6, 0x240ca1cc,
			0x2de92c6f, 0x4a7484aa, 0x5cb0a9dc, 0x76f988da,
			0x983e5152, 0xa831c66d, 0xb00327c8, 0xbf597fc7,
			0xc6e00bf3, 0xd5a79147, 0x06ca6351, 0x14292967,
			0x27b70a85, 0x2e1b2138, 0x4d2c6dfc, 0x53380d13,
			0x650a7354, 0x766a0abb, 0x81c2c92e, 0x92722c85,
			0xa2bfe8a1, 0xa81a664b, 0xc24b8b70, 0xc76c51a3,
			0xd192e819, 0xd6990624, 0xf40e3585, 0x106aa070,
			0x19a4c116, 0x1e376c08, 0x2748774c, 0x34b0bcb5,
			0x391c0cb3, 0x4ed8aa4a, 0x5b9cca4f, 0x682e6ff3,
			0x748f82ee, 0x78a5636f, 0x84c87814, 0x8cc70208,
			0x90befffa, 0xa4506ceb, 0xbef9a3f7, 0xc67178f2
		};
		
		uint H0 = 0x6a09e667;
		uint H1 = 0xbb67ae85;
		uint H2 = 0x3c6ef372;
		uint H3 = 0xa54ff53a;
		uint H4 = 0x510e527f;
		uint H5 = 0x9b05688c;
		uint H6 = 0x1f83d9ab;
		uint H7 = 0x5be0cd19;		
		
		List<uint> paddedMessage = PaddingMessageSHA1(Input);
		for (int i = 0; i < paddedMessage.Count / 16; i++)
		{
			int currentBlockIndex = i * 16;
			uint[] messageSchedule = PrepareMessageScheduleSHA256(paddedMessage.Slice(currentBlockIndex, 16));
		}
		
		
		throw new NotImplementedException();
	}

	private static uint Ch(uint a, uint b, uint c)
	{
		return (a & b) ^ (~a & c);
	}
	private static uint Parity(uint a, uint b, uint c)
	{
		return a ^ b ^ c;
	}
	private static uint Maj(uint a, uint b, uint c)
	{
		return (a & b) ^ (a & c) ^ (b & c);
	}

	

	private static uint SigmaV1(uint a)
	{
		return uint.RotateRight(a, 7) ^ uint.RotateRight(a,  18) ^ a >>  3;
	}

	private static uint SigmaV2(uint a)
	{
		return uint.RotateRight(a, 17) ^ uint.RotateRight(a, 19) ^ a >> 10;
	}


	public static uint[] PrepareMessageScheduleSHA256(List<uint> Input)
	{
		uint[] output = new uint[64];
		for (int j = 0 ; j < 16; j++)
		{
			output[j] = Input[j];
		}
		throw new NotImplementedException();
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
			output[h] = uint.RotateLeft(output[h - 3] ^ output[h - 8] ^ output[h - 14] ^ output[h - 16], 1);
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
