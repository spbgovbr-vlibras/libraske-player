using UnityEngine;
using Lavid.Libraske.SaveSystem;
using Lavid.Libraske.Util;

public static class AudioSettingsSaveHandler
{
    #region Gets
    public static bool HasSavedSettings() => PlayerPrefs.GetInt(SaveFields.HasSavedAudioSettings) == Boolean.TrueInt;
    public static float GetMainVolume() => PlayerPrefs.GetFloat(SaveFields.MainVolume);
    public static float GetSoundFxVolume() => PlayerPrefs.GetFloat(SaveFields.SFXVolume);
    public static bool IsMainMusicMuted() => PlayerPrefs.GetInt(SaveFields.MainMute) == Boolean.TrueInt;
    public static bool IsSoundFxMuted() => PlayerPrefs.GetInt(SaveFields.SFXMute) != 0;
    #endregion

    #region Sets
    public static void AllowSaving(bool value = true) => PlayerPrefs.SetInt(SaveFields.HasSavedAudioSettings, new Boolean(value).ToInt());
    public static void SetMusicVolume(float volume) => PlayerPrefs.SetFloat(SaveFields.MainVolume, volume);
    public static void SetSoundFxVolume(float volume) => PlayerPrefs.SetFloat(SaveFields.SFXVolume, volume);
    public static void MuteMusic(Boolean shouldMute) => PlayerPrefs.SetInt(SaveFields.MainMute, shouldMute.ToInt());
    public static void MuteSoundFx(Boolean shouldMute) => PlayerPrefs.SetInt(SaveFields.SFXMute, shouldMute.ToInt());
    #endregion

    public static void ResetSettings()
    {
        PlayerPrefs.SetFloat(SaveFields.MainVolume, 1);
        PlayerPrefs.SetFloat(SaveFields.SFXVolume, 1);
        PlayerPrefs.SetInt(SaveFields.MainMute, Boolean.FalseInt);
        PlayerPrefs.SetInt(SaveFields.SFXMute, Boolean.FalseInt);
    }
}