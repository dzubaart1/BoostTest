using Cntrls;
using Data;
using Globals;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Canvases
{
    public class GameOverCanvasCntrl : MonoBehaviour
    {
        [SerializeField] private ScoreCntrl _scoreCntrl;
        [SerializeField] private Text _scoreText;
        private void Start()
        {
            GameplayEventManager.Instance().OnEndGame.AddListener(OnGameOver);
            OnGameOver();
        }

        private void OnGameOver()
        {
            Cursor.lockState = CursorLockMode.Confined;
            _scoreText.text = _scoreCntrl.CurrentScore.ToString();
            if (JsonStorage.Instance().GetScore() < _scoreCntrl.CurrentScore)
            {
                JsonStorage.Instance().Save(_scoreCntrl.CurrentScore);
            }
        }

        public void OnMainMenuBtnClick()
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}
