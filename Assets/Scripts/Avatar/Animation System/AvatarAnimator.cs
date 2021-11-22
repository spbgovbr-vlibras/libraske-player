using Lavid.Libraske.DataStruct;
using UnityEngine;

/*
 * Nota: Nao altere o componente Animation via inspector. 
 */
public class AvatarAnimator : MonoBehaviour
{
    [SerializeField] private Animation _controller;
    [SerializeField] private Wrapper<AvatarAnimation> _animations;

    private const float DefaultAnimationStateSpeed = 1;
    private const float PausedAnimationStateSpeed = 0;

    public bool IsPlaying() => _controller.isActiveAndEnabled && _controller.isPlaying;

    public void AddAnimation(AvatarAnimation animation)
    {
        if (_animations == null)
            _animations = new Wrapper<AvatarAnimation>();

        _controller.AddClip(animation.Clip, animation.Name);
        _animations.Add(animation);
    }

    public void AddClip(AnimationClip clip)
    {
        if (_animations == null)
            _animations = new Wrapper<AvatarAnimation>();

        _controller.AddClip(clip, clip.name);
        _animations.Add(new AvatarAnimation(clip, clip.name));
    }

    public void ClearQueue()
    {
        foreach (AnimationState state in _controller)
            _controller.RemoveClip(state.name);

        if(_animations != null)
            _animations.Clear();
    }

    public void PlayAt(int index)
    {
        if (_animations == null)
            return; 

        _controller.Play(_animations[index].Name);
    }

    public void PlayAll()
    {
        for (int i = 0; i < _animations.Length; i++)
            _controller.PlayQueued(_animations[i].Name);
    }

    public void Resume()
    {
        foreach (AnimationState state in _controller)
            state.speed = DefaultAnimationStateSpeed;
    }

    public void SetPaused(bool value)
    {
        float spd = value ? PausedAnimationStateSpeed : DefaultAnimationStateSpeed;
        foreach (AnimationState state in _controller)
            state.speed = spd;
    }
}
