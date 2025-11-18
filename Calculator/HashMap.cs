using System.Numerics;
using System.Text;
using Calculator.Cryptography;

namespace Calculator;
public class HashMap<TKey, TValue> 
{
	
	private TKey?[] keys;
	private TValue?[] values;
	
	
	private int size;
	//public Dictionary<char, int> map = new Dictionary<char, int>();
	public HashMap(int capacity)
	{
		/*try
		{
			
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			throw;
		}*/
		size = capacity;
		keys = new TKey[capacity];
		values = new TValue[capacity];
		
	}

	public void Add(TKey key, TValue value)
	{
		
		string hash = SHA_1.SHA1(Encoding.UTF8.GetBytes(key.ToString()).ToList());
		BigInteger.TryParse(hash, out BigInteger bigInt);
		int index = (int)(bigInt % size);

		
		// check for collision
		if (EqualityComparer<TKey>.Default.Equals(keys[index], key))//keys[index] != key)
		{
			// search for available room
			index++;
			while (keys[index] != null)
			{
				index++;
			}
			
			/*keys[index] = key;
			values[index] = value;
			
			return;*/
		}
		
		values[index] = value;
		keys[index] = key;
	}

	public TValue? Get(TKey key)
	{
		string hash = SHA_1.SHA1(Encoding.UTF8.GetBytes(key.ToString()).ToList());
		BigInteger.TryParse(hash, out BigInteger bigInt);
		int index = (int)(bigInt % size);
		
		// check presence overflow
		while (!EqualityComparer<TKey>.Default.Equals(keys[index], key))
		{
			index++;
		}
		
		return values[index]; 
	}

	public void Remove(TKey key)
	{
		string hash = SHA_1.SHA1(Encoding.UTF8.GetBytes(key.ToString()).ToList());
		BigInteger.TryParse(hash, out BigInteger bigInt);
		int index = (int)(bigInt % size);

		while (EqualityComparer<TKey>.Default.Equals(keys[index], key))
		{
			index++;
		}
		
		keys[index] = default;
		values[index] = default;
	}

	public void Resize(int newSize)
	{
		TKey[] keysSuccessor = new TKey[newSize];
		TValue[] valuesSuccessor = new TValue[newSize];
		
		// recalc all indexes
		for (int i = 0; i < keys.Length; i++)
		{
			if (keys[i] != null)
			{
				string hash = SHA_1.SHA1(Encoding.UTF8.GetBytes(keys[i].ToString()).ToList());
				BigInteger.TryParse(hash, out BigInteger bigInt);
				int index = (int)(bigInt % size);

				// resolve new collisions
				while (EqualityComparer<TKey>.Default!.Equals(keysSuccessor[index], keys[i]))
				{
					index++;
				}
				
				keysSuccessor[index] = keys[i];
				valuesSuccessor[index] = values[i];
			}
		}
		
		// finalize data 
		keys = keysSuccessor;
		values = valuesSuccessor;
		
		size = newSize;
		throw new NotImplementedException();
	}

	public void Resize()
	{
		//determine size of new array
		int count = 0;
		for (int i = 0; i < keys.Length; i++)
		{
			if (keys[i] is null)
				count++;
		}
		//just reuse existing resize with new size
		Resize(count * 2);
		
		return;
		// todo recalc all indexes
		// todo resolve new collisions
		// todo finalize data 
		
		throw new NotImplementedException();
	}
	
}
