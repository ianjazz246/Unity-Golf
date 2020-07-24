using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace UnityGolf
{
	public class PuzzleButtonUnlatched : MonoBehaviour
	{
		public Transform buttonPad;
		public UnityEvent onButtonPress;
		public UnityEvent onButtonRelease;
		// Start is called before the first frame update
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{

		}

		private void OnTriggerEnter(Collider other)
		{
			onButtonPress.Invoke();
		}
		private void OnTriggerExit(Collider other)
		{
			onButtonRelease.Invoke();
		}
	}
}