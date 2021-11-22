using Lavid.Libraske.Avatar;
using UnityEngine;

public class LocalCustomizationManager : MonoBehaviour
{
    [SerializeField] AvatarCustomizationManager _manager;

    public void UpdateVisuals(CustomizationColorHandler item)
    {
        _manager.SetColor(item.GetColor());
        _manager.ApplyColorToProperty();
    }
    public void SaveData() => _manager.SaveCustomizatedColors();
}
