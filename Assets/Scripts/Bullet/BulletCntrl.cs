using Boosts;
using Canvases;
using Enemy;
using Globals;
using UnityEngine;

namespace Bullet
{
    public class BulletCntrl : MonoBehaviour
    {
        [SerializeField] private HitCanvasCntrl _hitCanvas;

        private const float MAX_LIFE_TIME = 10f;

        private float _currentLifeTime;
        private float _currentDamageAmount;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<EnemyHealth>() is not null)
            {
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(_currentDamageAmount);
                var hitCanvas = Instantiate(_hitCanvas, collision.transform.position + new Vector3(0,1,0), Quaternion.identity);
                hitCanvas.ChangeHitText(_currentDamageAmount);
            }
            
            if (collision.gameObject.GetComponent<BaseBoost>() is not null)
            {
                collision.gameObject.GetComponent<BaseBoost>().Activate();
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

        public void SetDamage(float damage)
        {
            _currentDamageAmount = damage;
        }
    }
}
