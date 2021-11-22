using UnityEngine;
using UnityEngine.EventSystems;

namespace Lavid.Libraske.Touch
{
    public abstract class TouchButtonEffect : MonoBehaviour, ITouchComponent
    {
        protected virtual void OnEnable() { }
        public abstract void OnPointerClick(PointerEventData eventData);
        public abstract void OnPointerDown(PointerEventData eventData);
        public abstract void OnPointerEnter(PointerEventData eventData);
        public abstract void OnPointerExit(PointerEventData eventData);
    }
}