using UnityEngine;
using UnityEngine.UI;

namespace Canvases
{
    public class HitCanvasCntrl : MonoBehaviour
    {
        [SerializeField] private Text _hitText;
        [SerializeField] private Animator _animator;

        private void Start()
        {
            _animator.Play("HitTextAnimation");
        }

        public void ChangeHitText(float damage)
        {
            _hitText.text = "-" + damage;
        }
    }
}
