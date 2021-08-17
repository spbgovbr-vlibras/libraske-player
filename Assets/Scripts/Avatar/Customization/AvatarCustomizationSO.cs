using Lavid.Libraske.Avatar;
using Lavid.Libraske.Util;
using UnityEngine;

[CreateAssetMenu(fileName = "Avatar Customization", menuName = "Libraske/Avatar/Customization")]
public class AvatarCustomizationSO : AvatarCustomizationSubject
{
    [SerializeField] private AvatarStruct<SerializableColor> _colors;

    public AvatarStruct<SerializableColor> GetColors() => _colors;
    public void SetColors(AvatarStruct<SerializableColor> colors)
    {
        _colors = colors;
        NotifyUpdateToObservers();
    }

    public void ChangePropertyColor(AvatarPropertiesEnum property, SerializableColor color)
    {
        _colors.SetProperty(property, color);
        NotifyUpdateToObservers();
    }
}