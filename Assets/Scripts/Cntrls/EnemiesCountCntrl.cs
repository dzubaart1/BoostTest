using Globals;
using UnityEngine;

namespace Cntrls
{
    public class EnemiesCountCntrl : MonoBehaviour
    {
        [SerializeField] private int _maxEnemiesCount;

        public int CurrentEnemiesCount { get; private set; }

        private void Start()
        {
            GameplayEventManager.Instance().OnChangeEnemyCount.AddListener(UpdateEnemiesCount);
        }

        private void UpdateEnemiesCount(int enemyCountChange)
        {
            CurrentEnemiesCount += enemyCountChange;
            GameplayEventManager.Instance().SendUpdateUIStatisticsSignal();
            if (CurrentEnemiesCount == _maxEnemiesCount)
            {
                GameplayEventManager.Instance().SendEndGameSignal();
            }
        }
    }
}
