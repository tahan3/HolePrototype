using UnityEngine;
using Zenject;

namespace Counters
{
    public class ObstaclesTrigger : MonoBehaviour
    {
        private ICounter _counter;

        [Inject]
        private void Construct(ICounter counter)
        {
            _counter = counter;
        }
        
        private void OnTriggerEnter(Collider other)
        {
            _counter.Number++;
        }
    }
}