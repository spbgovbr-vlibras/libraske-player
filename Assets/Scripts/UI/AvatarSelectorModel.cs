using Lavid.Libraske.Avatar;
using UnityEngine;

public class AvatarSelectorModel : MonoBehaviour
{
    [SerializeField] AvatarSelectorUI _ui;
    [SerializeField] AvatarSelector _avatarSelector;
    int _currentSelection;

    private void Start()
    {
        _currentSelection = _avatarSelector.GetCurrentTempAvatarIndex();
        ChooseAvatarAt(_currentSelection);
        UpdateUI(_avatarSelector.GetCurrentTempAvatar());
    }

    private void UpdateUI(AvatarNameEnum avatarName) => _ui.UpdateUI(avatarName);

    public void ChoosePrevious()
    {
        _currentSelection--;

        if (_currentSelection < 0)
            _currentSelection = _avatarSelector.QuantityOfAvatars - 1;

        ChooseAvatarAt(_currentSelection);
    }
    public void ChooseNext()
    {
        _currentSelection++;
        _currentSelection %= _avatarSelector.QuantityOfAvatars;

        ChooseAvatarAt(_currentSelection);
    }
    public void ChooseAvatarAt(int index)
    {
        _avatarSelector.ChooseAt(index);
        UpdateUI(_avatarSelector.GetCurrentTempAvatar());
    }

    // Called on canvas
    public void SaveSelectionChoice() => _avatarSelector.SaveSelectionChoice();
}
