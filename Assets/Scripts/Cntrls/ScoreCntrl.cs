using Globals;
using UnityEngine;

namespace Cntrls
{
    public class ScoreCntrl : MonoBehaviour
    {
        public int CurrentScore { get; private set; }

        private void Start()
        {
            GameplayEventManager.Instance().OnUpdateScoreCount.AddListener(UpdateScoreCount);
        }
        
        private void UpdateScoreCount(int score)
        {
            CurrentScore += score;
            GameplayEventManager.Instance().SendUpdateUIStatisticsSignal();
        }
    }
}
