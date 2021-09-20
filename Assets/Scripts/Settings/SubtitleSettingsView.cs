using Lavid.Libraske.Util;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleSettingsView : MonoBehaviour
{
    public Toggle showSubtitlesToggle;
    public ToggleGroup sizeOptions;
    public ToggleGroup colorOptions;

    public GameObject subtitlesPanel;
    public Image subtitleBarPreview;
    public Text subtitleTextPreview;

    public event System.Action OnUIUpdate; 

    private enum SubtitleFontSize
    {
        Low = 14,
        Middle = 20,
        High = 26
    }

    private static Vector2 LowSubtitleRect = new Vector2(391, 26.11f);
    private static Vector2 MiddleSubtitleRect = new Vector2(569, 38);
    private static Vector2 HighSubtitleRect = new Vector2(718.74f, 48);

    public Boolean ShowSubtitles() => new Boolean(showSubtitlesToggle.isOn);
    public SubtitleSettingsSaveHandler.Size GetSize() => (SubtitleSettingsSaveHandler.Size)GetSelectedOption(sizeOptions);
    public SubtitleSettingsSaveHandler.Color GetColor() => (SubtitleSettingsSaveHandler.Color)GetSelectedOption(colorOptions);

    void Start()
    {
        if (!SubtitleSettingsSaveHandler.HasSavedSettings())
            SubtitleSettingsSaveHandler.ResetSettings();

        UpdateValues();
        SubtitleSettingsSaveHandler.AllowSaving();
    }

    private void UpdateValues()
    {
        showSubtitlesToggle.isOn = SubtitleSettingsSaveHandler.CanShowSubtitles();
        subtitlesPanel.SetActive(SubtitleSettingsSaveHandler.CanShowSubtitles());
        SelectOption(sizeOptions, (int)SubtitleSettingsSaveHandler.GetSize());
        SelectOption(colorOptions, (int)SubtitleSettingsSaveHandler.GetColor());
        SetSubtitlePreview((int)SubtitleSettingsSaveHandler.GetSize(), (int)SubtitleSettingsSaveHandler.GetColor());

        UpdateRender();
    }

    public void SaveSubtitleSettings() => OnUIUpdate?.Invoke();

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
                subtitleBarPreview.rectTransform.sizeDelta = LowSubtitleRect;
                subtitleTextPreview.fontSize = (int)SubtitleFontSize.Low;
                break;
            case 1:
                subtitleBarPreview.rectTransform.sizeDelta = MiddleSubtitleRect;
                subtitleTextPreview.fontSize = (int)SubtitleFontSize.Middle;
                break;
            case 2:
                subtitleBarPreview.rectTransform.sizeDelta = HighSubtitleRect;
                subtitleTextPreview.fontSize = (int)SubtitleFontSize.High;
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
}
