using Lavid.Libraske.SaveSystem;
using Lavid.Libraske.Util;
using UnityEngine;
using Lavid.Libraske.Avatar;

public static class AvatarVLibrasSelectionSaveHandler
{
    static AvatarVLibrasSelectionSaveHandler()
    {
        if (!HasSavedSettings())
            ResetSettings();
    }

    private static bool HasSavedSettings() => PlayerPrefs.GetInt(SaveFields.HasSavedAvatarSelection) == Boolean.TrueInt;
    public static void EnableSaving(bool value) => PlayerPrefs.SetInt(SaveFields.HasSavedAvatarSelection, new Boolean(value).ToInt());
    public static void SelectAvatar(AvatarNameEnum avatar) => PlayerPrefs.SetInt(SaveFields.AvatarChoosed, (int)avatar);
    public static AvatarNameEnum GetAvatarSaved() => (AvatarNameEnum)PlayerPrefs.GetInt(SaveFields.AvatarChoosed);

    public static void SaveData()
    {
        EnableSaving(true);
        PlayerPrefs.Save();
    }
    public static void ResetSettings()
    {
        SelectAvatar(AvatarNameEnum.Icaro);
        SaveData();
    }
}
