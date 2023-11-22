using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Input
{
    public class ObjectTouchSystem : MonoBehaviour, IInputSystem, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        public event Action<Vector3> OnBeginInput;
        public event Action<Vector3> OnDrag;
        public event Action<Vector3> OnEndInput;

        public void OnPointerDown(PointerEventData eventData)
        {
            OnBeginInput?.Invoke(eventData.pointerCurrentRaycast.worldPosition);
        }

        void IDragHandler.OnDrag(PointerEventData eventData)
        {
            if (eventData.pointerCurrentRaycast.isValid)
            {
                OnDrag?.Invoke(eventData.pointerCurrentRaycast.worldPosition);
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnEndInput?.Invoke(eventData.pointerCurrentRaycast.worldPosition);
        }
    }
}