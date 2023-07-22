using UnityEngine.Events;

namespace Globals
{
    public class GameplayEventManager
    {
        public UnityEvent OnUpdateUIStatistics = new();
        public UnityEvent<int> OnChangeEnemyCount = new();
        public UnityEvent<int> OnUpdateScoreCount = new();
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
        public void SendChangeEnemyCountSignal(int count)
        {
            OnChangeEnemyCount.Invoke(count);
        }
        public void SendUpdateScoreCountSignal(int score)
        {
            OnUpdateScoreCount.Invoke(score);
        }
        public void SendUpdateUIStatisticsSignal()
        {
            OnUpdateUIStatistics.Invoke();
        }
    }
}