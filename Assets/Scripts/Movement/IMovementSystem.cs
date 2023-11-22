using UnityEngine;

namespace Movement
{
    public interface IMovementSystem
    {
        public void Move(Vector3 direction);
    }
}