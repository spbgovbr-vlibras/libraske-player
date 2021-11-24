using Lavid.Libraske.DataStruct;
using UnityEngine;

[CreateAssetMenu(fileName = "New Personalization Holder", menuName = "Libraske/Customization/Customization Holder")]
public class CustomizationHolderSO : ScriptableObject
{
    [SerializeField] Wrapper<CustomizationGroup> _groups;

    [SerializeField] Wrapper<CustomizationColor> _skinColors;
    [SerializeField] Wrapper<CustomizationColor> _eyesColors;
    [SerializeField] Wrapper<CustomizationColor> _hairColors;
    [SerializeField] Wrapper<CustomizationColor> _shirtColors;
    [SerializeField] Wrapper<CustomizationColor> _pantColors;

    private void OnEnable() => hideFlags = HideFlags.DontUnloadUnusedAsset;

    #region Colors
    public Wrapper<CustomizationColor> GetColorsWithPersonalizationId(int id)
    {
        Wrapper<CustomizationColor> colors = null;

        if (IsInside(_skinColors, id))
            colors = FilterInside(_skinColors, id);
        else if (IsInside(_eyesColors, id))
            colors = FilterInside(_eyesColors, id);
        else if (IsInside(_hairColors, id))
            colors = FilterInside(_hairColors, id);
        else if (IsInside(_shirtColors, id))
            colors = FilterInside(_shirtColors, id);
        else if (IsInside(_pantColors, id))
            colors = FilterInside(_pantColors, id);

        return colors;
    }
    private bool IsInside(Wrapper<CustomizationColor> wrapper, int id)
    {
        if (wrapper.Length <= 0)
            return false;

         return id >= wrapper[0].PersonalizationId && id  <= wrapper[wrapper.Length -1].PersonalizationId; 
    }
    private Wrapper<CustomizationColor> FilterInside(Wrapper<CustomizationColor> wrapper, int id)
    {
        Wrapper<CustomizationColor> colors = new Wrapper<CustomizationColor>();

        for(int i = 0; i < wrapper.Length; i++)
        {
            if (wrapper[i].PersonalizationId == id)
                colors.Add(wrapper[i]);
        }

        return colors;
    }
    public void SetColors(Wrapper<CustomizationColor> colors, CustomizationGroups.Groups group)
    {
        switch (group)
        {
            case CustomizationGroups.Groups.Hair:
                _hairColors = colors;
                break;
            case CustomizationGroups.Groups.Pant:
                _pantColors = colors;
                break;
            case CustomizationGroups.Groups.Shirt:
                _shirtColors = colors;
                break;
            case CustomizationGroups.Groups.Eyes:
                _eyesColors = colors;
                break;
            case CustomizationGroups.Groups.Skin:
                _skinColors = colors;
                break;
        }
    }
    #endregion

    public void SetGroups(Wrapper<CustomizationGroup> groups) => _groups = groups;
    public Wrapper<CustomizationGroup> GetGroups() => _groups;
}