//----------------------------------------------------
// Copyright 2019 Epic Systems Corporation
//----------------------------------------------------

using System.Collections.Generic;

namespace SentinelsAutoTrackerEngine
{
	public class DictionaryStack<T, P>
	{
		private Dictionary<T, P> _dictionary;
		private Dictionary<P, T> _invDictionary;
		private List<P> _list;

		public DictionaryStack()
		{
			_dictionary = new Dictionary<T, P>();
			_list = new List<P>();
			_invDictionary = new Dictionary<P, T>();
		}

		public void Push(T key, P value)
		{
			_list.Add(value);
			_dictionary.Add(key, value);
			_invDictionary.Add(value, key);

		}

		public P Pop()
		{
			int index = _list.Count - 1;

			if (index >= 0)
			{
				P value = _list[index];
				T key = _invDictionary[value];
				_list.RemoveAt(index);
				_invDictionary.Remove(value);
				_dictionary.Remove(key);

				return value;
			}

			return default(P);
		}

		public P Peek()
		{
			int index = _list.Count - 1;

			if (index >= 0)
			{
				P value = _list[index];
				return value;
			}

			return default(P);
		}

		public P this[T key]
		{
			get { return _dictionary[key]; }
		}

		public void Remove(T key)
		{
			P value = _dictionary[key];

			_dictionary.Remove(key);
			_invDictionary.Remove(value);
			_list.Remove(value);
		}

		public int Count()
		{
			return _dictionary.Count;
		}

	}
}
