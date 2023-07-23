using UnityEngine;

namespace Cntrls
{
    public class StatsCntrl : MonoBehaviour
    {
        [SerializeField] private float _maxEasyEnemyHealth;
        [SerializeField] private float _maxMediumEnemyHealth;
        [SerializeField] private float _maxHardEnemyHealth;
        
        [SerializeField] private float _addingHealthOnUpgrade;
    }
}