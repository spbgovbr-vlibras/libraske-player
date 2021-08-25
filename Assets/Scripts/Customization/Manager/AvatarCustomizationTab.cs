using UnityEngine;

namespace Lavid.Libraske.Avatar
{
    /// <summary> Customiza itens do avatar.  </summary>
    public class AvatarCustomizationTab : MonoBehaviour
    {
        [SerializeField] GameObject _whenTabEnabled;
        [SerializeField] GameObject _whenTabDisabled;
        [SerializeField] AvatarCustomizationManager _customizationManager;

        [SerializeField, Tooltip("Change close of camera when enable tab")] CameraAnimationCloses _cameraClose;
        [SerializeField] AvatarPropertiesEnum _avatarProperty;

        public void SetPropertyOnManager()
        {
            if (_customizationManager == null)
                return;

            _customizationManager.SetProperty(_avatarProperty);
            _customizationManager.SelectTab(this);
        }

        public void EnableTab(bool value)
        {
            _whenTabEnabled.SetActive(value);
            _whenTabDisabled.SetActive(!value);

            if (value && _customizationManager != null)
                _customizationManager.SetCameraClose(_cameraClose);
        }
    }
}