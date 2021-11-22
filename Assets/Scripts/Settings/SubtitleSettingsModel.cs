using Lavid.Libraske.DataStruct;
using Lavid.Libraske.Util;
using UnityEngine;
using UnityEngine.UI;

/// <summary> Synchronize values with UI  </summary>
public class SubtitleSettingsModel : MonoBehaviour 
{
    [SerializeField] Toggle _showSubtitlesToggle;
    [SerializeField] ToggleGroup _sizeToogleGroup;
    [SerializeField] ToggleGroup _colorToogleGroup;

    Wrapper<Toggle> _sizeToogles;
    Wrapper<Toggle> _colorToogles;

    public Boolean ShowSubtitlesPreview() => new Boolean(_showSubtitlesToggle.isOn);
    public SubtitleSettingsSaveHandler.Size GetPreviewSize() => (SubtitleSettingsSaveHandler.Size)GetSelectedOption(_sizeToogles);
    public SubtitleSettingsSaveHandler.Color GetPreviewColor() => (SubtitleSettingsSaveHandler.Color)GetSelectedOption(_colorToogles);

    void Awake()
    {
        _sizeToogles = new Wrapper<Toggle>(_sizeToogleGroup.GetComponentsInChildren<Toggle>(true));
        _colorToogles = new Wrapper<Toggle>(_colorToogleGroup.GetComponentsInChildren<Toggle>(true));
    }

    public void SelectValues
    (
        bool showSubtitles,
        int sizeIndex,
        int colorIndex
    )
    {
        _showSubtitlesToggle.isOn = showSubtitles;
        SelectOption(colorIndex, _colorToogles);
        SelectOption(sizeIndex, _sizeToogles);
    }

    private void SelectOption(int indexToSelect, Wrapper<Toggle> toogles)
    {
        for (int i = 0; i < toogles.Length; i++)
        {
            toogles[i].isOn = indexToSelect == i;
        }
    }

    public int GetSelectedOption(Wrapper<Toggle> toogles)
    {
        for (int i = 0; i < toogles.Length; i++)
        {
            if (toogles[i].isOn)
                return i;
        }
        return -1;
    }
}