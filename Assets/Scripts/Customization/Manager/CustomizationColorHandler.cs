using Lavid.Libraske.Avatar;
using UnityEngine;
using UnityEngine.UI;


public class CustomizationColorHandler : MonoBehaviour
{
    [Header("Color Manager")]
    [SerializeField] private AvatarCustomizationManager _avatarColorManager;
    [SerializeField] private Image _colorImage;

    [Header("Lock Container"), Space(2)]
    [SerializeField] private GameObject _lockContainer;

    public void SetColor(Color color) => _colorImage.color = color;

    public void LockColor(bool lockColor)
    {
        _colorImage.raycastTarget = !lockColor;
        _lockContainer.SetActive(lockColor);
    }

    public void ApplyColorToManager()
    {
        if (_avatarColorManager == null)
            return;

        _avatarColorManager.SetColor(_colorImage.color);
        _avatarColorManager.ApplyColorToProperty();
    }
}
