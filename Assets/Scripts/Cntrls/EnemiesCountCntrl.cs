using Globals;
using UnityEngine;
using UnityEngine.UI;

namespace Cntrls
{
    public class EnemiesCountCntrl : MonoBehaviour
    {
        [SerializeField] private Text _enemiesCountText;
        [SerializeField] private int _maxEnemiesCount;

        public int CurrentEnemiesCount { get; private set; }

        private void Start()
        {
            GameplayEventManager.Instance().OnDieEnemy.AddListener(()=>UpdateEnemiesCount(-1));
            GameplayEventManager.Instance().OnSpawnEnemy.AddListener(()=>UpdateEnemiesCount(1));
        }

        private void UpdateEnemiesCount(int enemyCountChange)
        {
            CurrentEnemiesCount += enemyCountChange;
            if (_enemiesCountText)
            {
                _enemiesCountText.text = CurrentEnemiesCount.ToString();
            }
            if (CurrentEnemiesCount == _maxEnemiesCount)
            {
                GameplayEventManager.Instance().SendEndGameSignal();
            }
        }
    }
}
