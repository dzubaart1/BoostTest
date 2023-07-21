using System.Collections;
using System.Collections.Generic;
using EventsManagers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Spawner
{
    public class SpawnerCntrl : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _spawnElements;
        [SerializeField] private int _maxSpawnRate;
        [SerializeField] private GameObject _spawnerContainer;
        
        private bool _isSpawn = true;

        private void Start()
        {
            GameplayEventManager.OnStartGame.AddListener(StartSpawn);
            GameplayEventManager.OnEndGame.AddListener(StopSpawn);
            StartCoroutine(Spawn());
        }

        private void StartSpawn()
        {
            _isSpawn = true;
        }

        private void StopSpawn()
        {
            _isSpawn = false;
        }

        private IEnumerator Spawn()
        {
            yield return new WaitForSeconds(Random.Range(1, _maxSpawnRate));
            if (_isSpawn)
            {
                Instantiate(_spawnElements[Random.Range(0, _spawnElements.Count)], Random.insideUnitCircle * 5,
                Quaternion.identity, _spawnerContainer.transform);
                StartCoroutine(Spawn());
            }
        }
    }
}