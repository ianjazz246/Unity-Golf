using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;

namespace UnityGolf
{
	[CustomEditor(typeof(ThirdPersonCamera))]
	public class ThirdPersonCameraEditor : Editor
	{
		bool useCurrentOffset;
		Vector2 angles;
		public override void OnInspectorGUI()
		{
			ThirdPersonCamera thirdPersonCamera = (ThirdPersonCamera)target;
			base.OnInspectorGUI();

			//useCurrentOffset = EditorGUILayout.Toggle("Use current camera offset for angles and distance", useCurrentOffset);
/*			useCurrentOffset = EditorGUILayout.Toggle("Use current offset for angles and distance", useCurrentOffset);
			if (useCurrentOffset)
			{
				Vector3 positionDelta = thirdPersonCamera.transform.position - thirdPersonCamera.target.transform.position;
				Debug.Log(positionDelta);
				var horizontalAngle = Mathf.Atan2(positionDelta.z, positionDelta.x) * 180f / Mathf.PI + 90;
				var verticalAngle = Mathf.Atan2(positionDelta.y, positionDelta.z) * 180f / Mathf.PI;
				EditorGUILayout.BeginHorizontal();
				GUI.enabled = false;
				EditorGUIUtility.labelWidth /= 1.5f;
				EditorGUILayout.FloatField("Horizontal Angle", horizontalAngle, GUILayout.ExpandWidth(false));
				EditorGUILayout.FloatField("Vertical Angle", verticalAngle);
				EditorGUILayout.EndHorizontal();
				EditorGUIUtility.labelWidth = 0;
				GUI.enabled = true;
			}*/
		}
	}
}