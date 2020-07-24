using UnityEngine;

namespace UnityGolf
{
	[CreateAssetMenu(menuName = "Game Config/Level Config")]
	public class LevelConfig : ScriptableObject
	{
		public string LevelName = "Unnamed Level";
		[TextArea]
		public string LevelDescription = "Insert Description";
		// Should be removed when we use level list config.
		[Tooltip("If this is the last level in its set, this should be true.")]
		public bool returnToMainMenuOnComplete = false;
		public float MaxTime;
		public float RecommendedStrokes;
		public int sceneBuildIndex;
	}
}