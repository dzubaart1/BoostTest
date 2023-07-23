using UnityEngine;
using UnityEngine.SceneManagement;

namespace Canvases
{
    public class MenuCanvasCntrl : CanvasBase
    {
        [SerializeField] private SettingsCanvasCntrl SettingsCanvas;
        [SerializeField] private RecordsAndCreditsCanvasCntrl RecordsAndCreditsCanvasCntrl;
        public void OnNewGameBtnClick()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void OnSettingsBtnClick()
        {
            SettingsCanvas.SetPrevCanvas(this);
            SettingsCanvas.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        public void OnRecordsCreditsBtnClick()
        {
            RecordsAndCreditsCanvasCntrl.SetPrevCanvas(this);
            RecordsAndCreditsCanvasCntrl.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        public void OnQuitBtnClick()
        {
            Application.Quit();
        }
    }
}
