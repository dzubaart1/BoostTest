using Globals;

namespace Boosts
{
    public class UpgradeGunBoost : BaseBoost
    {
        public override void Activate()
        {
            BoostEventManager.Instance().SendUpgradeGunBoostActivateSignal();
            Destroy(gameObject);
        }
    }
}