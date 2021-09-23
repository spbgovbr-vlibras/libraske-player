using Lavid.Libraske.Util;
using UnityEngine;

[RequireComponent(typeof(AudioSettingsModel))]
[RequireComponent(typeof(AudioSettingsView))]
public class AudioSettingsController : MonoBehaviour
{
    [SerializeField] AudioSettingsModel _model;
    [SerializeField] AudioSettingsView _view;

    private void Start() => Setup();

    public void Setup()
    {
        if (!AudioSettingsSaveHandler.HasSavedSettings())
            AudioSettingsSaveHandler.ResetSettings();

        AudioSettingsSaveHandler.AllowSaving();

        _model.Setup
        (
            AudioSettingsSaveHandler.GetMainVolume(),
            AudioSettingsSaveHandler.IsMainMusicMuted(),
            AudioSettingsSaveHandler.GetSoundFxVolume(),
            AudioSettingsSaveHandler.IsSoundFxMuted()
        );

        _view.SetValues(_model.MainVolume, _model.IsMainVolumeMuted, _model.SoundFxVolume, _model.IsFxVolumeMuted);
    }

    /// <summary> Sync values with UI. Called on canvas. /// </summary>
    public void UpdateValues()
    {
        _model.HandleChanges(_view.MainVolumeSlider.value, _view.SoundFxSlider.value, _view.MainSoundToggle.isOn, _view.SoundFxToggle.isOn);
        _view.SetValues(_model.MainVolume, _model.IsMainVolumeMuted, _model.SoundFxVolume, _model.IsFxVolumeMuted);
    }

    /// <summary> Called on canvas to save data on file. /// </summary>
    public void SaveData()
    {
        AudioSettingsSaveHandler.SetMusicVolume(_model.MainVolume);
        AudioSettingsSaveHandler.SetSoundFxVolume(_model.SoundFxVolume);
        AudioSettingsSaveHandler.MuteMusic(new Boolean(_model.IsMainVolumeMuted));
        AudioSettingsSaveHandler.MuteSoundFx(new Boolean(_model.IsFxVolumeMuted));
    }

    public void RestoreSettings()
    {
        AudioSettingsSaveHandler.ResetSettings();

        AudioSettingsSaveHandler.AllowSaving();

        _model.Setup
        (
            AudioSettingsSaveHandler.GetMainVolume(),
            AudioSettingsSaveHandler.IsMainMusicMuted(),
            AudioSettingsSaveHandler.GetSoundFxVolume(),
            AudioSettingsSaveHandler.IsSoundFxMuted()
        );

        _view.SetValues(_model.MainVolume, _model.IsMainVolumeMuted, _model.SoundFxVolume, _model.IsFxVolumeMuted);
    }
}