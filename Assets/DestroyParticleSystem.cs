using UnityEngine;

public class DestroyParticleSystem : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }
}
