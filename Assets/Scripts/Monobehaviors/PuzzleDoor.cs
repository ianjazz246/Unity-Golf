using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGolf
{
	public class PuzzleDoor : MonoBehaviour, IPuzzleResponder
	{
		public Animator anim;
		public void OpenDoor()
		{
			anim.SetBool("Door Open", true);
		}

		public void CloseDoor()
		{
			anim.SetBool("Door Open", false);
		}

		public void OnSignalOn()
		{
			OpenDoor();
		}

		public void OnSignalOff()
		{
			CloseDoor();
		}
	}
}