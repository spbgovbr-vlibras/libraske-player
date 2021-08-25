using UnityEngine;
using UnityEngine.UI;

namespace Lavid.Libraske.Avatar
{
    [RequireComponent(typeof(Image))]
    public class CustomizationColorHandler : MonoBehaviour
    {
        [SerializeField] private AvatarCustomizationManager _avatarColorManager;
        [SerializeField] private Color _color;
        private Image _image;

        private void OnEnable()
        {
            _image = GetComponent<Image>();
            _image.color = _color;
        }

        public void ApplyColorToManager()
        {
            if (_avatarColorManager == null)
                return;

            _avatarColorManager.SetColor(_color);
            _avatarColorManager.ApplyColorToProperty();
        }
    }
}