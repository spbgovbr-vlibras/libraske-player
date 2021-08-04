using Lavid.Libraske.Util;
using UnityEngine;

namespace Lavid.Libraske.Avatar
{
    /// <summary> Connect colors to Avatar's renderer materials </summary>
    public class Avatar : MonoBehaviour
    {
        [SerializeField] private AvatarStruct<SkinnedMeshRenderer> _renderer;
        [SerializeField, Tooltip("Avatar Customization Scriptable Object")] private AvatarCustomizationSO _customizationSO;

        private void OnEnable()
        {
            if (_customizationSO != null)
                SetupColors(_customizationSO.GetColors());
        }

        private void SetupColors(AvatarStruct<SerializableColor> colorReference)
        {
            SetMaterialColor(_renderer.cabelo, colorReference.cabelo);
            SetMaterialColor(_renderer.corpo, colorReference.corpo);

            SetMaterialColor(_renderer.iris, colorReference.iris);
            SetMaterialColor(_renderer.pupila, colorReference.pupila);
            SetMaterialColor(_renderer.olhos, colorReference.olhos);

            SetMaterialColor(_renderer.dentes, colorReference.dentes);
            SetMaterialColor(_renderer.lingua, colorReference.lingua);

            SetMaterialColor(_renderer.camisa, colorReference.camisa);
            SetMaterialColor(_renderer.calca, colorReference.calca);
            SetMaterialColor(_renderer.acessorios, colorReference.acessorios);
        }

        private void SetMaterialColor(SkinnedMeshRenderer renderer, Color color)
        {
            if (renderer != null && color != null)
                renderer.material.color = color;
        }
    }
}