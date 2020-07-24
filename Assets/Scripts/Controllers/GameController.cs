using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace UnityGolf
{
	public class GameController : MonoBehaviour
	{
		public ActionEvent_GameObject WinAction;

		public UIController uiController;
		public LevelConfig levelConfig;
		public PlayerRuntimeSet playerList;

		public LevelList levelList;
		// Index of level within levelList.levelConfigs
		public int levelIndex;

		private bool isLastLevel;
		private PlayerInput mainPlayerInput;

		private void Awake()
		{
			levelIndex = levelList.levelConfigs.IndexOf(levelConfig);
			isLastLevel = (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1) ||
				levelConfig.returnToMainMenuOnComplete || levelIndex == levelList.levelConfigs.Count;
		}

		// Start is called before the first frame update
		private void Start()
		{
			// Level first started
			mainPlayerInput = playerList.Set[0].GetComponent<PlayerInput>();
			OnLevelStart();
		}

		private void OnEnable()
		{
			WinAction.Action += OnPlayerWin;
		}

		private void OnDisable()
		{
			WinAction.Action -= OnPlayerWin;
		}

		private void OnLevelStart()
		{
			uiController.ShowLevelStartScreen();
			mainPlayerInput.gameObject.GetComponent<BallControlScript>().timeVariable.Value = 0;
			
			mainPlayerInput.SwitchCurrentActionMap("Level Starting");
			mainPlayerInput.actions["Level Starting/AnyKeyPressed"].performed += OnLevelStartAnyKeyPressed;
		}
		private void OnLevelStartAnyKeyPressed(InputAction.CallbackContext _)
		{
			PlayerInput mainPlayerInput = playerList.Set[0].GetComponent<PlayerInput>();
			mainPlayerInput.SwitchCurrentActionMap("Player");
			uiController.HideLevelStartScreen();
			mainPlayerInput.actions["Level Starting/AnyKeyPressed"].performed -= OnLevelStartAnyKeyPressed;
		}

		private void OnPlayerWin(GameObject player)
		{
			if (!player.GetComponent<BallControlScript>().isWon)
			{
				player.GetComponent<BallControlScript>().OnGameWin();
				player.GetComponent<Timer>().IsEnabled = false;
				player.layer = Constants.WON_PLAYERS_LAYER;
			}
			if (AllPlayersWon())
			{
				string levelEndText = isLastLevel ? "Hit any key to return to main menu" : "Hit any key to continue";
				PlayerInput mainPlayerInput = playerList.Set[0].GetComponent<PlayerInput>();
				mainPlayerInput.SwitchCurrentActionMap("Level Complete");
				mainPlayerInput.actions["Level Complete/AnyKeyPressed"].performed += NextLevel;
				foreach (var aPlayer in playerList.Set)
				{
					aPlayer.ui.ShowNextLevelText(levelEndText);
				}
			}
		}

		private bool AllPlayersWon()
		{
			if (playerList.Set.Count == 1)
			{
				return playerList.Set[0].isWon;
			}

			foreach (var aPlayer in playerList.Set)
			{
				if (!aPlayer.isWon)
				{
					return false;
				}
			}
			return true;
		}

		private void NextLevel(InputAction.CallbackContext _)
		{
			NextLevel();
		}

		private void NextLevel()
		{
			mainPlayerInput.actions["Level Complete/AnyKeyPressed"].performed -= NextLevel;
			if (isLastLevel)
			{
				SceneManager.LoadScene(Constants.MAIN_MENU_SCENE_NAME);
			}
			else
			{
				SceneManager.LoadScene(levelList.levelConfigs[levelIndex+1].sceneBuildIndex);
			}
		}

		// Update is called once per frame
		void Update()
		{
		}
	}
}