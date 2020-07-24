using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace UnityGolf
{
	public class LevelSelector : MonoBehaviour
	{
		public UnityEngine.UI.Button loadLevelButton;
		public UnityEngine.UI.Button cancelButton;
		public TMP_Dropdown dropdownMenu;
		public List<LevelList> levelLists;

		public List<int> indexList= new List<int>();

		public void Awake()
		{
			List<string> levelNames = new List<string>();
			foreach (LevelList levelList in levelLists)
			{
				foreach (LevelConfig level in levelList.levelConfigs)
				{
					levelNames.Add(level.LevelName);
					indexList.Add(level.sceneBuildIndex);
				}
			}
			dropdownMenu.ClearOptions();
			dropdownMenu.AddOptions(levelNames);
		}

		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		public void SelectLevel(int value)
		{
			SceneManager.LoadScene(indexList[value]);
		}

		public void CloseLevelSelectScreen()
		{
			Debug.Log("Close level select screen");
			gameObject.SetActive(false);
		}
	}
}