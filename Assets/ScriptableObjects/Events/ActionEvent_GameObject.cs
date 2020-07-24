using System;
using UnityEngine;

namespace UnityGolf
{
	// TODO:
	// Work on way for this to be an interface
	// Allow, at least, no argument handlers to this event
	[CreateAssetMenu(menuName = "ActionEvent/GameObject")]
	public class ActionEvent_GameObject : ScriptableObject
	{
		public Action<GameObject> Action;
	}
}