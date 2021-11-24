using Lavid.Libraske.Avatar;
using UnityEngine;

public class ColorPalett : MonoBehaviour, IAvatarCustomizationObserver
{
    [SerializeField] ColorSet[] _colorSets;
    [SerializeField] CustomizationHolderSO _customizationHolder;
    [SerializeField] AvatarPropertiesEnum _propertieToHandle;
    [SerializeField] AvatarCustomizationSO _customizationToObserver;

    public ColorSet[] GetColorSets() => _colorSets;

    private void Awake()
    {
        if(_customizationToObserver != null)
        {
            _customizationToObserver.AddObserver(this);
            OnCustomizationUpdate();
        }
    }

    private void OnDestroy()
    {
        if (_customizationToObserver != null)
            _customizationToObserver.RemoveObserver(this);
    }

    public void OnCustomizationUpdate()
    {
        Color newColor = _customizationToObserver.GetColors().GetProperty(_propertieToHandle);

        for (int i = 0; i < _colorSets.Length; i++)
        {
            if(_colorSets[i] != null)
            {
                _colorSets[i].UpdateColorSelected(newColor);
            }
        }
    }

    public void UpdateColors()
    {
        for(int i = 0; i < _colorSets.Length; i++)
        {
            int personalizationID = _colorSets[i].Id;
            var colors = _customizationHolder.GetColorsWithPersonalizationId(personalizationID);
            _colorSets[i].SetupChildColors(colors);
        }
    }
}