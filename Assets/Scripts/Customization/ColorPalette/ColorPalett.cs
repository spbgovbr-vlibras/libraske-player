using UnityEngine;

public class ColorPalett : MonoBehaviour
{
    [SerializeField] ColorSet[] _colorSets;
    [SerializeField] CustomizationHolderSO _customizationHolder;

    public ColorSet[] GetColorSets() => _colorSets;

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