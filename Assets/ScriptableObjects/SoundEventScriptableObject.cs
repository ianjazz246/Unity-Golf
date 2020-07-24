using UnityEngine;

namespace UnityGolf
{
	public abstract class SoundEventScriptableObject : ScriptableObject
	{
		public abstract void Play(AudioSource audioSource);
	}
}