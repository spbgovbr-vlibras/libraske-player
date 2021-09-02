using UnityEngine;

namespace Lavid.Libraske.Avatar
{
    /// <summary> Customiza itens do avatar.  </summary>
    public class AvatarCustomizationTab : MonoBehaviour
    {
        [Header("Renderer")]
        [SerializeField] GameObject _rendererWhenEnabled;
        [SerializeField] GameObject _rendererWhenDisabled;

        [Header("Tab Settings"), Space(3)]
        [SerializeField] GameObject _containerToTrigger;
        [SerializeField] AvatarCustomizationManager _customizationManager;
        [SerializeField, Tooltip("Change close of camera when enable tab")] CameraAnimationCloses _cameraClose;
        [SerializeField] AvatarPropertiesEnum _avatarProperty;

        public void SetPropertyOnManager()
        {
            if (_customizationManager == null)
                return;

            _customizationManager.SetProperty(_avatarProperty);
            _customizationManager.SelectTab(this, _containerToTrigger);
        }

        public void ApplyCameraClose()
        {
            if (_customizationManager != null)
                _customizationManager.SetCameraClose(_cameraClose);
        }

        public void EnableTab(bool value)
        {
            _rendererWhenEnabled.SetActive(value);
            _rendererWhenDisabled.SetActive(!value);
            _containerToTrigger.SetActive(value);
        }
    }
}