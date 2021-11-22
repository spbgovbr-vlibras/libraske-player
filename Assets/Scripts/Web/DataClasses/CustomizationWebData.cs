using UnityEngine;

[System.Serializable]
public struct CustomizationColor
{
    public string id;
    public string code;
    public string isDefault;
    public string personalization_group_id;
    public string isUnlocked;

    public bool IsUnlocked => bool.Parse(isUnlocked);
    public bool IsDefault => bool.Parse(isDefault);

    public int PersonalizationId => int.Parse(personalization_group_id);
    public int Id => int.Parse(id);

    public override string ToString()
    {
        string value = "";

        value += $"id: {id} code: {code} isDefault: {isDefault} personalization_group_id: {personalization_group_id} \n";

        return value;
    }

    public Color GetColor()
    {
        ColorUtility.TryParseHtmlString(code, out Color color);
        return color;
    }
}

[System.Serializable]
public struct CustomizationGroup
{
    public int id;
    public string name;
    public int personalization_id;
    public int price;
}

public static class CustomizationGroups
{
    public enum Groups 
    { 
        Skin = 1, 
        Eyes = 2,
        Hair = 3,
        Shirt = 4,
        Pant = 5
    }

    public static string ToUrlSection(Groups group) => ((int)group).ToString();
}