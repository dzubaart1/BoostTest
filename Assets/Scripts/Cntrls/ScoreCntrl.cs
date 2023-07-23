using Globals;
using UnityEngine;
using UnityEngine.UI;

namespace Cntrls
{
    public class ScoreCntrl : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;
        [SerializeField] private int _gapOfScoreToUpgrade;

        private int _nextScoreToUpgrade;
        public int CurrentScore { get; private set; }

        private void Start()
        {
            _nextScoreToUpgrade = _gapOfScoreToUpgrade;
            CurrentScore = 0;
            GameplayEventManager.Instance().OnUpdateScoreCount.AddListener(Upgrade);
        }
        
        private void Upgrade(int score)
        {
            CurrentScore += score;
            if (_scoreText)
            {
                _scoreText.text = CurrentScore.ToString();
            }
            if (CurrentScore >= _nextScoreToUpgrade)
            {
                _nextScoreToUpgrade += _gapOfScoreToUpgrade;
                GameplayEventManager.Instance().SendUpgradeLevelSignal();
            }
        } 
    }
}
