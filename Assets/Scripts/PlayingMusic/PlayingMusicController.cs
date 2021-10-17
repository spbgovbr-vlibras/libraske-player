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
    [SerializeField] private GameSession _gameSession;
    [SerializeField] private AudioHandler _audio;
    private bool _musicHasEnded;

    private bool _setupReady;
    public string InLogName => "PlayingMusicController";
    private bool ShouldEndMusic => _setupReady && _audio.AudioClipEnded;

    private void Awake()
    {
        _audio.Stop();

        if (FindObjectOfType<PauseSystem>() is PauseSystem pauseSystem)
            pauseSystem.AddObserver(this);

        StartCoroutine(SetupAnimations());
    }

    public override IEnumerator SetupAnimations()
    {
        Music music = this._musicHolder.GetMusic();
        yield return StartCoroutine(_bundleRequest.SendRequest(music.URLFullMusic));
        AnimationClip clip = _bundleRequest.TryGetFirstClip(_bundleRequest.GetLastRequest());

        if (clip != null)
        {
            Logger.Log(this, $"Clip {clip.name} received");
            _avatarAnimators.AddClip(clip);
            _avatarAnimators.PlayAll();
            _audio.Play();
            _setupReady = true;
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
        _avatarAnimators.EnableAnimations(!isPaused);
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