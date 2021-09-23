﻿using UnityEngine;

public class AudioHandler : MonoBehaviour, IPauseObserver
{
    private enum AudioType { Main, Fx }

    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioType _audioType;

    private const int DefaultVolume = 1;

    private void Awake()
    {
        if(FindObjectOfType<PauseSystem>() is PauseSystem ps)
        {
            ps.AddObserver(this);
        }
    }

    private void OnDestroy()
    {
        if (FindObjectOfType<PauseSystem>() is PauseSystem ps)
        {
            ps.RemoveObserver(this);
        }
    }

    private void OnEnable() => SyncVolumeWithSave();

    public void SetVolume(float volume) => _audioSource.volume = volume;

    public void PlayOneShot(AudioClip clip)
    {
        if(clip != null && _audioSource != null)
            _audioSource.PlayOneShot(clip);
    }

    public void SyncVolumeWithSave()
    {
        if (!AudioSettingsSaveHandler.HasSavedSettings())
        {
            _audioSource.volume = DefaultVolume;
            return;   
        }

        if (_audioType == AudioType.Main)
            _audioSource.volume = AudioSettingsSaveHandler.GetMainVolume();
        else
            _audioSource.volume = AudioSettingsSaveHandler.GetSoundFxVolume();
    }

    public void UpdatePauseStatus(bool isPaused)
    {
        if (_audioSource == null)
            return;

        if (isPaused)
            _audioSource.Pause();
        else
            _audioSource.Play();

        SyncVolumeWithSave();
    }
}