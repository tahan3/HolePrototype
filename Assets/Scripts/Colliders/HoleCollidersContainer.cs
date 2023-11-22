using System;
using UnityEngine;

namespace Colliders
{
    [Serializable]
    public class HoleCollidersContainer
    {
        public PolygonCollider2D hole2DCollider;
        public PolygonCollider2D ground2DCollider;
        public MeshCollider generatedMeshCollider;
        public Collider groundCollider;
    }
}