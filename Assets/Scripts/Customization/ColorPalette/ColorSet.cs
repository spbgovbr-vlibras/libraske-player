using Lavid.Libraske.Avatar;
using Lavid.Libraske.DataStruct;
using UnityEngine;

/// <summary> A color arrangement to manage the colors handlers. </summary>
public class ColorSet : MonoBehaviour, IUnlockable
{
    [SerializeField] private GameObject _unlockButton;
    [SerializeField] private Wrapper<CustomizationColorHandler> _colorHandlers;

    [SerializeField] private int _price;
    [SerializeField] private bool _isUnlocked;

    public bool IsUnlocked => _isUnlocked;
    public int Price => _price;

    public void Lock()
    {
        _isUnlocked = false;
        RefreshStatus();
    }

    public void RefreshStatus()
    {
        _unlockButton.SetActive(!_isUnlocked);

        for (int i = 0; i < _colorHandlers.Length; i++)
            _colorHandlers[i].LockColor(!_isUnlocked);
    }

    public void Unlock()
    {
        _isUnlocked = true;
        RefreshStatus();
    }

    private void OnEnable() => RefreshStatus();
}