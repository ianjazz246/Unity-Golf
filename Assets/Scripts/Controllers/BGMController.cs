﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    //public AudioSource bgmAudioSource;
    //public AudioClip bgmClip;

	// Start is called before the first frame update
	private void Awake()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag("music");

		if (objs.Length > 1)
		{
			Destroy(this.gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}
}
