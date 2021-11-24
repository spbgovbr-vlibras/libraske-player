using Lavid.Libraske.Avatar;
using Lavid.Libraske.DataStruct;
using Lavid.Libraske.UnlockSystem;
using Lavid.Libraske.Touch;
using UnityEngine;

/// <summary> A color arrangement to manage the colors handlers. </summary>
public class ColorSet : MonoBehaviour, IUnlockable
{
	[Header("Unlock System")]
    [SerializeField] private GameObject _unlockButton;
    [SerializeField] private UnlockController _controller;

	[Header("Colors Data")]
	[SerializeField] private Wrapper<CustomizationColorHandler> _colorHandlers;
    [SerializeField] private int _price;
    [SerializeField] private bool _isUnlocked;
	private int _personalizationID;

	public int Id { get => _personalizationID; set => _personalizationID = value; }
    public bool IsUnlocked => _isUnlocked;
    public int Price => _price;
    public UnlockController Controller => _controller;

    // Called on canvas
    public void OnUnlockButtonHoverEnter()
    {
        for (int i = 0; i < _colorHandlers.Length; i++)
        {
            if(_colorHandlers[i] != null)
                _colorHandlers[i].OnHoverEnter();
        }
    }

    // Called on canvas
    public void OnUnlockButtonHoverExit()
    {
        for (int i = 0; i < _colorHandlers.Length; i++)
        {
            if(_colorHandlers[i] != null)
                _colorHandlers[i].OnHoverExit();
        }
    }

    public void OnUpdateSelection(Color newColor)
    {
        for (int i = 0; i < _colorHandlers.Length; i++)
        {
            if (_colorHandlers[i] != null)
                _colorHandlers[i].UpdateColorSelected(newColor);
        }
    }

    public void UpdateColorSelected(Color newColor)
    {
        for (int i = 0; i < _colorHandlers.Length; i++)
        {
            _colorHandlers[i].UpdateColorSelected(newColor);
        }
    }

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