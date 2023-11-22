using System;
using UnityEngine;

namespace Input
{
    public interface IInputSystem
    {
        public event Action<Vector3> OnBeginInput;
        public event Action<Vector3> OnDrag;
        public event Action<Vector3> OnEndInput;
    }
}