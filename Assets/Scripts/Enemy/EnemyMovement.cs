using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemyMovement : MonoBehaviour
    {
        [SerializeField] private float _randomPointRadius;
        [SerializeField] private NavMeshAgent _agent;
        
        private Vector3 _nextRandomPoint;
        private NavMeshPath _navMeshPath;

        private void Start()
        {
            _navMeshPath = new NavMeshPath();

        }

        private void Update()
        {
            if (_agent.remainingDistance < 1)
            {
                NavigateRandomPoint();
            }
        }

        private void NavigateRandomPoint()
        {
            var getCorrectPoint = false;

            while (!getCorrectPoint)
            {
                NavMeshHit navMeshHit;
                NavMesh.SamplePosition(Random.insideUnitSphere * _randomPointRadius, out navMeshHit, _randomPointRadius,
                    NavMesh.AllAreas);

                _nextRandomPoint = navMeshHit.position;

                _agent.CalculatePath(_nextRandomPoint, _navMeshPath);
                if (_navMeshPath.status == NavMeshPathStatus.PathComplete)
                {
                    getCorrectPoint = true;
                }

                _agent.SetDestination(_nextRandomPoint);
            }
        }
    }
}
