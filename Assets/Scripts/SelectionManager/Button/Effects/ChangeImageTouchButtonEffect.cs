using UnityEngine;
using UnityEngine.EventSystems;

namespace Lavid.Libraske.Touch
{
    public class ChangeImageTouchButtonEffect : TouchButtonEffect
    {
        [SerializeField] TouchButtonEventStruct<GameObject> _images;

        private void SetImage(GameObject image)
        {
            _images.onEnable.Value.SetActive(false);
            _images.onEnter.Value.SetActive(false);
            _images.onExit.Value.SetActive(false);
            image.SetActive(true);
        }

        protected override void OnEnable()
        {
	        if(!EnableEffects)
		        return;
                
            if(_images.onEnable.IsEnabled)
                SetImage(_images.onEnable.Value);
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
	        if(!EnableEffects)
		        return;
                
            if (_images.onClick.IsEnabled)
                SetImage(_images.onClick.Value);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
	        if(!EnableEffects)
		        return;
                
            if (_images.onPointerDown.IsEnabled)
                SetImage(_images.onPointerDown.Value);
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
	        if(!EnableEffects)
		        return;
                
            if (_images.onEnter.IsEnabled)
                SetImage(_images.onEnter.Value);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
	        if(!EnableEffects)
		        return;
                
            if (_images.onExit.IsEnabled)
                SetImage(_images.onExit.Value);
        }
    }
}