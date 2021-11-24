using Lavid.Libraske.Avatar;
using UnityEngine;
using UnityEngine.UI;


public class CustomizationColorHandler : MonoBehaviour
{
    [SerializeField] private Image _colorImage;

    [Header("Selection")]
    [SerializeField] private GameObject _enableCaseSelected;
    private int _id;
    public int Id => _id;


    [Header("Lock Settings"), Space(2)]
    [SerializeField, Range(0, 1)] private float _regularOpacity;
    [SerializeField, Range(0, 1)] private float _lockOpacity;
    [SerializeField, Range(0, 1)] private float _hoverAndUnlockedOpacity;
    [SerializeField, Range(0, 1)] private float _hoverAndLockedOpacity;
    [SerializeField] private CanvasGroup _canvasGroup;
    private bool _isColorLocked;
    private bool _isADefaultColor;

    // Default colors should not be locked
    private bool ShouldLock(bool wantToLock) => wantToLock && !_isADefaultColor;

    public Color GetColor() => _colorImage.color;

    private void SetAlpha(float alpha) => _canvasGroup.alpha = alpha;

    public void UpdateColorSelected(Color color)
    {
        bool isSelected = color == _colorImage.color;
        _enableCaseSelected.SetActive(isSelected);
    }

    public void OnHoverEnter()
    {
        SetAlpha(_isColorLocked ? _hoverAndLockedOpacity : _hoverAndUnlockedOpacity);
    }

    public void OnHoverExit()
    {
        SetAlpha(_isColorLocked ? _lockOpacity : _regularOpacity);
    }

    public void SetColor(CustomizationColor color)
    {
        _id = color.Id;
        _colorImage.color = color.GetColor();
        _isADefaultColor = color.IsDefault;
    }

    public void LockColor(bool lockColor)
    {
        _isColorLocked = ShouldLock(lockColor);
        _colorImage.raycastTarget = !_isColorLocked;
        SetAlpha(_isColorLocked ? _lockOpacity : _regularOpacity);
    }
}
