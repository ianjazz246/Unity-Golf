using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGolf
{
	[CreateAssetMenu(menuName = "Game Config/Level List")]
	public class LevelList : ScriptableObject
	{
		public string listName;
		public string listDescription;
		public List<LevelConfig> levelConfigs;
	}
}