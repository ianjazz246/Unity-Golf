using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

	public GameObject howToPlayScreen;
	public GameObject gangolfImage;
	public GameObject levelSelectScreen;

	private bool gangolfEnabled = false;

	private void Start()
	{
		gangolfEnabled = gangolfImage.activeSelf;
	}
	public void StartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
	public void StartLevel(int sceneIndex)
	{
		SceneManager.LoadScene(sceneIndex);
	}

	public void StartPuzzle()
	{

	}

	public void SetActiveLevelSelectScreen(bool enabled)
	{
		levelSelectScreen.SetActive(enabled);
	}

	public void SetActiveHowToPlayScreen(bool enabled)
	{
		howToPlayScreen.SetActive(enabled);
	}

	public void ToggleGangolf()
	{
		gangolfEnabled = !gangolfEnabled;
		SetActiveGangolfImage(gangolfEnabled);
	}

	public void SetActiveGangolfImage(bool enabled)
	{
		gangolfImage.SetActive(enabled);
	}
}
