using Globals;
using UnityEngine;

namespace Enemy
{
    public class EnemyStatistics : MonoBehaviour
    {
        public EnemyRankType Rank;
        public float MaxHealth;
        public float StepMaxHealthOnUpgrade;
        public int DeathScore;

        private void Start()
        {
            GameplayEventManager.Instance().OnUpgradeLevel.AddListener(Upgrade);
        }
        private void Upgrade()
        {
            Debug.Log("BEFORE " + MaxHealth);
            MaxHealth += StepMaxHealthOnUpgrade;
            Debug.Log("AFTER " + MaxHealth);
        }
    }
}