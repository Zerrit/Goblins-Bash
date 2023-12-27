using UnityEngine;
using Zenject;

namespace _1_Scripts.Audio
{
	public class AudioService : MonoBehaviour, IAudioPlayer, IAudioService
	{
		[SerializeField] private AudioSource musicSource, effectsSource; 


		public void PlayEffect (AudioClip clip)
		{
			effectsSource.PlayOneShot(clip);
		}
		public void PlayMusic(AudioClip clip)
		{
			musicSource.PlayOneShot(clip);
		}
		
		public void ChangeMusicVolume(float value) => musicSource.volume = value;
		public void ChangeEffectsVolume(float value) => effectsSource.volume = value;
		public void ToggleMusic(bool value) => musicSource.mute = value;
		public void ToggleEffects(bool value) => effectsSource.mute = value;
	}
}
