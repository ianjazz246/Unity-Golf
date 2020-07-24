using System.Linq;
using TMPro;
using UnityEngine;

namespace UnityGolf
{
	public class KeepInBounds : MonoBehaviour
	{
		public float minY;
		// Tags of objects this object will not be allowed to rest on
		public string[] disallowedTags;
		[Tooltip("The value velocity² must be less than to be considered at rest")]
		private bool checkedAfterSleep = false;
		private bool outOfBounds = false;
		private Vector3 prevLocation;
		private Rigidbody rigidBody;
		private ContactPoint[] contacts;
		private BallControlScript ball;
		// Start is called before the first frame update
		private void Awake()
		{
			rigidBody = GetComponent<Rigidbody>();
			ball = GetComponent<BallControlScript>();
			contacts = new ContactPoint[2];
		}
		void Start()
		{
			prevLocation = transform.position;
		}

		public void SendBackToSafePosition()
		{
			// Send ball back to previous safe location
			transform.position = prevLocation;
			rigidBody.velocity = Vector3.zero;
			rigidBody.angularVelocity = Vector3.zero;
		}

		private void FixedUpdate()
		{
			if (gameObject.transform.position.y < minY)
			{
				SendBackToSafePosition();
			}
			else if (ball.IsAtRest())
			{
				if (!checkedAfterSleep)
				{
					checkedAfterSleep = true;
					if (outOfBounds)
					{
						SendBackToSafePosition();
					}
					else
					{
						prevLocation = transform.position;
					}
				}
			}
			else
			{
				if (checkedAfterSleep)
				{
					checkedAfterSleep = false;
				}
			}
		}

		private void OnCollisionEnter(Collision collision)
		{
			if (disallowedTags.Contains(collision.gameObject.tag))
			{
				outOfBounds = true;
			}
		}

		private void OnCollisionExit(Collision collision)
		{
			if (disallowedTags.Contains(collision.gameObject.tag))
			{
				outOfBounds = false;
			}
		}
/*
		private void OnCollisionStay(Collision collision)
		{
			int numContacts = collision.GetContacts(contacts);
			for (int i = 0; i < numContacts; i++)
			{
				// Make sure the contact point is below the ball,
				// so we know the ball is resting on a surface (ish)
				if (contacts[i].point.y < transform.position.y)
				{
					if (disallowedTags.Contains(collision.gameObject.tag))
					{
						return;
					}
					else
					{
						prevLocation = transform.position;
						return;
					}

				}
			}
		}*/

	}
}