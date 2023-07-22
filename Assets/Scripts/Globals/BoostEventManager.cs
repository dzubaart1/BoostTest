using UnityEngine.Events;

namespace Globals
{
    public class BoostEventManager
    {
        public UnityEvent OnBombBoostActivate = new();
        public UnityEvent<float> OnFreezeBoostActivate = new();
        
        private static BoostEventManager _singleton;
        public static BoostEventManager Instance()
        {
            return _singleton ??= new BoostEventManager();
        }

        public void SendBombBoostActivateSignal()
        {
            OnBombBoostActivate.Invoke();
        }

        public void SendFreezeBoostActivateSignal(float seconds)
        {
            OnFreezeBoostActivate.Invoke(seconds);
        }
    }
}