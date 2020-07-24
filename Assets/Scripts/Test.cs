using System.Diagnostics;
using UnityEngine;

namespace UnityGolf
{
	public class Test : MonoBehaviour
	{
		public GameObject baseObject;
		public int numObjects;

		private Vector3 startPosition;
		// Start is called before the first frame update
		void Start()
		{
			startPosition = transform.position;
			for (int i = 0; i < numObjects; i++)
			{
				startPosition.z += 10;
				Instantiate(baseObject, startPosition, Quaternion.identity);
			}
		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}