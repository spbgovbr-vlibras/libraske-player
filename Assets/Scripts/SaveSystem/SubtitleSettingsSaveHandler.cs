using UnityEngine;
using Lavid.Libraske.SaveSystem;
using Lavid.Libraske.Util;

public static class SubtitleSettingsSaveHandler
{
    static SubtitleSettingsSaveHandler()
    {
        if (!HasSavedSettings())
            ResetSettings();
    }

    #region Fields
    public enum Size { Small, Regular, Big }
    public enum Color { White, Yellow }
    #endregion

    #region Gets
    private static bool HasSavedSettings() => PlayerPrefs.GetInt(SaveFields.HasSavedAudioSettings) == Boolean.TrueInt;
    public static bool CanShowSubtitles() => PlayerPrefs.GetInt(SaveFields.ShowSubtitles) != 0;
    public static Size GetSize() => (Size)PlayerPrefs.GetInt(SaveFields.SubtitlesSize);
    public static Color GetColor() => (Color)PlayerPrefs.GetInt(SaveFields.SubtitlesColor);
    #endregion

    #region Sets
    public static void EnableSaving(bool value) => PlayerPrefs.SetInt(SaveFields.HasSavedSubtitleSettings, new Boolean(value).ToInt());
    public static void EnableSubtitles(Boolean value) => PlayerPrefs.SetInt(SaveFields.ShowSubtitles, value.ToInt());
    public static void SetSize(Size size) => PlayerPrefs.SetInt(SaveFields.SubtitlesSize, (int)size);
    public static void SetColor(Color color) => PlayerPrefs.SetInt(SaveFields.SubtitlesColor, (int)color);
    #endregion

    public static void ResetSettings()
    {
        EnableSaving(false);
        EnableSubtitles(Boolean.True);
        SetSize(Size.Regular);
        SetColor(Color.White);
        PlayerPrefs.Save();
    }

    public static void SaveData()
    {
        EnableSaving(true);
        PlayerPrefs.Save();
    }
}