using Lavid.Libraske.DataStruct;
using Lavid.Libraske.Util;
using System;
using UnityEngine;

public class PlayingMusicController : MonoBehaviour
{
    [SerializeField] private MusicHolderSO _musicHolder;
    [SerializeField] private MusicListSO _musicList;
    [SerializeField] protected Wrapper<Animator> _avatarAnimators;

    [Header("Case failed to find music")]
    [SerializeField] private LoadSceneManager _sceneManager;
    [SerializeField] private string _sceneToLoad;

    protected RuntimeAnimatorController _animatorController;

    private void OnEnable() => Setup();

    public virtual void Setup()
    {
        int index = int.Parse(_musicHolder.GetMusic().Id);
        _animatorController = null;

        try
        {
            _animatorController = _musicList.GetControllerAtIndex(index);

            for (int i = 0; i < _avatarAnimators.Length; i++)
                _avatarAnimators[i].runtimeAnimatorController = _animatorController;
        }
        catch (Exception err)
        {
            Debug.LogException(err);
            _sceneManager.LoadScene(_sceneToLoad);
        }
    }
}