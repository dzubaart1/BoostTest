using Globals;

namespace Boosts
{
    public class BombBoost : BaseBoost
    {
        public override void Activate()
        {
            BoostEventManager.Instance().SendBombBoostActivateSignal();
            Destroy(gameObject);
        }
    }
}