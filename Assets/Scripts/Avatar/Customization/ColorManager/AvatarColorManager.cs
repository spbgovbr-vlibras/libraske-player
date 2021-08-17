using Lavid.Libraske.Util;
using UnityEngine;

namespace Lavid.Libraske.Avatar
{
    public class AvatarColorManager : MonoBehaviour
    {
        [SerializeField] private AvatarCustomizationSO _avatarCustomizationSO;
        [SerializeField] private AvatarCustomizationSO _currentAvatarCustomizationSO;

        private Color _color;
        private AvatarPropertiesEnum _avatarProperty;

        private void Start() => _avatarCustomizationSO.SetColors(_currentAvatarCustomizationSO.GetColors());

        public void SetProperty(AvatarPropertyHandlerButton handlerButton) => _avatarProperty = handlerButton.GetAvatarProperty();
        public void SetColor(AvatarColorHandlerButton handlerButton) => _color = handlerButton.GetColor();
        public void ApplyColorToProperty()
        {
            if (_color == null || _avatarCustomizationSO == null || _avatarProperty == AvatarPropertiesEnum.NULL)
                return;

            _avatarCustomizationSO.ChangePropertyColor(_avatarProperty, (SerializableColor)_color);
        }

        public void SaveCustomizatedColors() => _currentAvatarCustomizationSO.SetColors(_avatarCustomizationSO.GetColors());
    }
}