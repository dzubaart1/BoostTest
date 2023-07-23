using Bullet;
using Globals;
using UnityEngine;

namespace Player
{
    public class PlayerFire : MonoBehaviour
    {
        [SerializeField] private BulletCntrl _bulletPrefab;
        [SerializeField] private GameObject _bulletsHolder;
        [SerializeField] private float _stepDamageAmountOnUpgrade;
        [SerializeField] private float _startDamageAmount;
    
        private float _currentDamageAmount;
        private void Start()
        {
            _currentDamageAmount = _startDamageAmount;
            BoostEventManager.Instance().OnUpgradeGunBoostActivate.AddListener(Upgrade);
        }

        public void Fire()
        {
            var bullet = Instantiate(_bulletPrefab, Camera.main.transform.position, Quaternion.identity, _bulletsHolder.transform);
            bullet.SetDamage(_currentDamageAmount);
            bullet.GetComponent<Rigidbody>().velocity =
                Quaternion.AngleAxis(Random.Range(-3f, 3f), Vector3.up) * Camera.main.transform.forward * 40;
        }
    
        private void Upgrade()
        {
            _currentDamageAmount += _stepDamageAmountOnUpgrade;
        }
    }
}
