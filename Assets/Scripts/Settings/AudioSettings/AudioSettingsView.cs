using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsView : MonoBehaviour
{
    public Slider musicSlider, soundEffectsSlider;
    public Toggle musicToggle, soundEffectsToggle;

    public event Action OnUIChangeValue;

    public float MusicVolume { get => musicSlider.value; }
    public float SoundFxVolume { get => soundEffectsSlider.value; }
    public bool IsMainVolumeMuted { get => musicToggle.isOn; }
    public bool IsFxVolumeMuted { get => soundEffectsToggle.isOn; }

    void Start()
    {
        if (!AudioSettingsSaveHandler.HasSavedSettings())
            AudioSettingsSaveHandler.ResetSettings();

        UpdateValues();
    }

    private void UpdateValues()
    {
        musicSlider.value = AudioSettingsSaveHandler.GetMainVolume();
        soundEffectsSlider.value = AudioSettingsSaveHandler.GetSoundFxVolume();
        musicToggle.isOn = AudioSettingsSaveHandler.IsMusicMuted();
        soundEffectsToggle.isOn = AudioSettingsSaveHandler.IsSoundFxMuted();
    }

    public void UpdateSound()
    {
        if (musicToggle.isOn)
            musicSlider.value = 0;

        if (soundEffectsToggle.isOn)
            soundEffectsSlider.value = 0;

        OnUIChangeValue?.Invoke();
    }
}