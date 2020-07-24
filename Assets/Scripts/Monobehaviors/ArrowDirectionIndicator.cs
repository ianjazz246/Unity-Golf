using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityGolf
{

	// Old. Uses quads instead of slider
	public class ArrowDirectionIndicator : MonoBehaviour
	{
		public GameObject relativeCamera;
		public float lengthScaleFactor = 0.1f;
		public float maxZScale = 15;
		public BallControlScript ball;

		private Material material;
		private InputAction dragCancelInputAction;

		private void Awake()
		{
			material = GetComponentInChildren<MeshRenderer>().material;
			dragCancelInputAction = ball.GetComponent<PlayerInput>().actions["putt"];
			Debug.Log("Arrow Adding input listener");
			dragCancelInputAction.performed += HandleDragPerform;
			dragCancelInputAction.canceled += HandleDragCancel;
		}
		private void Start()
		{
			/*        ball.OnDrag += onDrag;
					ball.OnDragRelease += onDragRelease;*/
			if (ball.relativeCamera != null)
			{
				if (relativeCamera != null)
				{
					Debug.Log("The relative camera assigned to this ArrowDirectionIndicator is being overwritten by the camera by the ball.");
				}
				relativeCamera = ball.relativeCamera;
			}
		}
		private void OnDestroy()
		{
			/*        ball.OnDrag -= onDrag;
					ball.OnDragRelease -= onDragRelease;*/
			Debug.Log("Arrow removing input listener");
			dragCancelInputAction.performed -= HandleDragPerform;
			dragCancelInputAction.canceled -= HandleDragCancel;
		}

		private void HandleDrag(Vector3 initialMousePos, Vector3 currMousePos, float angle)
		{
			if (ball.IsAtRest())
			{
				gameObject.SetActive(true);
				var cameraDirection = Vector3.ProjectOnPlane(relativeCamera.transform.forward, Vector3.up);
				var rotation = Quaternion.LookRotation(cameraDirection) * Quaternion.Euler(0, angle, 0);
				transform.rotation = rotation;

				var newScale = transform.localScale;
				newScale.z = Math.Min(maxZScale, ball.calculateForce(currMousePos - new Vector3(Screen.width / 2, Screen.height / 2)) * lengthScaleFactor);
				transform.localScale = newScale;
				material.SetTextureScale("_MainTex", new Vector3(transform.localScale.x, transform.localScale.z * 4));
			}
		}

		private void HandleDragPerform(InputAction.CallbackContext context)
		{
			Vector2 currMousePos = context.ReadValue<Vector2>();
			var mouseCenterOffset = currMousePos - new Vector2(Screen.width / 2.0f, Screen.height / 2.0f);
			float angle = -Mathf.Atan2(mouseCenterOffset.y, mouseCenterOffset.x) * 180 / Mathf.PI + 90;
			HandleDrag(Vector3.zero, currMousePos, angle);
		}

		private void HandleDragCancel(InputAction.CallbackContext context)
		{
			gameObject.SetActive(false);
		}

		public void updateDirection(float angle, float force)
		{
			var cameraDirection = Vector3.ProjectOnPlane(relativeCamera.transform.forward, Vector3.up);
			Debug.DrawLine(Vector3.zero, cameraDirection);
			var rotation = Quaternion.LookRotation(cameraDirection) * Quaternion.Euler(0, angle, 0);
			transform.rotation = rotation;

			var newScale = transform.localScale;
			newScale.z = force;
			transform.localScale = newScale;
			material.SetTextureScale("_MainTex", new Vector3(transform.localScale.x, transform.localScale.z * 4));
		}
	}
}