using Globals;
using UnityEngine;

namespace Boosts
{
    public class FreezeBoost : BaseBoost
    {
        [SerializeField] private float _freezeSeconds;
        
        public override void Activate()
        {
            BoostEventManager.Instance().SendFreezeBoostActivateSignal(_freezeSeconds);
            Destroy(gameObject);
        }
    }
}