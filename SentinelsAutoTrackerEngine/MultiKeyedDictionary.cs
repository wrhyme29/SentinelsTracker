//----------------------------------------------------
// Copyright 2019 Epic Systems Corporation
//----------------------------------------------------

using System.Collections.Generic;

namespace SentinelsAutoTrackerEngine
{
	public class MultiKeyedDictionary<T, P>
	{
		private Dictionary<T, List<P>> _dictionary;
		public int Count { get; private set; }

		public MultiKeyedDictionary()
		{
			_dictionary = new Dictionary<T, List<P>>();
			Count = 0;
		}

		public void Add(T key, P value)
		{
			if(!_dictionary.ContainsKey(key))
			{
				_dictionary.Add(key, new List<P>());
			}
			
				_dictionary[key].Add(value);
			Count++;
		}

		public void Remove(T key, P value)
		{
			_dictionary[key].Remove(value);
			if(_dictionary[key].Count == 0)
			{
				_dictionary.Remove(key);
			}
			Count--;
		}

		public IEnumerable<List<P>> Iterator()
		{
			foreach(List<P> list in _dictionary.Values)
			{
				yield return list;
			}
		}

		public List<P> this[T key]
		{
			get
			{ 
				return _dictionary[key];
			}
		}

		

	}
}
