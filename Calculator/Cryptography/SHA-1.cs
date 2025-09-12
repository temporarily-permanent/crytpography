namespace Calculator.Cryptography;

public class SHA_1
{
	public static List<sbyte> SHA1(List<sbyte> Input)
	{
		//todo padding message
		throw new NotImplementedException();
	}

	private List<sbyte> PaddingMessageSHA1(List<sbyte> Input)
	{
		//todo check if math checks out
		//todo check if math checks out
		sbyte[] output = new sbyte[(int)Math.Ceiling((double)Input.Count / 64) * 64];

		//copy message over
		for (int i = 0; i < Input.Count; i++)
		{
			output[i] = Input[i];
		}
		
		// calculate amount of 0 needed in padding
		int excess = Input.Count % 64;
		int k = 60 - excess;

		int index = Input.Count + 1;
		output[index] = 0bx1000000;
		
		if (((Input.Count * 8) % 512) < 448)
		{
			throw new ArithmeticException();
		} 
		
		return output.ToList();
	}
}