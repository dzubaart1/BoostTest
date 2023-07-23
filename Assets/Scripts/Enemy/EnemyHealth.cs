using Globals;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        public EnemyRankType EnemyRank;
        public UnityEvent<HealthInfo> OnTakeDamage = new();

        private float _currentHealth;
        private float _midHealth;
        private int _deathScore;

        private void Start()
        {
            GameplayEventManager.Instance().SendSpawnEnemySignal();
            BoostEventManager.Instance().OnBombBoostActivate.AddListener(Die);
        }
        
        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
            
            if (_currentHealth <= 0)
            {
                Die();
                return;
            }

            if (_currentHealth <= _midHealth)
            {
                OnTakeDamage.Invoke(new HealthInfo(){IsDead = false,IsLowHealth = true});
                return;
            }
            
            OnTakeDamage.Invoke(new HealthInfo(){IsDead = false,IsLowHealth = false});
        }

        private void Die()
        {
            OnTakeDamage.Invoke(new HealthInfo(){IsDead = true,IsLowHealth = true});
            GameplayEventManager.Instance().SendDieEnemySignal();
            GameplayEventManager.Instance().SendUpdateScoreCountSignal(_deathScore);
            Destroy(gameObject);
        }

        public void SetStatistics(EnemyStatistics enemyStatistics)
        {
            _currentHealth = enemyStatistics.MaxHealth;
            _midHealth = enemyStatistics.MaxHealth / 2;
            _deathScore = enemyStatistics.DeathScore;
        }
    }
    public class HealthInfo
    {
        public bool IsDead;
        public bool IsLowHealth;
    }
}