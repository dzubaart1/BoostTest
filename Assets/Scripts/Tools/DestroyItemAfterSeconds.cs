using UnityEngine;

public class DestroyItemAfterSeconds : MonoBehaviour
{
    [SerializeField] private float _seconds;
    private void Start()
    {
        Destroy(gameObject, _seconds);
    }
}
