using EventsManagers;
using UnityEngine;
using UnityEngine.UI;

namespace Canvas
{
    public class EnemiesCountCanvasCntrl : MonoBehaviour
    {
        [SerializeField] private Text _enemiesCount;

        private const int MAX_ENEMIES_COUNT = 10;

        private int _currentEnemiesCount;

        private void Start()
        {
            GameplayEventManager.OnChangeEnemyCount.AddListener(UpdateEnemiesCount);
        }

        private void UpdateEnemiesCount(int enemyCountChange)
        {
            _currentEnemiesCount += enemyCountChange;
            _enemiesCount.text = _currentEnemiesCount.ToString();

            if (_currentEnemiesCount == MAX_ENEMIES_COUNT)
            {
                GameplayEventManager.SendEndGameSignal();
            }
        }
    }
}
