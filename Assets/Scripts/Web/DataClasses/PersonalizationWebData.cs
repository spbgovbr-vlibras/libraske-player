using UnityEngine;

[System.Serializable]
public struct PersonalizationColor
{
    private int id;
    private string code;
    private bool isDefault;
    private int personalization_group_id;
    private Color color;

    public int Id => id;
    public bool IsDefault => isDefault;
    public int PersonalizationId => personalization_group_id;
    public Color Color { get => color; }

    public PersonalizationColor(int id, string code, bool isDefault, int personalization_group_id)
    {
        this.id = id;
        this.code = code;
        this.isDefault = isDefault;
        this.personalization_group_id = personalization_group_id;

        ColorUtility.TryParseHtmlString(code, out color);
    }
}

[System.Serializable]
public struct PersonalizationGroup
{
    private int id;
    private string name;
    private int personalization_id;
    private int price;

    public int Id => id;
    public string Name => name;
    public int PersonalizationId => personalization_id;
    public int Price => price;

    public PersonalizationGroup(int id, string name, int personalization_id, int price)
    {
        this.id = id;
        this.name = name;
        this.personalization_id = personalization_id;
        this.price = price;
    }
}