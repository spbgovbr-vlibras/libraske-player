using Lavid.Libraske.Avatar;
using Lavid.Libraske.DataStruct;
using Lavid.Libraske.UnlockSystem;
using UnityEngine;

/// <summary> A color arrangement to manage the colors handlers. </summary>
public class ColorSet : MonoBehaviour, IUnlockable
{
    [SerializeField] private GameObject _unlockButton;
    [SerializeField] private Wrapper<CustomizationColorHandler> _colorHandlers;

    private int _personalizationID;
    public int Id { get => _personalizationID; set => _personalizationID = value; }

    #region UnlockSystem
    [SerializeField] private int _price;
    [SerializeField] private bool _isUnlocked;
    [SerializeField] private UnlockController _controller;

    public bool IsUnlocked => _isUnlocked;
    public int Price => _price;
    public UnlockController Controller => _controller;


    #endregion

    public void SetupColorSet(int personalizationID, int price)
    {
        _personalizationID = personalizationID;
        _price = price;
    }

    public void SetupChildColors(Wrapper<CustomizationColor> colors)
    {
        if (colors.Length <= 0)
        {
            Debug.LogWarning("Color Wrapper is empty");
            return;
        }

        bool enableLockContainer = false;

        for (int i = 0; i < _colorHandlers.Length; i++)
        {
            bool isLocked = !colors[i].IsUnlocked;
            _colorHandlers[i].SetColor(colors[i]);
            _colorHandlers[i].LockColor(isLocked);
            enableLockContainer |= isLocked;
        }

        _unlockButton.SetActive(enableLockContainer);
    }

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
}