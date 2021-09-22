using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    private enum AudioType { Main, Fx }

    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioType _audioType;

    private const int DefaultVolume = 1;

    private void OnEnable() => SyncVolumeWithSave();

    public void SetVolume(float volume) => _audioSource.volume = volume;

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
}
