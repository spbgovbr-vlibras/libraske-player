using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Lavid.Libraske.Touch
{
    public class TouchButton : MonoBehaviour, ITouchComponent
    {
        [Header("Events")]
        [SerializeField] private UnityEvent _onClick;
        [SerializeField] private UnityEvent _onPointerDown;
        [SerializeField] private UnityEvent _onEnter;
        [SerializeField] private UnityEvent _onExit;

        public void OnPointerClick(PointerEventData eventData) => _onClick?.Invoke();
        public void OnPointerDown(PointerEventData eventData) => _onPointerDown?.Invoke();
        public void OnPointerEnter(PointerEventData eventData) => _onEnter?.Invoke();
        public void OnPointerExit(PointerEventData eventData) => _onExit?.Invoke();
    }
}