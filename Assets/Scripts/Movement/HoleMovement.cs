using Input;
using UnityEngine;

namespace Movement
{
    public class HoleMovement : IMovementSystem
    {
        private Rigidbody _target;

        public HoleMovement(IInputSystem inputSystem, Rigidbody target)
        {
            inputSystem.OnDrag += Move;
            inputSystem.OnBeginInput += Move;

            _target = target;
        }

        public void Move(Vector3 direction)
        {
            _target.MovePosition(direction);
        }
    }
}