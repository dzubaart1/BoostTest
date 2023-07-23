using System.Collections;
using System.Collections.Generic;
using Enemy;
using Globals;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Cntrls
{
    public class SpawnerCntrl : MonoBehaviour
    {
        [Header("Spawn Objects Initial")]
        [SerializeField] private List<EnemyHealth> _enemiesList;
        [SerializeField] private List<GameObject> _boostsList;
        
        [Header("Rate Initial")]
        [SerializeField] private float _maxEnemiesSpawnRate;
        [SerializeField] private float _stepEnemiesSpawnRateOnUpgrade;
        [SerializeField] private float _maxBoostsSpawnRate;
        [SerializeField] private float _stepBoostsSpawnRateOnUpgrade;

        [SerializeField] private float _minSpawnRate;
        
        [Header("Other Settings")]
        [SerializeField] private float _maxSizeArea;
        [SerializeField] private GameObject _spawnerContainer;
        [SerializeField] private StatisticsCntrl _statisticsCntrl;
        
        private bool _isSpawn = true;
        private void Start()
        {
            GameplayEventManager.Instance().OnStartGame.AddListener(StartSpawn);
            GameplayEventManager.Instance().OnEndGame.AddListener(StopSpawn);
            GameplayEventManager.Instance().OnUpgradeLevel.AddListener(Upgrade);
            
            BoostEventManager.Instance().OnFreezeBoostActivate.AddListener(freezeSeconds => StartCoroutine(FreezeSpawn(freezeSeconds)));
            StartSpawn();
        }

        private void StartSpawn()
        {
            _isSpawn = true;
            StartCoroutine(SpawnBoost());
            StartCoroutine(SpawnEnemy());
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

        private IEnumerator SpawnEnemy()
        {
            if (!_isSpawn)
            {
                yield break;
            }
            
            yield return new WaitForSeconds(Random.Range(_minSpawnRate, _maxEnemiesSpawnRate));

            var enemyId = Random.Range(0, _enemiesList.Count);
            var enemySpawnPosition = new Vector3(Random.Range(-_maxSizeArea, _maxSizeArea), 0,
                Random.Range(-_maxSizeArea, _maxSizeArea));
            
            
            var spawnedEnemy = Instantiate(_enemiesList[enemyId], enemySpawnPosition, 
                Quaternion.identity, _spawnerContainer.transform);
            
            spawnedEnemy.SetStatistics(_statisticsCntrl.GetStatisticsByRank(spawnedEnemy.EnemyRank));
            
            StartCoroutine(SpawnEnemy());
        }
        
        private IEnumerator SpawnBoost()
        {
            if (!_isSpawn)
            {
                yield break;
            }
            
            yield return new WaitForSeconds(Random.Range(_minSpawnRate, _maxBoostsSpawnRate));

            var boostId = Random.Range(0, _boostsList.Count);
            var boostSpawnPosition = new Vector3(Random.Range(-_maxSizeArea, _maxSizeArea), 0,
                Random.Range(-_maxSizeArea, _maxSizeArea));
            
            Instantiate(_boostsList[boostId], boostSpawnPosition, 
                Quaternion.identity, _spawnerContainer.transform);

            StartCoroutine(SpawnBoost());
        }

        private void Upgrade()
        {

            _maxBoostsSpawnRate -= _stepBoostsSpawnRateOnUpgrade;
            if (_maxBoostsSpawnRate <= _minSpawnRate)
            {
                _maxBoostsSpawnRate = _minSpawnRate;
            }

            _maxEnemiesSpawnRate -= _stepEnemiesSpawnRateOnUpgrade;
            if (_maxEnemiesSpawnRate <= _minSpawnRate)
            {
                _maxEnemiesSpawnRate = _minSpawnRate;
            }
        }
    }
}