using System.Collections;
using UnityEngine;

namespace UnityGolf
{
	public class Timer : MonoBehaviour
	{
		public FloatVariable TimeElapsed;
		[SerializeField]
		private bool isEnabled;
		public bool IsEnabled
		{
			get => isEnabled;
			set
			{
				isEnabled = value;

				//Disable previous coroutine
				if (timeUpdateCoroutine != null)
				{
					StopCoroutine(timeUpdateCoroutine);
				}

				if (isEnabled)
				{
					timeUpdateCoroutine = StartCoroutine(TimeUpdateLoop());
				}
				else
				{
					timeUpdateCoroutine = null;
				}
			}
		}
		[Tooltip("Time in seconds for delay of loop to update time.")]
		public float TimeUpdateDelay = 0.5f;

		private float lastCheckTime = 0;
		private YieldInstruction delay;
		private Coroutine timeUpdateCoroutine;

		public void ResetTime()
		{
			TimeElapsed.Value = 0;
		}

		private void Awake()
		{
			delay = new WaitForSeconds(TimeUpdateDelay);
			timeUpdateCoroutine = StartCoroutine(TimeUpdateLoop());
			lastCheckTime = Time.time;
		}

		/*private void Update()
		{
			if (IsEnabled)
			{
				TimeElapsed.Value += Time.deltaTime;
			}
		}*/

		IEnumerator TimeUpdateLoop()
		{
			while (IsEnabled)
			{
				TimeElapsed.Value += Time.time - lastCheckTime;
				lastCheckTime = Time.time;
				yield return delay;
			}
		}
	}
}