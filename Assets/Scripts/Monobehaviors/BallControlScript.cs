using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace UnityGolf
{
	public class BallControlScript : MonoBehaviour
	{
		public GameObject arrowObject;
		public PlayerConfig playerData;
		public PlayerRuntimeSet playerRuntimeSet;
		public UIController ui;

		public bool isWon = false;
		// The camera dragging will be relative to
		public GameObject relativeCamera;
		// Max distance to cast ray to ground to check for slope of ground
		public float maxGroundCastDistance;
		public FloatVariable strokesVariable;
		public FloatVariable timeVariable;

		private Vector3 forceDirection;
		private Rigidbody myRigidbody;
		// Scale factor for mouse difference to calculate force for mouse drag
		// Determined by screen size
		private float dragForceScaleFactor;
		private BallAudio ballAudio;
		private Vector3 mouseDragStartPos;
		private Vector3 prevMousePos;
		private InputAction puttInputAction;

		private void Awake()
		{
			var meshRenderer = GetComponent<MeshRenderer>();
			meshRenderer.material = playerData.ballMaterial;

			myRigidbody = GetComponent<Rigidbody>();
			myRigidbody.sleepThreshold = playerData.sleepThreshold;
			ballAudio = GetComponent<BallAudio>();
			dragForceScaleFactor = playerData.maxBallPuttForce / (Math.Min(Screen.width, Screen.height) / 2 - 2 * playerData.screenBorderRadius);
			strokesVariable.Value = 0;
			timeVariable.Value = 0;

			puttInputAction = GetComponent<PlayerInput>().actions["Putt"];
		}

		private void OnEnable()
		{
			puttInputAction.performed += OnDragPerform;
			puttInputAction.canceled += OnDragCancel;

			playerRuntimeSet.Add(this);
		}

		private void OnDisable()
		{
			puttInputAction.performed -= OnDragPerform;
			puttInputAction.canceled -= OnDragCancel;

			playerRuntimeSet.Remove(this);
		}

		// Start is called before the first frame update
		void Start()
		{
		}

		// Update is called once per frame
		void Update()
		{

		}

		/*  private void OnCollisionEnter(Collision collision)
		  {
			  if (collision.gameObject.tag == "Track")
			  {
				  if (collision)
			  }
		  }*/

		public float calculateForce(Vector2 mouseCenterOffset)
		{
			return Math.Min(playerData.maxBallPuttForce, mouseCenterOffset.magnitude * dragForceScaleFactor);
		}

		public void OnMouseDragRelease(Vector3 initialMousePos, Vector3 currentMousePos, float angle)
		{
			if (IsAtRest())
			{
				var mouseOffset = currentMousePos - new Vector3(Screen.width / 2.0f, Screen.height / 2.0f);
				var forceStrength = calculateForce(mouseOffset);
				var cameraDirection = Vector3.ProjectOnPlane(relativeCamera.transform.forward, Vector3.up);
				forceDirection = Quaternion.Euler(0, angle, 0) * cameraDirection.normalized;
				myRigidbody.AddForce(forceStrength / forceDirection.magnitude * forceDirection, ForceMode.Impulse);
				strokesVariable.Value++;


				ballAudio?.PlayPuttSound();
				ui?.UpdateStrokeDisplay();
			}
		}

		public void OnDragPerform(InputAction.CallbackContext context)
		{
			prevMousePos = context.ReadValue<Vector2>();
			//Debug.Log("Performed" + prevMousePos);
		}

		public void OnDragCancel(InputAction.CallbackContext context)
		{
			var mouseCenterOffset = prevMousePos - new Vector3(Screen.width / 2.0f, Screen.height / 2.0f);
			float angle = -Mathf.Atan2(mouseCenterOffset.y, mouseCenterOffset.x) * 180 / Mathf.PI + 90;
			OnMouseDragRelease(Vector3.zero, prevMousePos, angle);
			//Debug.Log("Canceled" + context.ReadValue<Vector2>());
		}

		public void OnGameWin()
		{
			GetComponent<PlayerInput>().DeactivateInput();
			ui.ShowLevelCompleteScreen();
			isWon = true;
		}

		// Returns whether ball is at rest
		public bool IsAtRest()
		{
			//return myRigidbody.velocity.sqrMagnitude < playerData.atRestThreshold;
			return myRigidbody.IsSleeping();
		}
	}
}