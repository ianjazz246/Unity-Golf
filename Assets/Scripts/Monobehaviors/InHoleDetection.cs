using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityGolf
{
	public class InHoleDetection : MonoBehaviour
	{
		public float MaxSquaredVelocityForWin;
		public ActionEvent_GameObject WinEvent;
		private void OnTriggerStay(Collider other)
		{
			if (other.gameObject.CompareTag("Player") && !other.gameObject.GetComponent<BallControlScript>().isWon &&
				other.attachedRigidbody.velocity.sqrMagnitude < MaxSquaredVelocityForWin)
			{
				WinEvent.Action?.Invoke(other.gameObject);
			}
		}
	}
}