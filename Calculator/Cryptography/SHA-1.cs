using System;
namespace Calculator.Cryptography;

public class SHA_1
{
	public static List<byte> SHA1(List<byte> Input)
	{
		//todo padding message
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


		int index = Input.Count + 1;
		output[index] = 0b10000000;

		//fill out the rest of zero's
		for (int i = index; i < lastIndex; i++)
		{
			output[i] = 0b00000000;
		}
		
		// todo set size of message in message
		
		byte[] inputSize = BitConverter.GetBytes(Input.Count);

		for (int i = 0; i < 8; i++)
		{
			output[lastIndex + i] = inputSize[i];
		}
		
		return output.ToList();
	}
}