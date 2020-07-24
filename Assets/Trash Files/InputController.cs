using System;
using UnityEngine;

public class InputController : MonoBehaviour
{
	public bool inputEnabled;
	public static event Action<Vector3, Vector3, float> OnDrag;
	public static event Action<Vector3, Vector3, float> OnDragRelease;

	private bool isDragging = false;
	private Vector3 mouseDragStartPos;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (inputEnabled)
		{
			// Should only allow isDragging if ball is at rest
			// GetButtonDown only detects the first time its down and not after that until released and pressed again
			if (Input.GetButtonDown("Fire1"))
			{
				if (!isDragging)
				{
					mouseDragStartPos = Input.mousePosition;
				}
				else
				{
				}
				isDragging = true;
			}
			else if (isDragging)
			{
				var mousePos = Input.mousePosition;
				var mouseCenterOffset = mousePos - new Vector3(Screen.width / 2.0f, Screen.height / 2.0f);
				float angle = -Mathf.Atan2(mouseCenterOffset.y, mouseCenterOffset.x) * 180 / Mathf.PI + 90;
				// If mouse button is still down during the drag
				if (Input.GetButton("Fire1"))
				{
					OnDrag?.Invoke(mouseDragStartPos, mousePos, angle);
				}
				// User has released mouse during drag
				else
				{
					isDragging = false;
					OnDragRelease?.Invoke(mouseDragStartPos, mousePos, angle);
					Debug.Log("Drag released");
				}
			}
		}
	}
}
