using Lavid.Libraske.DataStruct;
using UnityEngine;

public class AudioSettingsModel : MonoBehaviour
{
    [SerializeField] private AudioSettingsController _controller;

    // Primitive values to allow debugging on Inspector
    private float _mainVolume;
    private float _fxVolume;
    private bool _isMainVolumeMuted;
    private bool _isFxVolumeMuted;

    // To validate changes
    private bool _mainVolumeWasMuted;
    private bool _fxVolumeWasMuted;
    private float _mainVolumeB4BeMuted;
    private float _fxVolumeB4BeMuted;

    // Audio previews
    [SerializeField] private Wrapper<AudioHandler> _mainPreviews;
    [SerializeField] private Wrapper<AudioHandler> _fxPreviews;

    public float MainVolume { get => _mainVolume; }
    public float SoundFxVolume { get => _fxVolume; }
    public bool IsMainVolumeMuted { get => _isMainVolumeMuted; }
    public bool IsFxVolumeMuted { get => _isFxVolumeMuted; }

    public void Setup(float mainVolume, bool isMainVolumeMuted, float fxVolume, bool isFxVolumeMuted)
    {
        UpdateCurrentValues(mainVolume, isMainVolumeMuted, fxVolume, isFxVolumeMuted);
        UpdateLastFrameValues();
    }

    public void HandleChanges
    (
        in float mainVolume,
        in float fxVolume,
        in bool isMainVolumeMuted,
        in bool isFxVolumeMuted
    )
    {
        UpdateCurrentValues(mainVolume, isMainVolumeMuted, fxVolume, isFxVolumeMuted);

        ChangeVolumeAfterTriggerUnmute(in _isMainVolumeMuted, in _mainVolumeWasMuted, ref _mainVolume, in _mainVolumeB4BeMuted);
        ChangeVolumeAfterTriggerUnmute(in _isFxVolumeMuted, in _fxVolumeWasMuted, ref _fxVolume, in _fxVolumeB4BeMuted);

        MuteVolumeAfterTriggerMute(in _isMainVolumeMuted, in _mainVolumeWasMuted, ref _mainVolume);
        MuteVolumeAfterTriggerMute(in _isFxVolumeMuted, in _fxVolumeWasMuted, ref _fxVolume);

        UpdateMuteTrigger(in _mainVolume, ref _isMainVolumeMuted);
        UpdateMuteTrigger(in _fxVolume, ref _isFxVolumeMuted);

        UpdatePreviewAudios();
        UpdateLastFrameValues();
    }

    private void MuteVolumeAfterTriggerMute(in bool isVolumeMuted, in bool volumeWasMuted, ref float volume)
    {
        if (isVolumeMuted && !volumeWasMuted)
            volume = 0;
    }

    private void UpdateCurrentValues(float mainVolume, bool isMainVolumeMuted, float fxVolume, bool isFxVolumeMuted)
    {
        _mainVolume = mainVolume;
        _fxVolume = fxVolume;
        _isMainVolumeMuted = isMainVolumeMuted;
        _isFxVolumeMuted = isFxVolumeMuted;
    }

    private void UpdateLastFrameValues()
    {
        _fxVolumeWasMuted = _isFxVolumeMuted;
        _mainVolumeWasMuted = _isMainVolumeMuted;
        _fxVolumeB4BeMuted = _isFxVolumeMuted ? _fxVolumeB4BeMuted : _fxVolume;
        _mainVolumeB4BeMuted = _isMainVolumeMuted ? _mainVolumeB4BeMuted : _mainVolume;
    }

    private void UpdateMuteTrigger(in float volume, ref bool isMuted) => isMuted = volume == 0;

    private void ChangeVolumeAfterTriggerUnmute(in bool isMuted, in bool wasMuted, ref float volume, in float newVolume)
    {
        if (!isMuted && wasMuted)
            volume = newVolume;
    }

    private void UpdatePreviewAudios()
    {
        float mainVolume = _mainVolume;
        float fxVolume = _fxVolume;

        for (int i = 0; i < _mainPreviews.Length; i++)
        {
            if (_mainPreviews[i] != null)
                _mainPreviews[i].SetVolume(mainVolume);
        }

        for (int i = 0; i < _fxPreviews.Length; i++)
        {
            if (_fxPreviews[i] != null)
                _fxPreviews[i].SetVolume(fxVolume);
        }
    }
}