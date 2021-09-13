using UnityEngine;

public class AudioSettingsUser : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicVolumePref = "MusicVolumePref";
    private static readonly string SFXVolumePref = "SFXVolumePref";
    private static readonly string MusicMute = "MusicMute";
    private static readonly string SFXMute = "SFXMute";
    private int firstPlayInt;
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

            UpdateSound();
        }
        else
        {
            musicFloat = PlayerPrefs.GetFloat(MusicVolumePref);
            soundEffectsFloat = PlayerPrefs.GetFloat(SFXVolumePref);
            musicMuteBoolean = (PlayerPrefs.GetInt(MusicMute) != 0);
            soundEffectsMuteBoolean = (PlayerPrefs.GetInt(SFXMute) != 0);

            UpdateSound();
        }
    }

    public void ResetSoundSettings()
    {
        musicFloat = 1f;
        soundEffectsFloat = 1f;
        musicMuteBoolean = false;
        soundEffectsMuteBoolean = false; 

        PlayerPrefs.SetFloat(MusicVolumePref, musicFloat);
        PlayerPrefs.SetFloat(SFXVolumePref, soundEffectsFloat);
        PlayerPrefs.SetInt(MusicMute, (musicMuteBoolean ? 1 : 0));
        PlayerPrefs.SetInt(SFXMute, (soundEffectsMuteBoolean ? 1 : 0));
    }

    public void UpdateSound()
    {
        if(sceneMusic != null)
        {
            if (musicMuteBoolean)
                sceneMusic.volume = 0;
            else
                sceneMusic.volume = musicFloat;
        }

        if (soundEffectsMuteBoolean)
        {
            for (int i = 0; i < sceneSFX.Length; i++)
            {
                sceneSFX[i].volume = 0;
            }
        }
        else
        {
            for (int i = 0; i < sceneSFX.Length; i++)
            {
                sceneSFX[i].volume = soundEffectsFloat;
            }
        }
    }

}
