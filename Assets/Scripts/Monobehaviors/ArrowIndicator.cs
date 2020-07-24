using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UnityGolf
{
	// Attach to the canvas containing the slider
	public class ArrowIndicator : MonoBehaviour
	{
		public GameObject relativeCamera;
		public float lengthScaleFactor = 0.1f;
		public float maxZScale = 15;
		public BallControlScript ball;
		public Image fillImage;
		public Color minStrengthColor;
		public Color maxStrengthColor;	


		private Slider slider;
		private InputAction dragCancelInputAction;

		private void Awake()
		{
			slider = GetComponent<Slider>();
		}
		// Start is called before the first frame update
		void Start()
		{
			if (ball.relativeCamera != null)
			{
				if (relativeCamera != null)
				{
				}
				relativeCamera = ball.relativeCamera;
			}

			slider = GetComponentInChildren<Slider>();
			slider.maxValue = ball.playerData.maxBallPuttForce;

			dragCancelInputAction = ball.GetComponent<PlayerInput>().actions["Putt"];
			dragCancelInputAction.performed += HandleDragPerform;
			dragCancelInputAction.canceled += HandleDragCancel;
			gameObject.SetActive(false);
		}

		private void OnDestroy()
		{
			// Actions must be unsubscribed in OnDestroy so we can still respond to events after disabling the gameObject
			// to hide it.
			dragCancelInputAction.performed -= HandleDragPerform;
			dragCancelInputAction.canceled -= HandleDragCancel;
		}
		private void HandleDragPerform(InputAction.CallbackContext context)
		{
			var currMousePos = context.ReadValue<Vector2>();
			// Offset of mouse from center of screen
			var mouseCenterOffset = currMousePos - new Vector2(Screen.width / 2.0f, Screen.height / 2.0f);
			float angle = -Mathf.Atan2(mouseCenterOffset.y, mouseCenterOffset.x) * 180 / Mathf.PI + 90;
			if (ball.IsAtRest())
			{
				gameObject.SetActive(true);
				var cameraDirection = Vector3.ProjectOnPlane(relativeCamera.transform.forward, Vector3.up);
				var rotation = Quaternion.LookRotation(cameraDirection) * Quaternion.Euler(90, angle, 0);
				transform.rotation = rotation;
				slider.value = ball.calculateForce(mouseCenterOffset);

				fillImage.color = Color.Lerp(minStrengthColor, maxStrengthColor, slider.value / slider.maxValue);
			}
		}

		private void HandleDragCancel(InputAction.CallbackContext context)
		{
			gameObject.SetActive(false);
		}
	}
}