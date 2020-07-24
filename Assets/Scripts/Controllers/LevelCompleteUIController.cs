using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UnityGolf
{
	public class LevelCompleteUIController : MonoBehaviour
	{
		public TextMeshProUGUI header;
		public TextMeshProUGUI timeDisplay;
		public TextMeshProUGUI strokeDisplay;
		[Tooltip("Text to enable showing user what to do after level completed.")]
		public TextMeshProUGUI nextLevelText;
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

		public void ShowLevelCompleteScreen(float time, float strokes)
		{
			gameObject.SetActive(true);
			header.text = levelConfig.LevelName + " Completed!";

			// Add formatting with the words "hours", "minutes", "seconds"
			// Such as 69 hours, 69 minutes, 69 seconds
			// TimeSpan timeSpan = TimeSpan.FromSeconds(timeVariable.Value);

			timeDisplay.text = TimeSpan.FromSeconds(time).ToString(@"mm\:ss");
			strokeDisplay.text = strokes.ToString() + " Strokes";
		}

		// Shows text prompting user to perform action to go to next level
		public void ShowNextLevelText(string text)
		{
			nextLevelText.gameObject.SetActive(true);
			if (text != null)
			{
				nextLevelText.text = text;
			}
		}
	}
}