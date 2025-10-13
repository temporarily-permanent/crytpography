using System.Text;
using Calculator.Cryptography;

namespace Calculator;
public class HashMap<TKey, TValue>
{
	
	TKey[] keys;
	TValue[] values;
	//public Dictionary<char, int> map = new Dictionary<char, int>();
	public HashMap(int capacity)
	{
		keys = new TKey[capacity];
		values = new TValue[capacity];
	}

	public void Add(TKey key, TValue value)
	{
		SHA_1.SHA1(Encoding.UTF8.GetBytes("aaaaaaa").ToList());
		throw new NotImplementedException();

	}

	public TValue Get(TKey key)
	{
		throw new NotImplementedException();
		
	}
	public void Remove(TKey key) { throw new NotImplementedException(); }
	public void Resize(int newSize) { throw new NotImplementedException(); }
	public void Resize() { throw new NotImplementedException(); }
	
}