using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UnityGolf
{
	public class UIController : MonoBehaviour
	{
		public TextMeshProUGUI timeDisplay;
		public TextMeshProUGUI strokeDisplay;
		public FloatVariable timeVariable;
		public FloatVariable strokeVariable;
		[Space(5)]
		public LevelStartUIController levelStartUI;
		public LevelCompleteUIController levelCompleteUI;
		[Space(5)]
		public LevelConfig levelConfig;
		//public GameObject player;
		//public GameObject Player {
		//	set
		//	{
		//		dragInputAction.canceled -= UpdateStrokeDisplay;
		//		player = value;
		//		UpdatePlayerReferences();
		//	}
		//	get => player;
		//}

		private BallControlScript playerControl;
		private InputAction dragInputAction;

		private void Awake()
		{

		}

		private void OnDisable()
		{
			//dragInputAction.canceled -= UpdateStrokeDisplay;
		}

		// Start is called before the first frame update
		void Start()
		{
			UpdateTimeDisplay();
			UpdateStrokeDisplay();
		}

		// Update is called once per frame
		void Update()
		{
			UpdateTimeDisplay();
		}

		/*private void UpdatePlayerReferences()
		{
			Debug.Log("UI Controller UpdatePlayerReferences");
			playerControl = player.GetComponent<BallControlScript>();
			dragInputAction = player.GetComponent<PlayerInput>().actions["drag"];
			dragInputAction.canceled += UpdateStrokeDisplay;
		}*/



		public void UpdateTimeDisplay()
		{
			timeDisplay.text = TimeSpan.FromSeconds(timeVariable.Value).ToString(@"mm\:ss");
		}
		public void UpdateStrokeDisplay()
		{
			strokeDisplay.text = strokeVariable.Value.ToString();
		}

		public void ShowLevelStartScreen()
		{
			levelStartUI.gameObject.SetActive(true);
			levelStartUI.ShowLevelStartScreen();
		}

		public void ShowLevelCompleteScreen()
		{
			levelCompleteUI.gameObject.SetActive(true);
			levelCompleteUI.ShowLevelCompleteScreen(timeVariable.Value, strokeVariable.Value);
		}
		public void ShowNextLevelText(string text)
		{
			levelCompleteUI.ShowNextLevelText(text);
		}
		public void HideLevelStartScreen()
		{
			levelStartUI.HideLevelStartScreen(0.3f);
		}
	}
}