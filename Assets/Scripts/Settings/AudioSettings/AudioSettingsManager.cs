using Lavid.Libraske.DataStruct;
using UnityEngine;
using Lavid.Libraske.Util;

public class AudioSettingsManager : MonoBehaviour
{
    [SerializeField] private Wrapper<AudioHandler> _audios; 
    [SerializeField] private AudioSettingsView _settingsView;

    private void Awake() 
    {
        if(_settingsView != null)
            _settingsView.OnUIChangeValue += OnUIValueChange;

        AudioSettingsSaveHandler.AllowSaving();
        UpdateAudioObjects();
    }

    private void UpdateAudioObjects()
    {
        for (int i = 0; i < _audios.Length; i++)
        {
            if (_audios[i] != null)
                _audios[i].UpdateVolume();
        }
    }

    private void OnUIValueChange()
    {
        AudioSettingsSaveHandler.SetMusicVolume(_settingsView.MusicVolume);
        AudioSettingsSaveHandler.SetSoundFxVolume(_settingsView.SoundFxVolume);
        AudioSettingsSaveHandler.MuteMusic(new Boolean(_settingsView.IsMainVolumeMuted));
        AudioSettingsSaveHandler.MuteSoundFx(new Boolean(_settingsView.IsFxVolumeMuted));

        UpdateAudioObjects();
    }

    private void OnDestroy()
    {
        if(_settingsView != null)
            _settingsView.OnUIChangeValue -= OnUIValueChange;
    }
}