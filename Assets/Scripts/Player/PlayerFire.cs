using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _bulletsHolder;

    public void Fire()
    {
        var bullet = Instantiate(_bulletPrefab, Camera.main.transform.position, Quaternion.identity, _bulletsHolder.transform);

        bullet.GetComponent<Rigidbody>().velocity =
            Quaternion.AngleAxis(Random.Range(-3f, 3f), Vector3.up) * Camera.main.transform.forward * 40;
    }
}
