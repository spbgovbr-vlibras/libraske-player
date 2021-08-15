using UnityEngine;

public static class SubtitleSettings
{
    #region Constants
    public enum Boolean { False, True }
    public enum Size { Small, Regular, Big }
    public enum Color { White, Yellow }


    public const string s_HasSavedSettings = "HasSavedSettings";
    public const string s_ShowSubtitles = "ShowSubtitles";
    public const string s_SubtitlesSize = "SubtitleSize";
    public const string s_SubtitlesColor = "SubtitlesColor";
    #endregion

    #region Gets
    public static bool HasSavedSettings() => PlayerPrefs.GetInt(s_HasSavedSettings) == (int)Boolean.True;
    public static bool CanShowSubtitles() => PlayerPrefs.GetInt(s_ShowSubtitles) != 0;
    public static Size GetSize() => (Size)PlayerPrefs.GetInt(s_SubtitlesSize);
    public static Color GetColor() => (Color)PlayerPrefs.GetInt(s_SubtitlesColor);
    #endregion

    #region Sets
    public static void EnableSubtitles(Boolean value) => PlayerPrefs.SetInt(s_ShowSubtitles, (int)value);
    public static void SetSize(Size size) => PlayerPrefs.SetInt(s_SubtitlesSize, (int)size);
    public static void SetColor(Color color) => PlayerPrefs.SetInt(s_SubtitlesColor, (int)color);
    public static void ResetSettings() => SetSettings(Boolean.True, Size.Regular, Color.White);
    public static void SetSettings(Boolean showSubtitles, Size size, Color color)
    {
        EnableSubtitles(showSubtitles);
        SetSize(size);
        SetColor(color);
        PlayerPrefs.SetInt(s_HasSavedSettings, (int)Boolean.True);
    }
    #endregion
}