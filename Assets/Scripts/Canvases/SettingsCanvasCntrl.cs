using Globals;
using UnityEngine;
using UnityEngine.UI;

namespace Canvases
{
    public class SettingsCanvasCntrl : CanvasBase
    {
        [SerializeField] private Slider _slider;

        private CanvasBase _prevCanvas;

        private void Start()
        {
            _slider.value = Settings.Instance().GetAudioVolume();
        }

        public void SetPrevCanvas(CanvasBase canvasBase)
        {
            _prevCanvas = canvasBase;
        }
        
        public void OnVolumeSliderChangeValue()
        {
            Settings.Instance().ChangeAudioVolumeSetting(_slider.value);
        }

        public void OnBackBtnClick()
        {
            _prevCanvas.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}