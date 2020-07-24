using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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

		
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		public void SelectLevel()
		{
			Debug.Log("Select Level");
		}

		public void CloseLevelSelectScreen()
		{
			Debug.Log("Close level select screen");
		}
	}
}