using System;
using Colliders;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace Hole
{
    public class ColliderCreator : MonoBehaviour
    {
        [Inject] private HoleCollidersContainer _holeCollidersContainer;

        private const float ScaleFactor = 0.5f;
        
        private Mesh _generatedMesh;

        //TEST
        private void FixedUpdate()
        {
            if (transform.hasChanged)
            {
                var t = transform;
                var position = t.position;
                var holeTransform = _holeCollidersContainer.hole2DCollider.transform;
                
                t.hasChanged = false;
                holeTransform.position = new Vector2(position.x, position.z);
                holeTransform.localScale = t.localScale * ScaleFactor;
                RecalculateCollider();
            }
        }

        private void RecalculateCollider()
        {
            MakeHole2D();
            Make3DMeshCollider();
        }

        private void MakeHole2D()
        {
            Vector2[] pointPositions = _holeCollidersContainer.hole2DCollider.GetPath(0);

            for (var i = 0; i < pointPositions.Length; i++)
            {
                pointPositions[i] = _holeCollidersContainer.hole2DCollider.transform.TransformPoint(pointPositions[i]);
            }

            _holeCollidersContainer.ground2DCollider.pathCount = 2;
            _holeCollidersContainer.ground2DCollider.SetPath(1, pointPositions);
        }

        private void Make3DMeshCollider()
        {
            if (_generatedMesh != null) Destroy(_generatedMesh);

            _generatedMesh = _holeCollidersContainer.ground2DCollider.CreateMesh(true, true);
            _holeCollidersContainer.generatedMeshCollider.sharedMesh = _generatedMesh;
        }
    }
}
