using UnityEngine.Events;

namespace Globals
{
    public class GameplayEventManager
    {
        public UnityEvent<int> OnUpdateScoreCount = new();
        public UnityEvent OnSpawnEnemy = new();
        public UnityEvent OnDieEnemy = new();
        public UnityEvent OnUpgradeLevel = new();
        public UnityEvent OnEndGame = new();
        public UnityEvent OnStartGame = new();

        private static GameplayEventManager _singleton;
        public static GameplayEventManager Instance()
        {
            return _singleton ??= new GameplayEventManager();
        }

        public void SendStartGamSignal()
        {
            OnStartGame.Invoke();
        }
        public void SendEndGameSignal()
        {
            OnEndGame.Invoke();
        }
        public void SendSpawnEnemySignal()
        {
            OnSpawnEnemy.Invoke();
        }
        public void SendDieEnemySignal()
        {
            OnDieEnemy.Invoke();
        }
        public void SendUpdateScoreCountSignal(int score)
        {
            OnUpdateScoreCount.Invoke(score);
        }
        public void SendUpgradeLevelSignal()
        {
            OnUpgradeLevel.Invoke();
        }
    }
}