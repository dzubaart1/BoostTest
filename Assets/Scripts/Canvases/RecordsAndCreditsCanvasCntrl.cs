using Data;
using UnityEngine;
using UnityEngine.UI;

namespace Canvases
{
    public class RecordsAndCreditsCanvasCntrl : MonoBehaviour
    {
        [SerializeField] private Text _bestScoreText;

        private CanvasBase _prevCanvas;

        public void SetPrevCanvas(CanvasBase canvasBase)
        {
            _prevCanvas = canvasBase;
            _bestScoreText.text = JsonStorage.Instance().GetScore().ToString();
        }

        public void OnBackBtnClick()
        {
            _prevCanvas.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
