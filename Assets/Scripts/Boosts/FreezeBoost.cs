using Globals;
using UnityEngine;

namespace Boosts
{
    public class FreezeBoost : MonoBehaviour, IBoost
    {
        [SerializeField] private float _freezeSeconds;
        
        public void Activate()
        {
            BoostEventManager.Instance().SendFreezeBoostActivateSignal(_freezeSeconds);
            Destroy(gameObject);
        }
    }
}