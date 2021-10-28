using UnityEngine;
using Lavid.Libraske.SaveSystem;
using Lavid.Libraske.Util;

public static class AudioSettingsSaveHandler
{
    private const float DefaultMainVolume = 0.75f;
    private const float DefaultFxVolume = 0.75f;

    static AudioSettingsSaveHandler()
    {
        if (!HasSavedSettings())
            ResetSettings();
    }

    #region Gets
    private static bool HasSavedSettings() => PlayerPrefs.GetInt(SaveFields.HasSavedAudioSettings) == Boolean.TrueInt;
    public static float GetMainVolume() => PlayerPrefs.GetFloat(SaveFields.MainVolume);
    public static float GetSoundFxVolume() => PlayerPrefs.GetFloat(SaveFields.SFXVolume);
    public static bool IsMainMusicMuted() => PlayerPrefs.GetInt(SaveFields.MainMute) == Boolean.TrueInt;
    public static bool IsSoundFxMuted() => PlayerPrefs.GetInt(SaveFields.SFXMute) != 0;
    #endregion

    #region Sets
    private static void EnableSaving(bool value) => PlayerPrefs.SetInt(SaveFields.HasSavedAudioSettings, new Boolean(value).ToInt());
    public static void SetMainVolume(float volume) => PlayerPrefs.SetFloat(SaveFields.MainVolume, volume);
    public static void SetSoundFxVolume(float volume) => PlayerPrefs.SetFloat(SaveFields.SFXVolume, volume);
    public static void MuteMusic(Boolean shouldMute) => PlayerPrefs.SetInt(SaveFields.MainMute, shouldMute.ToInt());
    public static void MuteSoundFx(Boolean shouldMute) => PlayerPrefs.SetInt(SaveFields.SFXMute, shouldMute.ToInt());
    #endregion

    public static void SaveData()
    {
        PlayerPrefs.Save();
        EnableSaving(true);
    }

    public static void ResetSettings()
    {
        EnableSaving(false);
        SetMainVolume(DefaultMainVolume);
        SetSoundFxVolume(DefaultFxVolume);
        MuteMusic(Boolean.False);
        MuteSoundFx(Boolean.False);
        PlayerPrefs.Save();
    }
}