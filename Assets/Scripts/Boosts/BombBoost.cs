using Globals;
using UnityEngine;

namespace Boosts
{
    public class BombBoost : MonoBehaviour, IBoost
    {
        public void Activate()
        {
            BoostEventManager.Instance().SendBombBoostActivateSignal();
            Destroy(gameObject);
        }
    }
}