using Lavid.Libraske.Util;
using System;
using UnityEngine;

public class PlayingMusicController : MonoBehaviour, IPauseObserver, IBarrier
{
    [Header("Process Media")]
    [SerializeField] private MusicMediaHolderSO _mediaHolderSO;
    [SerializeField] private SubtitleReader _subtitleReader;
    [SerializeField] private AudioHandler _audio;
    [SerializeField] private AvatarAnimationController _avatarAnimators;

    [Header("Process Music End")]
    private bool _gameIsPaused;
    private bool _setupReady;
    public event Action OnUnlockBarrier;
    public bool IsUnlocked { get; private set; }
    private bool ShouldEndMusic => _setupReady && !_audio.IsPlaying && !_gameIsPaused;
    public bool ShouldUnlock() => !IsUnlocked && ShouldEndMusic;


    private void Awake()
    {
        _audio.Stop();

        if (FindObjectOfType<PauseSystem>() is PauseSystem pauseSystem)
            pauseSystem.AddObserver(this);

        SetupGameplay();
    }

    private void SetupGameplay()
    {
        _avatarAnimators.AddAnimation(_mediaHolderSO.MusicAnimation);
        _audio.SetClip(_mediaHolderSO.MusicAudio);
        _subtitleReader.ReadSubtitle(_mediaHolderSO.Subtitle);
        _audio.Play();
        _avatarAnimators.PlayAll();
        _setupReady = true;
    }

    public void UpdatePauseStatus(bool isPaused)
    {
        _avatarAnimators.EnableAnimations(isPaused);
        _gameIsPaused = isPaused;
    }

    private void Update() => TryUnlock();

    public void TryUnlock()
    {
        if (ShouldUnlock())
        {
            OnUnlockBarrier?.Invoke();
            IsUnlocked = true;
        }
    }
}