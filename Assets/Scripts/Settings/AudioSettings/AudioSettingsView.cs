using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsView : MonoBehaviour
{
    public Slider _mainVolumeSlider;
    public Slider _soundFxSlider;
    public Toggle _musicToggle;
    public Toggle _soundEffectsToggle;

    public Slider MainVolumeSlider => _mainVolumeSlider;
    public Slider SoundFxSlider => _soundFxSlider;
    public Toggle MainSoundToggle => _musicToggle;
    public Toggle SoundFxToggle => _soundEffectsToggle;

    public void SetValues(float mainVolume, bool muteMainVolume, float fxVolume, bool muteFxVolume)
    {
        _mainVolumeSlider.value = mainVolume;
        _soundFxSlider.value = fxVolume;
        _musicToggle.isOn = muteMainVolume;
        _soundEffectsToggle.isOn = muteFxVolume;
    }
}