using UnityEngine;

public class AvatarAnimatorDebugger : MonoBehaviour
{
    [SerializeField] AvatarAnimator _animator;
    [SerializeField] AnimationClip[] _clips;

    [SerializeField] bool _addClips;
    [SerializeField] bool _playAll;
    [SerializeField] bool _clearQueue;
    [SerializeField] bool _triggerPause;

    bool _isPaused;

    // Update is called once per frame
    void Update()
    {
        if (_addClips)
        {
            AddClip(_clips);
            _addClips = false;
        }

        if (_playAll)
        {
            PlayAll();
            _playAll = false;
        }

        if (_clearQueue)
        {
            ClearQueue();
            _clearQueue = false;
        }

        if (_triggerPause)
        {
            TriggerPause();
            _triggerPause = false;
        }
    }

    private void PlayAll() => _animator.PlayAll();
    private void ClearQueue() => _animator.ClearQueue();
    public void AddClip(AnimationClip[] clips)
    {
        for(int i = 0; i < clips.Length; i++)
            _animator.AddClip(clips[i]);
    }

    private void TriggerPause()
    {
        _isPaused = !_isPaused;
        _animator.SetPaused(_isPaused);
    }
}