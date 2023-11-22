using UnityEngine;
using Zenject;

namespace Colliders
{
    public class HoleTrigger : MonoBehaviour
    {
        [Inject] private HoleCollidersContainer _holeCollidersContainer;
        
        private void OnTriggerEnter(Collider other)
        {
            Physics.IgnoreCollision(other, _holeCollidersContainer.groundCollider, true);
            Physics.IgnoreCollision(other, _holeCollidersContainer.generatedMeshCollider, false);
        }

        private void OnTriggerExit(Collider other)
        {
            Physics.IgnoreCollision(other, _holeCollidersContainer.groundCollider, false);
            Physics.IgnoreCollision(other, _holeCollidersContainer.generatedMeshCollider, true);
        }
    }
}