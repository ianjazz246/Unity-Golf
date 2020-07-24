using System.Collections.Generic;
using UnityEngine;

namespace UnityGolf
{
	public abstract class RuntimeSet<T> : ScriptableObject
	{
		public List<T> Set;
		public void Add(T item)
		{
			if (!Set.Contains(item))
				Set.Add(item);
		}
		public void Remove(T item)
		{
			if (Set.Contains(item))
				Set.Remove(item);
		}
	}
}