using System.Collections;
using Globals;
using UnityEngine;
using UnityEngine.Events;

namespace Enemy
{
    public class EnemyHealth : MonoBehaviour
    {
        public UnityEvent OnLowHealthState = new();

        [SerializeField] private ParticleSystem _onDieParticleSystem;
        [SerializeField] private Material _damageMaterial;
        [SerializeField] private Material _lowHealthMaterial;
        [SerializeField] private float _maxHealth;
        [SerializeField] private int _deathScore;

        private MeshRenderer _meshRenderer;
        private Material _defaultMaterial;
    
        private float _currentHealth;
        private float _midHealth;

        private void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _defaultMaterial = _meshRenderer.material;
            
            _currentHealth = _maxHealth;
            _midHealth = _maxHealth / 2;
            GameplayEventManager.Instance().SendChangeEnemyCountSignal(1);
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
            
            StartCoroutine(AnimateMaterial());
        }

        private void Die()
        {
            Instantiate(_onDieParticleSystem, transform.position, Quaternion.identity);
            GameplayEventManager.Instance().SendChangeEnemyCountSignal(-1);
            GameplayEventManager.Instance().SendUpdateScoreCountSignal(_deathScore);
            Destroy(gameObject);
        }

        private IEnumerator AnimateMaterial()
        {
            _meshRenderer.material = _damageMaterial;
            yield return new WaitForSeconds(0.1f);
            if (_currentHealth <= _midHealth)
            {
                _meshRenderer.material = _lowHealthMaterial;
                OnLowHealthState.Invoke();
            }
            else
            {
                _meshRenderer.material = _defaultMaterial;
            }
        }
    }
}