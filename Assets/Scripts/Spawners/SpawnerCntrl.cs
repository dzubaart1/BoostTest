using System.Collections;
using System.Collections.Generic;
using Globals;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Cntrls
{
    public class SpawnerCntrl : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _spawnElements;
        [SerializeField] private float _minSpawnRate;
        [SerializeField] private float _maxSpawnRate;
        [SerializeField] private GameObject _spawnerContainer;
        [SerializeField] private float _maxSizeArea;

        private bool _isSpawn = true;

        private void Start()
        {
            GameplayEventManager.Instance().OnStartGame.AddListener(StartSpawn);
            GameplayEventManager.Instance().OnEndGame.AddListener(StopSpawn);
            
            BoostEventManager.Instance().OnFreezeBoostActivate.AddListener(freezeSeconds => StartCoroutine(FreezeSpawn(freezeSeconds)));
            StartSpawn();
        }

        private void StartSpawn()
        {
            _isSpawn = true;
            StartCoroutine(Spawn());
        }

        private void StopSpawn()
        {
            _isSpawn = false;
        }

        private IEnumerator FreezeSpawn(float freezeSeconds)
        {
            StopSpawn();
            yield return new WaitForSeconds(freezeSeconds);
            StartSpawn();
        }

        private IEnumerator Spawn()
        {
            yield return new WaitForSeconds(Random.Range(_minSpawnRate, _maxSpawnRate));
            if (_isSpawn)
            {
                Instantiate(_spawnElements[Random.Range(0, _spawnElements.Count)], new Vector3(Random.Range(-_maxSizeArea,_maxSizeArea),0,Random.Range(-_maxSizeArea,_maxSizeArea)),
                Quaternion.identity, _spawnerContainer.transform);
                StartCoroutine(Spawn());
            }
        }
    }
}