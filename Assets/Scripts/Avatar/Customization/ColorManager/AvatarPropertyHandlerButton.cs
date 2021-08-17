using UnityEngine;

namespace Lavid.Libraske.Avatar
{
    /// <summary> Customiza itens do avatar.  </summary>
    public class AvatarPropertyHandlerButton : TouchSelection
    {
        [SerializeField] AvatarPropertiesEnum _avatarProperty;
        public AvatarPropertiesEnum GetAvatarProperty() => _avatarProperty;
    }
}