using UnityEngine;
using UnityEngine.UI;

public class SubtitleSettingsManager : MonoBehaviour
{
    public Toggle showSubtitlesToggle;
    public ToggleGroup sizeOptions;
    public ToggleGroup colorOptions;

    public GameObject subtitlesPanel;
    public Image subtitleBarPreview;
    public Text subtitleTextPreview;

    private bool showSubtitlesBoolean;
    private int selectedSubtitlesSize;
    private int selectedSubtitlesColor;

    void Start()
    {
        if (!SubtitleSettings.HasSavedSettings())
        {
            SubtitleSettings.ResetSettings();
        }
        else
        {
            showSubtitlesBoolean = SubtitleSettings.CanShowSubtitles();
            selectedSubtitlesSize = (int) SubtitleSettings.GetSize();
            selectedSubtitlesColor = (int) SubtitleSettings.GetColor();

            showSubtitlesToggle.isOn = showSubtitlesBoolean;
            subtitlesPanel.SetActive(showSubtitlesBoolean);
            SelectOption(sizeOptions, selectedSubtitlesSize);
            SelectOption(colorOptions, selectedSubtitlesColor);
            SetSubtitlePreview(selectedSubtitlesSize, selectedSubtitlesColor);
        }
    }

    public void SaveSubtitleSettings()
    {
        SubtitleSettings.EnableSubtitles((SubtitleSettings.Boolean)(showSubtitlesToggle.isOn ? 1 : 0));
        SubtitleSettings.SetSize((SubtitleSettings.Size)GetSelectedOption(sizeOptions));
        SubtitleSettings.SetColor((SubtitleSettings.Color)GetSelectedOption(colorOptions));
    }

    public void UpdateRender()
    {
        subtitlesPanel.SetActive(showSubtitlesToggle.isOn);
        SetSubtitlePreview(GetSelectedOption(sizeOptions), GetSelectedOption(colorOptions));
    }

    public void SelectOption(ToggleGroup group, int id)
    {
        var options = group.GetComponentsInChildren<Toggle>();
        options[id].isOn = true;
    }

    public int GetSelectedOption(ToggleGroup group)
    {
        var options = group.GetComponentsInChildren<Toggle>();
        for (int i = 0; i < options.Length; i++)
        {
            if (options[i].isOn)
            {
                return i;
            }
        }
        return -1;
    }

    public void SetSubtitlePreview(int sizeID, int colorID)
    {
        switch (sizeID)
        {
            case 0:
                subtitleBarPreview.rectTransform.sizeDelta = new Vector2(391, 26.11f);
                subtitleTextPreview.fontSize = 14;
                break;
            case 1:
                subtitleBarPreview.rectTransform.sizeDelta = new Vector2(569, 38);
                subtitleTextPreview.fontSize = 20;
                break;
            case 2:
                subtitleBarPreview.rectTransform.sizeDelta = new Vector2(718.74f, 48);
                subtitleTextPreview.fontSize = 26;
                break;
        }

        switch (colorID)
        {
            case 0:
                subtitleTextPreview.color = Color.white;
                break;
            case 1:
                subtitleTextPreview.color = Color.yellow;
                break;
        }
    }

    public void ResetSubtitlesSettings()
    {
        showSubtitlesBoolean = true;
        selectedSubtitlesSize = 0;
        selectedSubtitlesColor = 0;

        showSubtitlesToggle.isOn = showSubtitlesBoolean;
        subtitlesPanel.SetActive(showSubtitlesBoolean);
        SelectOption(sizeOptions, selectedSubtitlesSize);
        SelectOption(colorOptions, selectedSubtitlesColor);
        SetSubtitlePreview(selectedSubtitlesSize, selectedSubtitlesColor);

        SubtitleSettings.EnableSubtitles((SubtitleSettings.Boolean)(showSubtitlesToggle.isOn ? 1 : 0));
        SubtitleSettings.SetSize((SubtitleSettings.Size)GetSelectedOption(sizeOptions));
        SubtitleSettings.SetColor((SubtitleSettings.Color)GetSelectedOption(colorOptions));
    }
}
