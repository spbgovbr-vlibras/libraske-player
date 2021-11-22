using Lavid.Libraske.Avatar;
using UnityEngine;
using UnityEngine.UI;


public class CustomizationColorHandler : MonoBehaviour
{
    [SerializeField] private Image _colorImage;

    private int _id;
    public int Id => _id;

    [Header("Lock Container"), Space(2)]
    [SerializeField] private GameObject _lockContainer;

    public Color GetColor() => _colorImage.color;

    public void SetColor(CustomizationColor color)
    {
        _id = color.Id;
        _colorImage.color = color.GetColor();
    }

    public void LockColor(bool lockColor)
    {
        _colorImage.raycastTarget = !lockColor;
        _lockContainer.SetActive(lockColor);
    }
}
