namespace _1_Scripts
{
    public interface IAudioService
    {
        public void ChangeMusicVolume(float value);
        public void ChangeEffectsVolume(float value);
        public void ToggleMusic(bool value);
        public void ToggleEffects(bool value);
    }
}