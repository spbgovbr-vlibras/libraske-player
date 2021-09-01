using Lavid.Libraske.Util;
using UnityEngine;

namespace Lavid.Libraske.Avatar
{
    /// <summary> Connect colors to Avatar's renderer materials </summary>
    public class AvatarVLibras : MonoBehaviour, IAvatarCustomizationObserver
    {
        [SerializeField] private AvatarStruct<SkinnedMeshRenderer> _renderer;
        [SerializeField, Tooltip("Avatar Customization Scriptable Object")] private AvatarCustomizationSO _customizationSO;

        [SerializeField] private string _avatarName;

        private void OnEnable()
        {
            if(_customizationSO != null)
            {
                SetupColorsFromScriptableObject();
                _customizationSO.AddObserver(this);
            }
        }

        public void SetupColorsFromScriptableObject()
        {
            if (_customizationSO != null)
                SetupColors(_customizationSO.GetColors());
        }

        public void OnCustomizationUpdate() => SetupColorsFromScriptableObject();
        private void OnDestroy()
        {
            if (_customizationSO != null)
                _customizationSO.RemoveObserver(this);
        }

        private void SetupColors(AvatarStruct<SerializableColor> colorReference)
        {
            SetMaterialColor(_renderer.GetProperty(AvatarPropertiesEnum.CABELO), colorReference.GetProperty(AvatarPropertiesEnum.CABELO));
            SetMaterialColor(_renderer.GetProperty(AvatarPropertiesEnum.CORPO), colorReference.GetProperty(AvatarPropertiesEnum.CORPO));

            SetMaterialColor(_renderer.GetProperty(AvatarPropertiesEnum.IRIS), colorReference.GetProperty(AvatarPropertiesEnum.IRIS));
            SetMaterialColor(_renderer.GetProperty(AvatarPropertiesEnum.PUPILA), colorReference.GetProperty(AvatarPropertiesEnum.PUPILA));
            SetMaterialColor(_renderer.GetProperty(AvatarPropertiesEnum.OLHOS), colorReference.GetProperty(AvatarPropertiesEnum.OLHOS));

            SetMaterialColor(_renderer.GetProperty(AvatarPropertiesEnum.DENTES), colorReference.GetProperty(AvatarPropertiesEnum.DENTES));
            SetMaterialColor(_renderer.GetProperty(AvatarPropertiesEnum.LINGUA), colorReference.GetProperty(AvatarPropertiesEnum.LINGUA));

            SetMaterialColor(_renderer.GetProperty(AvatarPropertiesEnum.CAMISA), colorReference.GetProperty(AvatarPropertiesEnum.CAMISA));
            SetMaterialColor(_renderer.GetProperty(AvatarPropertiesEnum.CALCA), colorReference.GetProperty(AvatarPropertiesEnum.CALCA));
            SetMaterialColor(_renderer.GetProperty(AvatarPropertiesEnum.ACESSORIOS), colorReference.GetProperty(AvatarPropertiesEnum.ACESSORIOS));
        }

        private void SetMaterialColor(SkinnedMeshRenderer renderer, Color color)
        {
            if (renderer != null && color != null)
                renderer.material.color = color;
        }

        public string GetAvatarName() => _avatarName;
    }
}