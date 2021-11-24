using Lavid.Libraske.Avatar;
using UnityEngine;
using UnityEngine.UI;


public class CustomizationColorHandler : MonoBehaviour
{
    [SerializeField] private Image _colorImage;

    private int _id;
    public int Id => _id;



    [Header("Lock Settings"), Space(2)]
    [SerializeField, Range(0, 1)] private float _regularOpacity;
    [SerializeField, Range(0, 1)] private float _lockOpacity;
    [SerializeField, Range(0, 1)] private float _hoverAndUnlockedOpacity;
    [SerializeField, Range(0, 1)] private float _hoverAndLockedOpacity;
    [SerializeField] private CanvasGroup _canvasGroup;
    private bool _isColorLocked;

    public Color GetColor() => _colorImage.color;

    private void SetAlpha(float alpha) => _canvasGroup.alpha = alpha;

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
    }

    public void LockColor(bool lockColor)
    {
        _isColorLocked = lockColor;
        _colorImage.raycastTarget = !lockColor;
        SetAlpha(lockColor ? _lockOpacity : _regularOpacity);
    }
}
