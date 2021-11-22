using UnityEngine;
using UnityEngine.EventSystems;

namespace Lavid.Libraske.Touch
{
    public class SoundTouchButtonEffect : TouchButtonEffect
    {
        [SerializeField] AudioHandler _audioController;
        [SerializeField] TouchButtonEventStruct<AudioClip> _sounds;

        private void PlaySound(AudioClip clip)
        {
            if (_audioController != null)
                _audioController.PlayOneShot(clip);
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (_sounds.onClick.IsEnabled)
                PlaySound(_sounds.onClick.Value);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            if (_sounds.onPointerDown.IsEnabled)
                PlaySound(_sounds.onPointerDown.Value);
        }

        public override void OnPointerEnter(PointerEventData eventData)
        {
            if (_sounds.onEnter.IsEnabled)
                PlaySound(_sounds.onEnter.Value);
        }

        public override void OnPointerExit(PointerEventData eventData)
        {
            if (_sounds.onExit.IsEnabled)
                PlaySound(_sounds.onExit.Value);
        }
    }
}