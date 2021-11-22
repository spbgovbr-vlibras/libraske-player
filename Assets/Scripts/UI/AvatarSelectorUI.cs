using Lavid.Libraske.Avatar;
using UnityEngine;
using Lavid.Libraske.UI;

[System.Serializable]
internal struct DotFromAvatar 
{
    public DotUI dotUI;
    public AvatarNameEnum name;
}

public class AvatarSelectorUI : MonoBehaviour
{
    [SerializeField] TextUI _nameUI;
    [SerializeField] DotFromAvatar[] _dotsInUI;

    public void UpdateUI(AvatarNameEnum avatarName)
    {
        _nameUI.SetText(avatarName.ToString());

        // Update UI dots and selection
        for(int i = 0; i < _dotsInUI.Length; i++)
        {
            bool isTheSame = avatarName == _dotsInUI[i].name;
            _dotsInUI[i].dotUI.UpdateSelectionBoolean(isTheSame);
        }
    }
}