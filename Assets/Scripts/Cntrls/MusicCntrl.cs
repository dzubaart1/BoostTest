using Globals;
using UnityEngine;

namespace Cntrls
{
    public class MusicCntrl : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        private void Start()
        {
            Settings.Instance().OnChangeAudioVolumeSettings.AddListener(ChangeAudioVolume);
            ChangeAudioVolume(Settings.Instance().GetAudioVolume());
        }

        private void ChangeAudioVolume(float volume)
        {
            _audioSource.volume = volume;
        }
    }
}
