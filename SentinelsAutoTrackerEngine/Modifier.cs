//----------------------------------------------------
// Copyright 2019 Epic Systems Corporation
//----------------------------------------------------

using System.Collections.Generic;

namespace SentinelsAutoTrackerEngine
{
	public class Modifier
	{
		private static int s_idCounter = 0;
		private static Queue<int> s_orphanedIds = new Queue<int>();
		public int UniqueId { get; private set; }
		public string Name { get; private set; }
		public string Description { get; private set; }
		public ModifierTargets Target { get; private set; }
		public Modifier(string name, string description, ModifierTargets target)
		{
			Name = name;
			Description = description;
			Target = target;
			AssignId();
		}

		private void AssignId()
		{
			if(s_orphanedIds.Count == 0)
			{
				UniqueId = s_idCounter;
				s_idCounter++;
			} else
			{
				UniqueId = s_orphanedIds.Dequeue();
			}
		}

		public void RemoveModifier()
		{
			s_orphanedIds.Enqueue(UniqueId);
		}

		public static void ClearIdCounter()
		{
			s_idCounter = 0;
			s_orphanedIds.Clear();
		}

		public enum ModifierTargets
		{
			Local,
			AllTargets,
			HeroTargets,
			VillainTargets,
			EnvironmentTargets
		}
	}

}
