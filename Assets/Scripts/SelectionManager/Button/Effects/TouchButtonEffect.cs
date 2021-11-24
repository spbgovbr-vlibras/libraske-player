using UnityEngine;
using UnityEngine.EventSystems;

namespace Lavid.Libraske.Touch
{
    public abstract class TouchButtonEffect : MonoBehaviour, ITouchComponent
    {
		private bool _enableEffects = true;
		public bool EnableEffects { get => _enableEffects; set => _enableEffects = value; }
		
        protected virtual void OnEnable() { }
        public abstract void OnPointerClick(PointerEventData eventData);
        public abstract void OnPointerDown(PointerEventData eventData);
        public abstract void OnPointerEnter(PointerEventData eventData);
        public abstract void OnPointerExit(PointerEventData eventData);
    }
}