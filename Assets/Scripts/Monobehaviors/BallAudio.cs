using UnityEngine;

namespace UnityGolf
{
	public class BallAudio : MonoBehaviour
	{
		[Tooltip("SoundEvent to play when this collides with something and other object has no sound.")]
		public SoundEventScriptableObject collideDefaultSoundEffect;
		public SoundEventScriptableObject puttSoundEffect;
		public AudioSource audioSource;

		// Start is called before the first frame update
		void Start()
		{
		}

		// Update is called once per frame
		void Update()
		{

		}

		public void PlayPuttSound()
		{
			puttSoundEffect?.Play(audioSource);
		}

		private void OnCollisionEnter(Collision collision)
		{
			ObstacleAudio audio = collision.gameObject.GetComponent<ObstacleAudio>();
			if (audio != null)
			{
				audio.onCollideSoundEvent.Play(audioSource);
			}
			else
			{
				collideDefaultSoundEffect.Play(audioSource);
			}
		}
	}
}