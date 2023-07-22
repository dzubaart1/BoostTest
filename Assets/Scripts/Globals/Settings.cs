using UnityEngine.Events;

namespace Globals
{
    public class Settings
    {
        public UnityEvent<float> OnChangeAudioVolumeSettings = new();

        private float _audioVolume = 0.2f;
        
        private static Settings _singleton;
        public static Settings Instance()
        {
            return _singleton ??= new Settings();
        }

        public void ChangeAudioVolumeSetting(float volume)
        {
            _audioVolume = volume;
            OnChangeAudioVolumeSettings.Invoke(_audioVolume);
        }

        public float GetAudioVolume()
        {
            return _audioVolume;
        }
    }
}