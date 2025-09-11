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
		sbyte[] output = new sbyte[512];

		//
		for (int i = 0; i < Input.Count; i++)
		{
			output[i] = Input[i];
		}
		
		// calculate k 

		if (((Input.Count * 8) % 512) < 448)
		{
			throw new ArithmeticException();
		} 
		
		return output.ToList<sbyte>();
	}
}