using UnityEngine;
using UnityEngine.UI;

namespace Canvases
{
    public class ChangeTextColorOnHover : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private Color _onHover;

        private Color _defaultColor;
        
        private void Start()
        {
            _defaultColor = _text.color;
        }

        public void OnEnterHover()
        {
            _text.color = _onHover;
        }

        public void OnExitHover()
        {
            _text.color = _defaultColor;
        }
    }
}
