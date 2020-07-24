using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityGolf
{
	public class ThirdPersonCamera : MonoBehaviour
	{
		public Transform target;
		public PlayerInput input;
		public string lookAction;
		public string zoomAction;
		public float sensitivityX = 1;
		public float sensitivityY = 1;
		public float zoomSensitivity = 1;

		public float maxVerticalAngle;
		public float minVerticalAngle;

		public float distanceFromTarget;
		public float minDistanceFromTarget;
		public float maxDistanceFromTarget;

		public float horizontalAngle;
		public float verticalAngle;

		private void OnEnable()
		{
			input.actions[lookAction].performed += HandleLookPerformed;
			input.actions["Zoom"].performed += HandleZoomPerformed;
		}
/*		private void Start()
		{
			var startingHorizontalAngle = Mathf.Atan2(transform.position.x - target.position.x, transform.position.z - target.position.z);
			Debug.Log("Horizontal Angle: " + Mathf.Atan2(transform.position.x - target.position.x, transform.position.z - target.position.z));
			var startingVerticalAngle = Mathf.Atan2(transform.position.x - target.position.x, transform.position.z - target.position.z);
			Debug.Log("Vertical Angle: " + Mathf.Atan2(transform.position.y - target.position.y, transform.position.z - target.position.z));
			
		}*/
		private void OnDisable()
		{
			input.actions[lookAction].performed -= HandleLookPerformed;
			input.actions["Zoom"].performed -= HandleZoomPerformed;
		}

		private void HandleLookPerformed(InputAction.CallbackContext context)
		{
			var pointerDelta = context.ReadValue<Vector2>();
			horizontalAngle += pointerDelta.x * sensitivityX * Constants.CAMERA_ROTATE_X_SCALE;
			horizontalAngle %= 360;
			verticalAngle -= pointerDelta.y * sensitivityY * Constants.CAMERA_ROTATE_Y_SCALE;
			verticalAngle %= 360;
			verticalAngle = Mathf.Clamp(verticalAngle, minVerticalAngle, maxVerticalAngle);
		}

		private void HandleZoomPerformed(InputAction.CallbackContext callback)
		{
			var zoomAmount = callback.ReadValue<float>();
			distanceFromTarget -= zoomAmount * zoomSensitivity * Constants.CAMERA_ZOOM_SCALE;
			distanceFromTarget = Mathf.Clamp(distanceFromTarget, minDistanceFromTarget, maxDistanceFromTarget);
		}

		private void LateUpdate()
		{
			var dir = new Vector3(0, 0, -distanceFromTarget);
			var rotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0);
			transform.position = target.position + rotation * dir;

			transform.LookAt(target);
		}

	}
}