using System;
using EventsManagers;
using UnityEngine;
using UnityEngine.UI;

namespace Canvas
{
    public class ScoreCanvasCntrl : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;

        private int _currentScore;

        private void Start()
        {
            GameplayEventManager.OnUpdateScoreCount.AddListener(UpdateScore);
        }

        private void UpdateScore(int score)
        {
            _currentScore += score;
            _scoreText.text = _currentScore.ToString();
        }
    }
}
