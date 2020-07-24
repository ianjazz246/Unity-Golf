using UnityEngine;

namespace UnityGolf
{
	[CreateAssetMenu(menuName = "Game Config/Player Config")]
	public class PlayerConfig : ScriptableObject
	{
		public string playerName;
		public Color32 ballColor;
		public Material ballMaterial;
		[Tooltip("Distance from smaller edge where dragging to there is max putt strength")]
		public int screenBorderRadius = 20;

		// Ball putt force max force
		public float maxBallPuttForce = 50;
		[Tooltip("From Unity Docs: The mass-normalized energy threshold, below which objects start going to sleep.")]
		public float sleepThreshold;
		[Tooltip("UNUSED The value velocity² must be less than to be considered at rest")]
		public float atRestThreshold = 0.1f;
	}
}