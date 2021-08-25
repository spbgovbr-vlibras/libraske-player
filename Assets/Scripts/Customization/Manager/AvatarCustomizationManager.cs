using Lavid.Libraske.DataStruct;
using Lavid.Libraske.Util;
using UnityEngine;

namespace Lavid.Libraske.Avatar
{
    public class AvatarCustomizationManager : MonoBehaviour
    {
        [SerializeField] private AvatarCustomizationSO _avatarCustomizationSO;
        [SerializeField] private AvatarCustomizationSO _currentAvatarCustomizationSO;

        [SerializeField] private Wrapper<AvatarCustomizationTab> _customizationTabs;
        [SerializeField] private CameraAnimationController _cameraAnimationController;

        private Color _color;
        private AvatarPropertiesEnum _avatarProperty;

        private void Start() => _avatarCustomizationSO.SetColors(_currentAvatarCustomizationSO.GetColors());

        public void SelectTab(AvatarCustomizationTab tab)
        {
            for(int i = 0; i < _customizationTabs.Length; i++)
            {
                _customizationTabs[i].EnableTab(_customizationTabs[i] == tab);
            }
        }

        public void SetProperty(AvatarPropertiesEnum property) => _avatarProperty = property;
        public void SetColor(Color color) => _color = color;
        public void SetCameraClose(CameraAnimationCloses close)
        {
            if (_cameraAnimationController != null)
                _cameraAnimationController.SetClose(close);
        }

        public void ApplyColorToProperty()
        {
            if (_color == null || _avatarCustomizationSO == null || _avatarProperty == AvatarPropertiesEnum.NULL)
                return;

            _avatarCustomizationSO.ChangePropertyColor(_avatarProperty, (SerializableColor)_color);
        }

        public void SaveCustomizatedColors() => _currentAvatarCustomizationSO.SetColors(_avatarCustomizationSO.GetColors());
    }
}