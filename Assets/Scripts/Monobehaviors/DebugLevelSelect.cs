using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DebugLevelSelect : MonoBehaviour
{
	public bool showUI;
	private int numScenes;

	private void Awake()
	{
		numScenes = SceneManager.sceneCountInBuildSettings;
	}

	private void Update()
	{
		if (Keyboard.current.f1Key.wasPressedThisFrame)
		{
			showUI = !showUI;
		}
	}

	private void OnGUI()
	{
		if (showUI)
		{
			for (int i = 0; i < numScenes; i++)
			{
				if (GUI.Button(new Rect(10, 10 + 35 * i, 50, 30), $"Scene{i}"))
				{
					SceneManager.LoadScene(i);
				}
			}
		}
	}
}
