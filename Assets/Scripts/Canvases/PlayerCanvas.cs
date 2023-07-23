using System.Collections;
using Globals;
using UnityEngine;
using UnityEngine.UI;

namespace Canvases
{
    public class PlayerCanvas : MonoBehaviour
    {
        [SerializeField] private Text _levelText;
        [SerializeField] private GameObject FreezeBackground;
        private void Start()
        {
            GameplayEventManager.Instance().OnEndGame.AddListener(() => gameObject.SetActive(false));
            GameplayEventManager.Instance().OnUpgradeLevel.AddListener(() => StartCoroutine(UpgradeLevel()));
            BoostEventManager.Instance().OnFreezeBoostActivate.AddListener(freezeSeconds => StartCoroutine(FreezeScreen(freezeSeconds)));
        }

        private IEnumerator UpgradeLevel()
        {
            _levelText.enabled = true;
            yield return new WaitForSeconds(2);
            _levelText.enabled = false;
        }

        private IEnumerator FreezeScreen(float freezeSeconds)
        {
            FreezeBackground.SetActive(true);
            yield return new WaitForSeconds(freezeSeconds);
            FreezeBackground.SetActive(false);
        }
    }
}
