using UnityEngine;
using UnityEngine.UI;

namespace Lavid.Libraske.Avatar
{
    [RequireComponent(typeof(Image))]
    public class AvatarColorHandlerButton : TouchSelection
    {
        [SerializeField] private Color _color;
        private Image _image;

        private void OnEnable()
        {
            _image = GetComponent<Image>();
            _image.color = _color;
        }

        public Color GetColor() => _color;
    }
}