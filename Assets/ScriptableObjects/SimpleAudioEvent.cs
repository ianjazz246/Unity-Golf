using UnityEngine;

namespace UnityGolf
{
	[CreateAssetMenu(fileName = "SimpleAudioEvent", menuName = "Audio Events/Simple")]
	public class SimpleAudioEvent : SoundEventScriptableObject
	{
		public AudioClip[] audioClips;
		public Vector2 volumeRange;
		public Vector2 pitchRange;

		public override void Play(AudioSource audioSource)
		{
			if (audioClips.Length <= 0) return;
			AudioClip clip = audioClips[Random.Range(0, audioClips.Length)];
			float volume = Random.Range(volumeRange.x, volumeRange.y);
			float pitch = Random.Range(pitchRange.x, pitchRange.y);
			audioSource.pitch = pitch;
			audioSource.PlayOneShot(clip, volume);
		}
	}
}