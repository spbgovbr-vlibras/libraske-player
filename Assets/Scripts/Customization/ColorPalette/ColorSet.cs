using Lavid.Libraske.Avatar;
using Lavid.Libraske.DataStruct;
using Lavid.Libraske.UnlockSystem;
using UnityEngine;

/// <summary> A color arrangement to manage the colors handlers. </summary>
public class ColorSet : MonoBehaviour, IUnlockable
{
    [SerializeField] private GameObject _unlockButton;
    [SerializeField] private Wrapper<CustomizationColorHandler> _colorHandlers;

    #region UnlockSystem
    [SerializeField] private int _price;
    [SerializeField] private bool _isUnlocked;
    [SerializeField] private UnlockController _controller;

    public bool IsUnlocked => _isUnlocked;
    public int Price => _price;
    public UnlockController Controller => _controller;
    #endregion

    public void TryUnlock()
    {
        if (_controller != null)
            _controller.EnterUnlockRequest(this);
    }

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