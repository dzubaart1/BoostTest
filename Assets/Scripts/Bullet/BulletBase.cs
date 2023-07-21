using Enemy;
using UnityEngine;

namespace Bullet
{
    public class BulletBase : MonoBehaviour
    {
        [SerializeField] private float _damageAmount;

        private const float MAX_LIFE_TIME = 10f;
    
        private float _currentLifeTime;
    
        public float GetDamage()
        {
            return _damageAmount;
        }
    
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<EnemyHealth>() is not null)
            {
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(_damageAmount);    
            }
            Destroy(gameObject);
        }

        private void Update()
        {
            _currentLifeTime += Time.deltaTime;
            if (_currentLifeTime > MAX_LIFE_TIME)
            {
                Destroy(gameObject);
            }
        }
    }
}
