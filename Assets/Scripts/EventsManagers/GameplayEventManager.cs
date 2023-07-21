using UnityEngine.Events;

namespace EventsManagers
{
    public class GameplayEventManager
    {
        public static UnityEvent<int> OnChangeEnemyCount = new UnityEvent<int>();
        public static UnityEvent<int> OnUpdateScoreCount = new UnityEvent<int>();
        public static UnityEvent OnEndGame = new UnityEvent();
        public static UnityEvent OnStartGame = new UnityEvent();
        
        public static void SendStartGamSignal()
        {
            OnStartGame.Invoke();
        }
        public static void SendEndGameSignal()
        {
            OnEndGame.Invoke();
        }
        public static void SendChangeEnemyCountSignal(int count)
        {
            OnChangeEnemyCount.Invoke(count);
        }
        public static void SendUpdateScoreCountSignal(int score)
        {
            OnUpdateScoreCount.Invoke(score);
        }
    }
}