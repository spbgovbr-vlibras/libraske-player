using Lavid.Libraske.Util;
using System.Collections;
using UnityEngine;

public class PlayingMusicController : InGameController, IPauseObserver, ILoggable
{
    [Header("Loading scenes")]
    [SerializeField] private LoadSceneManager _sceneManager;
    [SerializeField] private string _loadOnFail;
    [SerializeField] private string _loadOnMusicEnd;

    [Header("Process Music End")]
    [SerializeField] private RequestMusicFromURL _musicMediaRequest;
    [SerializeField] private CreateGameSessionRequest _gameSession;
    [SerializeField] private AudioHandler _audio;
    private bool _musicHasEnded;

    private bool _animationSetupReady;
    private bool _musicSetupReady;
    private bool _gameIsPaused;

    public string InLogName => "PlayingMusicController";
    private bool ShouldEndMusic => _animationSetupReady && _musicSetupReady && !_audio.IsPlaying && !_gameIsPaused;

    private void Awake()
    {
        _audio.Stop();

        if (FindObjectOfType<PauseSystem>() is PauseSystem pauseSystem)
            pauseSystem.AddObserver(this);

        StartCoroutine(SetupAnimations());
        StartCoroutine(SetupMusicMedia());
    }

    private IEnumerator SetupMusicMedia()
    {
        string url = _musicHolder.GetMusicData().MusicMediaURL;
        yield return StartCoroutine(_musicMediaRequest.DownloadMusic(url));

        _audio.Play();
        _musicSetupReady = true;
    }

    public override IEnumerator SetupAnimations()
    {
        Music music = this._musicHolder.GetMusicData();
        yield return StartCoroutine(_bundleRequest.SendRequest(music.FullAnimationURL));
        AnimationClip clip = _bundleRequest.GetClipOnBundle(_bundleRequest.GetLastRequest());
        _bundlesDownloadeds.Add(_bundleRequest.GetLastBundle());

        if (clip != null)
        {
            Logger.Log(this, $"Clip {clip.name} received");
            _avatarAnimators.AddClip(clip);
            _avatarAnimators.PlayAll();
            _animationSetupReady = true;
        }
        else
        {
            Logger.Log(this, "Clip received is null");

            if (FindObjectOfType<ErrorSystem>() is ErrorSystem es)
                es.ThrowError(new InGameError("Failed to load music"));
        }
    }

    public void UpdatePauseStatus(bool isPaused)
    {
        _avatarAnimators.EnableAnimations(isPaused);
        _gameIsPaused = isPaused;
    }

    private void Update()
    {
        if (ShouldEndMusic && !_musicHasEnded)
        {
            _musicHasEnded = true;
            CloseSession();
        }
    }

    private void CloseSession()
    {
        //yield return StartCoroutine(_gameSession.EndSessionCoroutine());
        _sceneManager.LoadScene(_loadOnMusicEnd);
    }
}