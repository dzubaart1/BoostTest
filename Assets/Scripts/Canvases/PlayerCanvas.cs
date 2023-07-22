using System.Collections;
using Cntrls;
using Globals;
using UnityEngine;
using UnityEngine.UI;

namespace Canvases
{
    public class PlayerCanvas : MonoBehaviour
    {
        
        
        [SerializeField] private ScoreCntrl _scoreCntrl;
        [SerializeField] private EnemiesCountCntrl _enemiesCountCntrl;
        [SerializeField] private Text _scoreText;
        [SerializeField] private Text _enemiesCountText;
        [SerializeField] private GameObject FreezeBackground;
        private void Start()
        {
            GameplayEventManager.Instance().OnUpdateUIStatistics.AddListener(UpdateUIStatistics);
            BoostEventManager.Instance().OnFreezeBoostActivate.AddListener(freezeSeconds => StartCoroutine(FreezeScreen(freezeSeconds)));
        }

        private void UpdateUIStatistics()
        {
            _scoreText.text = _scoreCntrl.CurrentScore.ToString();
            _enemiesCountText.text = _enemiesCountCntrl.CurrentEnemiesCount.ToString();
        }

        private IEnumerator FreezeScreen(float freezeSeconds)
        {
            FreezeBackground.SetActive(true);
            yield return new WaitForSeconds(freezeSeconds);
            FreezeBackground.SetActive(false);
        }
    }
}
