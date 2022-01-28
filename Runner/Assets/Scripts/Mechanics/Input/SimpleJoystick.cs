using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Mechanics.Input
{
    public class SimpleJoystick : MonoBehaviour, IPointerDownHandler, IEndDragHandler,   IDragHandler, IPointerUpHandler
    {
        [SerializeField]
        float radius;

        [SerializeField]
        RectTransform pointer;

        Vector2 direction;

        public Vector2 Direction { get => direction; }

        public static SimpleJoystick instance;
        private void Awake()
        {
            instance = this;
        }

        public void OnDrag(PointerEventData eventData)
        {
            SetJoystickInput(eventData);
        }

        private void SetJoystickInput(PointerEventData eventData)
        {
            pointer.transform.position = eventData.position;
            pointer.localPosition = Vector3.ClampMagnitude(pointer.localPosition, radius);
            direction = pointer.localPosition / radius;
        }

        
        public void OnEndDrag(PointerEventData eventData)
        {
            direction = Vector2.zero;
            pointer.localPosition = Vector3.zero;
        }
        
        public void OnPointerDown(PointerEventData eventData)
        {
            SetJoystickInput(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            direction = Vector2.zero;
            pointer.localPosition = Vector3.zero;
        }
    }
}