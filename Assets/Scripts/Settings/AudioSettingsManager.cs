
using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicVolumePref = "MusicVolumePref";
    private static readonly string SFXVolumePref = "SFXVolumePref";
    private static readonly string MusicMute = "MusicMute";
    private static readonly string SFXMute = "SFXMute";
    private int firstPlayInt;
    public Slider musicSlider, soundEffectsSlider;
    public Toggle musicToggle, soundEffectsToggle;
    private float musicFloat, soundEffectsFloat;
    private bool musicMuteBoolean, soundEffectsMuteBoolean;
    public AudioSource sceneMusic;
    public AudioSource[] sceneSFX;

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if (firstPlayInt == 0)
        {
            ResetSoundSettings();
            PlayerPrefs.SetInt(FirstPlay, -1);
        }
        else
        {
            musicFloat = PlayerPrefs.GetFloat(MusicVolumePref);
            soundEffectsFloat = PlayerPrefs.GetFloat(SFXVolumePref);
            musicMuteBoolean = (PlayerPrefs.GetInt(MusicMute) != 0);
            soundEffectsMuteBoolean = (PlayerPrefs.GetInt(SFXMute) != 0);

            musicSlider.value = musicFloat;
            soundEffectsSlider.value = soundEffectsFloat;
            musicToggle.isOn = musicMuteBoolean;
            soundEffectsToggle.isOn = soundEffectsMuteBoolean;
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(MusicVolumePref, musicSlider.value);
        PlayerPrefs.SetFloat(SFXVolumePref, soundEffectsSlider.value);
        PlayerPrefs.SetInt(MusicMute, (musicToggle.isOn ? 1 : 0));
        PlayerPrefs.SetInt(SFXMute, (soundEffectsToggle.isOn ? 1 : 0));
    }

    public void ResetSoundSettings()
    {
        musicFloat = 1f;
        soundEffectsFloat = 1f;
        musicMuteBoolean = false;
        soundEffectsMuteBoolean = false;

        musicToggle.isOn = musicMuteBoolean;
        soundEffectsToggle.isOn = soundEffectsMuteBoolean;

        musicSlider.value = musicFloat;
        soundEffectsSlider.value = soundEffectsFloat;   

        PlayerPrefs.SetFloat(MusicVolumePref, musicFloat);
        PlayerPrefs.SetFloat(SFXVolumePref, soundEffectsFloat);
        PlayerPrefs.SetInt(MusicMute, (musicMuteBoolean ? 1 : 0));
        PlayerPrefs.SetInt(SFXMute, (soundEffectsMuteBoolean ? 1 : 0));
    }

    public void UpdateSound()
    {
        if (musicToggle.isOn)
        {
            sceneMusic.volume = 0;
            musicSlider.value = 0;
        }
        else
        {
            sceneMusic.volume = musicSlider.value;
        }

        if (soundEffectsToggle.isOn)
        {
            soundEffectsSlider.value = 0;
            for (int i = 0; i < sceneSFX.Length; i++)
            {
                sceneSFX[i].volume = 0;
            }
        }
        else
        {
            for (int i = 0; i < sceneSFX.Length; i++)
            {
                sceneSFX[i].volume = soundEffectsSlider.value;
            }
        }
    }

}