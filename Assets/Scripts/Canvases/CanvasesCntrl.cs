using Globals;
using UnityEngine;

namespace Canvases
{
    public class CanvasesCntrl : MonoBehaviour
    {
        [SerializeField] private PlayerCanvas PlayerCanvas;
        [SerializeField] private GameOverCanvasCntrl GameOverCanvas;

        private void Start()
        {
            GameplayEventManager.Instance().OnStartGame.AddListener(StartGameCanvases);
            GameplayEventManager.Instance().OnEndGame.AddListener(EndGameCanvases);
            StartGameCanvases();
        }

        private void StartGameCanvases()
        {
            PlayerCanvas.gameObject.SetActive(true);
            GameOverCanvas.gameObject.SetActive(false);
        }

        private void EndGameCanvases()
        {
            PlayerCanvas.gameObject.SetActive(false);
            GameOverCanvas.gameObject.SetActive(true);
        }
    }
}