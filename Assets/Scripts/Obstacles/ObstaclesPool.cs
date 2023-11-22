using System.Collections.Generic;
using Colliders;
using UnityEngine;
using Zenject;

namespace Obstacles
{
    //TEST
    public class ObstaclesPool : MonoBehaviour
    {
        [SerializeField] private List<Collider> obstacleColliders;

        [Inject] private HoleCollidersContainer _holeCollidersContainer;

        private void Start()
        {
            foreach (var collier in obstacleColliders)
            {
                Physics.IgnoreCollision(collier.GetComponent<Collider>(), _holeCollidersContainer.generatedMeshCollider,
                    true);
            }
        }
    }
}