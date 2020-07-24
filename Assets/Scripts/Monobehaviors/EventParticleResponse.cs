using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGolf;

public class EventParticleResponse : MonoBehaviour
{
	public ActionEvent_GameObject winEvent;
	public ParticleSystem ps;

	private void OnEnable()
	{
		winEvent.Action += PlayConfetti;
	}

	private void OnDisable()
	{
		winEvent.Action -= PlayConfetti;
	}

	private void PlayConfetti(GameObject _)
	{
		ps.Play();
		var emission = ps.emission;
		emission.enabled = true;
	}
}
