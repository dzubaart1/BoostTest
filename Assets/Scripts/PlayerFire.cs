using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab;

    public void Fire()
    {
        var bullet = Object.Instantiate(BulletPrefab, Camera.main.transform.position, Quaternion.identity);

        bullet.GetComponent<Rigidbody>().velocity =
            Quaternion.AngleAxis(Random.Range(-3f, 3f), Vector3.up) * Camera.main.transform.forward * 40;
    }
}
