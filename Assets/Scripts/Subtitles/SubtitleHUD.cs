using Lavid.Libraske.DataStruct;
using Lavid.Libraske.UI;
using UnityEngine;

public class SubtitleHUD : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private TextUI _text;
    [SerializeField] private Wrapper<SubtitleColor> _colors;
    [SerializeField] private Wrapper<SubtitleSize> _sizes;

    private void OnEnable() => UpdateValues();
    public void UpdateValues()
    {
        _container.SetActive(SubtitleSettings.CanShowSubtitles());

        UpdateSize();
        UpdateColor();
    }
    private void UpdateSize()
    {
        var size = SubtitleSettings.GetSize();

        for (int i = 0; i < _sizes.Length; i++)
        {
            if (size == _sizes[i].sizeEnum)
            {
                _container.transform.localScale = new Vector2(_sizes[i].size, _sizes[i].size);
                return;
            }
        }
    }
    private void UpdateColor()
    {
        var color = SubtitleSettings.GetColor();

        for (int i = 0; i < _colors.Length; i++)
        {
            if (color == _colors[i].colorEnum)
            {
                _text.SetColor(_colors[i].color);
                return;
            }
        }
    }
}

[System.Serializable]
internal struct SubtitleColor
{
    public SubtitleSettings.Color colorEnum;
    public Color color;
}

[System.Serializable]
internal struct SubtitleSize
{
    public SubtitleSettings.Size sizeEnum;
    public float size;
}