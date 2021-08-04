using Lavid.Libraske.Avatar;
using Lavid.Libraske.Util;
using UnityEngine;

[CreateAssetMenu(fileName = "Avatar Customization", menuName = "Libraske/Avatar/Customization")]
public class AvatarCustomizationSO : ScriptableObject
{
    [SerializeField] private AvatarStruct<SerializableColor> _colors;
    public AvatarStruct<SerializableColor> GetColors() => _colors;
}