using UnityEngine;

public class ColorPalettsController : MonoBehaviour 
{
    [SerializeField] ColorPalett[] _paletts;
    [SerializeField] CustomizationHolderSO _customizationHolder;

    private void OnEnable() => Setup();
    public void Setup()
    {
        SetupPaletts();
        UpdatePalettsColors();
    }

    private void UpdatePalettsColors()
    {
        for (int i = 0; i < _paletts.Length; i++)
        {
            _paletts[i].UpdateColors();
        }
    }

    private void SetupPaletts()
    {
        var groups = _customizationHolder.GetGroups();
        int id = groups[0].personalization_id; // InitialID

        for(int i = 0; i < _paletts.Length; i++)
        {
            foreach(var colorset in _paletts[i].GetColorSets())
            {
                colorset.SetupColorSet(id, groups[id-1].price);
                id++;
            }
        }
    }
}