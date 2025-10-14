using System.Numerics;
using System.Text;
using Calculator.Cryptography;

namespace Calculator;
public class HashMap<TKey, TValue>
{
	
	private TKey[] keys;
	private TValue[] values;

	private int size;
	//public Dictionary<char, int> map = new Dictionary<char, int>();
	public HashMap(int capacity)
	{
		size = capacity;
		keys = new TKey[capacity];
		values = new TValue[capacity];
	}

	public void Add(TKey key, TValue value)
	{
		
		string hash = SHA_1.SHA1(Encoding.UTF8.GetBytes(key.ToString()).ToList());
		BigInteger.TryParse(hash, out BigInteger bigInt);
		int index = (int)(bigInt % size);
		
		//todo occupancy check
		
		values[index] = value;
		
		//todo resolve
		
		throw new NotImplementedException();
	}

	public TValue Get(TKey key)
	{
		BigInteger hash = new BigInteger(Encoding.UTF8.GetBytes(key.ToString()));
		
		//tood check presence overflow
		//todo resolve correct array item
		
		throw new NotImplementedException();
	}

	public void Remove(TKey key)
	{
		size--;
		throw new NotImplementedException();
	}

	public void Resize(int newSize)
	{
		size = newSize;
		throw new NotImplementedException();
	}
	public void Resize() { throw new NotImplementedException(); }
	
}