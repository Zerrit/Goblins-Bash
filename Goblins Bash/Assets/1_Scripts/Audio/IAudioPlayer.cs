using UnityEngine;

namespace _1_Scripts
{
    public interface IAudioPlayer
    {
        public void PlayEffect(AudioClip clip);
        public void PlayMusic(AudioClip clip);
    }
}