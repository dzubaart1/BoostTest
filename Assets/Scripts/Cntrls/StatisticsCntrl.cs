using System.Collections.Generic;
using Enemy;
using UnityEngine;

namespace Cntrls
{
    public class StatisticsCntrl : MonoBehaviour
    {
        [SerializeField] private List<EnemyStatistics> _statistics;

        private Dictionary<int, EnemyStatistics> _enemyDictStatistics;

        private void Start()
        {
            _enemyDictStatistics = new Dictionary<int, EnemyStatistics>();
            foreach (var stat in _statistics)
            {
                if (_enemyDictStatistics.ContainsKey((int)stat.Rank))
                {
                    continue;
                }

                _enemyDictStatistics.Add((int)stat.Rank, stat);
            }
        }

        public EnemyStatistics GetStatisticsByRank(EnemyRankType enemyRankType)
        {
            _enemyDictStatistics.TryGetValue((int)enemyRankType, out var value);
            return value;
        }
    }
}
