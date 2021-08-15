using UnityEngine;

public class SubtitleHUD : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string ShowSubtitles = "ShowSubtitles";
    private static readonly string SubtitlesSizePref = "SubtitleSize";
    private static readonly string SubtitlesColorPref = "SubtitlesColor";
    private int firstPlayInt;

    public GameObject subtitlesPanel;

    private bool showSubtitlesBoolean;
    private int selectedSubtitlesSize;
    private int selectedSubtitlesColor;

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            ResetSubtitlesSettings();
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            showSubtitlesBoolean = (PlayerPrefs.GetInt(ShowSubtitles) != 0);
            selectedSubtitlesSize = PlayerPrefs.GetInt(SubtitlesSizePref);
            selectedSubtitlesColor = PlayerPrefs.GetInt(SubtitlesColorPref);
        }
    }

    public void ResetSubtitlesSettings()
    {
        showSubtitlesBoolean = true;
        selectedSubtitlesSize = 0;
        selectedSubtitlesColor = 0;

        //SubtitleSettingsManager.ResetSubtitlesSettings(showSubtitlesBoolean, subtitleSize, subtitleColor);

        PlayerPrefs.SetInt(ShowSubtitles, (showSubtitlesBoolean ? 1 : 0));
        PlayerPrefs.SetInt(SubtitlesSizePref, selectedSubtitlesSize);
        PlayerPrefs.SetInt(SubtitlesColorPref, selectedSubtitlesColor);
    }
}
