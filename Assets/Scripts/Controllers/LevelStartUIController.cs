using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace UnityGolf
{
	public class LevelStartUIController : MonoBehaviour
	{
		public TextMeshProUGUI LevelNameText;
		public TextMeshProUGUI LevelDetailsText;
		public LevelConfig levelConfig;
		private void Awake()
		{
			// Needs to happen before Start so it gets levelConfig when GameController calls SHowLevelStartScreen
			// levelConfig is a reference to scriptableObject, so doesn't depend on code in UIController, only on reference
			if (levelConfig == null)
			{
				levelConfig = GetComponentInParent<UIController>().levelConfig;
			}
		}

		public void ShowLevelStartScreen()
		{
			LevelNameText.text = levelConfig.LevelName;
			LevelDetailsText.text = levelConfig.LevelDescription;
		}

		public void HideLevelStartScreen(float fadeDuration = 0)
		{
			StartCoroutine(FadeOut(fadeDuration));
		}

		/// <summary>
		/// Fades out the level start image over time
		/// </summary>
		/// <param name="fadeDuration">The duration the fade takes, in seconds</param>
		/// <returns></returns>
		public IEnumerator FadeOut(float fadeDuration)
		{
			float startTime = Time.time;
			float endTime = startTime + fadeDuration;
			CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
			float originalAlpha = canvasGroup.alpha;

			while (Time.time <= endTime)
			{
				canvasGroup.alpha = Mathf.Lerp(originalAlpha, 0, (Time.time - startTime) / fadeDuration);
				yield return null;
			}
			canvasGroup.gameObject.SetActive(false);
		}
	}
}