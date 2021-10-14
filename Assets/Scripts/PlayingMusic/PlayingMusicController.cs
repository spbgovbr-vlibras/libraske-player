using Lavid.Libraske.DataStruct;
using Lavid.Libraske.Util;
using System;
using System.Collections;
using UnityEngine;

public class PlayingMusicController : MonoBehaviour, IPauseObserver
{
    [SerializeField] private MusicHolderSO _musicHolder;
    [SerializeField] private MusicListSO _musicList;
    [SerializeField] private AvatarAnimationController _avatarAnimation;

    [Header("Loading scenes")]
    [SerializeField] private LoadSceneManager _sceneManager;
    [SerializeField] private string _loadOnFail;
    [SerializeField] private string _loadOnMusicEnd;

    [Header("Process Music End")]
    [SerializeField] private GameSession _gameSession;
    [SerializeField] private AudioHandler _audio;
    private bool _musicHasEnded;

    private void Awake()
    {
        if (FindObjectOfType<PauseSystem>() is PauseSystem pauseSystem)
            pauseSystem.AddObserver(this);

        Setup();
    }

    public virtual void Setup()
    {
        // TODO: Get Music By ID on database
        int index = 0;// int.Parse(_musicHolder.GetMusic().Id);

        try
        {
            RuntimeAnimatorController animatorController = _musicList.GetControllerAtIndex(index);
            _avatarAnimation.SetController(animatorController);
        }
        catch (Exception err)
        {
            Debug.LogException(err);
            if (FindObjectOfType<ErrorSystem>() is ErrorSystem es)
                es.ThrowError(new InGameError("Failed to load music"));

            _sceneManager.LoadScene(_loadOnFail);
        }
    }

    public void UpdatePauseStatus(bool isPaused)
    {
        _avatarAnimation.EnableAnimations(!isPaused);
    }

    private void Update()
    {
        if (!_musicHasEnded && _audio.AudioClipEnded)
        {
            _musicHasEnded = true;
            CloseSession();
        }
    }

    private void CloseSession()
    {
        //yield return _gameSession.EndSessionCoroutine();
        _sceneManager.LoadScene(_loadOnMusicEnd);
    }
}