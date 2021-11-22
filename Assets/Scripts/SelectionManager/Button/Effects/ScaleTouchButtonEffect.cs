using UnityEngine;
using UnityEngine.EventSystems;

namespace Lavid.Libraske.Touch
{
    public class ScaleTouchButtonEffect : TouchButtonEffect
    {
        [SerializeField] GameObjectScaler _scalerController;
        [SerializeField] TouchButtonEventStruct<float> _scales;

        private void SetScale(float value)
        {
            if (_scalerController != null)
                _scalerController.SetScale(value);
        }

        protected override void OnEnable()
        {
            if (_scales.onEnable.IsEnabled)
                SetScale(_scales.onEnable.Value);
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (_scales.onClick.IsEnabled)
                SetScale(_scales.onClick.Value);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            if (_scales.onPointerDown.IsEnabled)
                SetScale(_scales.onPointerDown.Value);
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            if (_scales.onEnter.IsEnabled)
                SetScale(_scales.onEnter.Value);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            if (_scales.onExit.IsEnabled)
                SetScale(_scales.onExit.Value);
        }
    }
}