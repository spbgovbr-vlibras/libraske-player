using System.Collections.Generic;
using UnityEngine;

public class AvatarAnimationBundle : MonoBehaviour
{
    [SerializeField] Animation _animation;
    [SerializeField] AnimationClip _clip;

    [SerializeField] bool _addClip;
    [SerializeField] bool _playAll;
    [SerializeField] bool _pause;

    bool _isPaused;
    List<float> _defaultSpeeds;
    private readonly int OnPausedSpeed = 0;

    // Update is called once per frame
    void Update()
    {
        if (_addClip)
        {
            AddClip(_clip);
            _addClip = false;
        }

        if (_playAll)
        {
            PlayAll();
            _playAll = false;
        }

        if (_pause)
        {
            Pause();
            _pause = false;
        }
    }

    private void PlayAll()
    {
        for (int i = 0; i < _animation.GetClipCount(); i++)
            _animation.PlayQueued(i.ToString());

        SetupDefaultSpeeds();
    }

    private void SetupDefaultSpeeds()
    {
        _defaultSpeeds = new List<float>();

        foreach (AnimationState state in _animation)
            _defaultSpeeds.Add(state.speed);
    }

    public void AddClip(AnimationClip clip)
    {
        _animation.AddClip(clip, _animation.GetClipCount().ToString());
    }

    private void Pause()
    {
        _isPaused = !_isPaused;

        if (_isPaused)
        {
            foreach (AnimationState state in _animation)
                state.speed = OnPausedSpeed;
        }
        else
        {
            int index = 0;
            foreach (AnimationState state in _animation)
            {
                state.speed = _defaultSpeeds[index];
                index++;
            }
        }
    }
}