using System;
using UnityEditor;
using UnityEngine;

namespace UnityGolf
{
	[CustomEditor(typeof(ActionEvent_GameObject))]
	public class ActionEvent_GameObjectInspector : Editor
	{
		Action<GameObject> action;
		public UnityEngine.Object eventParameter;
		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();
			var scriptableObject = (ActionEvent_GameObject)target;
			action = scriptableObject.Action;

			eventParameter = EditorGUILayout.ObjectField("Event Parameter", eventParameter, typeof(GameObject), true);

			if (GUILayout.Button("RunEvent"))
			{
				if (action != null)
				{
					Debug.Log("Action != null");
				}
				else
				{
					Debug.Log("Action == null");
				}
				action?.Invoke((GameObject)eventParameter);
			}
		}
	}
}