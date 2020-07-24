using UnityEngine;
using UnityEngine.Events;

namespace UnityGolf
{
	public class InHole : MonoBehaviour
	{
		UnityEvent inHole;
		// Start is called before the first frame update

		double holeY = 51; //the y the ball needs to be below for it to be in the hole
		double holeRad = 5; //radius of flag, I dont know what this is right now

		void Start()
		{
			if (inHole == null)
				inHole = new UnityEvent();

			inHole.AddListener(NextLevel);
		}

		// Update is called once per frame
		void Update()
		{
			float holeX = GameObject.Find("flag").transform.position.x;
			float holeZ = GameObject.Find("flag").transform.position.z;
			float ballX = transform.position.x;
			float ballY = transform.position.y;
			float ballZ = transform.position.z;

			if (Mathf.Abs(holeX - ballX) < holeRad && Mathf.Abs(holeZ - ballZ) < holeRad && ballY < holeY && inHole != null)
			{
				inHole.Invoke();
			}
		}

		void NextLevel()
		{
			Debug.Log("Ball in Hole");
		}

	}
}