namespace Calculator.Cryptography;

public class SHA_1
{
	public static List<sbyte> SHA1(List<sbyte> Input)
	{
		//todo padding message
		//todo 
		throw new NotImplementedException();
	}

	private List<sbyte> PaddingMessageSHA1(List<sbyte> Input)
	{
		//todo check if math checks out
		sbyte[] output = new sbyte[(int)Math.Ceiling((double)Input.Count / 64) * 64];

		//
		for (int i = 0; i < Input.Count; i++)
		{
			output[i] = Input[i];
		}
		
		// calculate amount of 0 needed in padding 
		int k = 60 - Input.Count % 64;

		if (((Input.Count * 8) % 512) < 448)
		{
			throw new ArithmeticException();
		} 
		
		return output.ToList<sbyte>();
	}
}