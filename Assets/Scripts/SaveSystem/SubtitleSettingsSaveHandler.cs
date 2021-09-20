using UnityEngine;
using Lavid.Libraske.SaveSystem;
using Lavid.Libraske.Util;

public static class SubtitleSettingsSaveHandler
{
    #region Fields
    public enum Size { Small, Regular, Big }
    public enum Color { White, Yellow }
    #endregion

    #region Gets
    public static bool HasSavedSettings() => PlayerPrefs.GetInt(SaveFields.HasSavedAudioSettings) == Boolean.TrueInt;
    public static bool CanShowSubtitles() => PlayerPrefs.GetInt(SaveFields.ShowSubtitles) != 0;
    public static Size GetSize() => (Size)PlayerPrefs.GetInt(SaveFields.SubtitlesSize);
    public static Color GetColor() => (Color)PlayerPrefs.GetInt(SaveFields.SubtitlesColor);
    #endregion

    #region Sets
    public static void AllowSaving(bool value = true) => PlayerPrefs.SetInt(SaveFields.HasSavedSubtitleSettings, new Boolean(value).ToInt());
    public static void EnableSubtitles(Boolean value) => PlayerPrefs.SetInt(SaveFields.ShowSubtitles, value.ToInt());
    public static void SetSize(Size size) => PlayerPrefs.SetInt(SaveFields.SubtitlesSize, (int)size);
    public static void SetColor(Color color) => PlayerPrefs.SetInt(SaveFields.SubtitlesColor, (int)color);
    public static void ResetSettings() => SetSettings(Boolean.True, Size.Regular, Color.White);
    public static void SetSettings(Boolean showSubtitles, Size size, Color color)
    {
        EnableSubtitles(showSubtitles);
        SetSize(size);
        SetColor(color);
        PlayerPrefs.SetInt(SaveFields.HasSavedAudioSettings, Boolean.TrueInt);
    }
    #endregion
}
