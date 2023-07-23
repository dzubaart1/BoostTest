using System.Collections;
using Globals;
using UnityEngine;

namespace Enemy
{
    public class EnemyVisual : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _onDieParticleSystem;
        [SerializeField] private ParticleSystem _onMoveParticleSystem;
        [SerializeField] private Material _damageMaterial;
        [SerializeField] private Material _lowHealthMaterial;
        
        
        private Material _defaultMaterial;
        private MeshRenderer _meshRenderer;

        private void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            
            _defaultMaterial = _meshRenderer.material;
            _onMoveParticleSystem.startColor = _meshRenderer.material.color;
        }
        

        public void OnTakeDamageVisual(HealthInfo healthInfo)
        {
            if (healthInfo.IsDead)
            {
                Instantiate(_onDieParticleSystem, transform.position, Quaternion.identity);
                return;
            }
            StartCoroutine(AnimateMaterialOnTakeDamage(healthInfo));
        }
        private IEnumerator AnimateMaterialOnTakeDamage(HealthInfo healthInfo)
        {
            _meshRenderer.material = _damageMaterial;
            yield return new WaitForSeconds(0.1f);
            if (healthInfo.IsLowHealth)
            {
                _meshRenderer.material = _lowHealthMaterial;
                _onMoveParticleSystem.startColor = _meshRenderer.material.color;
            }
            else{
                _meshRenderer.material = _defaultMaterial;
            }
        }
    }
}