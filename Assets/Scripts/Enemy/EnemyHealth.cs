using EventsManagers;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        public UnityEvent OnEnemyDie;
        
        [SerializeField] private Material _damageMaterial;
        [SerializeField] private Material _lowHealthMaterial;
        [SerializeField] private float _maxHealth;
        [SerializeField] private int _deathScore;
    
        private float _currentHealth;
        private float _midHealth;

        private void Start()
        {
            _currentHealth = _maxHealth;
            _midHealth = _maxHealth / 2;
            GameplayEventManager.SendChangeEnemyCountSignal(1);
        }

        public void TakeDamage(float damage)
        {
            _currentHealth -= damage;
        
            if (_currentHealth <= 0)
            {
                GameplayEventManager.SendChangeEnemyCountSignal(-1);
                GameplayEventManager.SendUpdateScoreCountSignal(_deathScore);
                Destroy(gameObject);
            }
        
            if (_currentHealth <= _midHealth)
            {
                GetComponent<MeshRenderer>().material = _lowHealthMaterial;
            }
        }
    }
}