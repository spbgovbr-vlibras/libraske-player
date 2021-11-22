using Lavid.Libraske.DataStruct;
using UnityEngine;

public class AvatarAnimationController : MonoBehaviour
{
    [SerializeField] private Wrapper<AvatarAnimator> _animators;

    public void AddAnimation(AvatarAnimation anim)
    {
        for (int i = 0; i < _animators.Length; i++)
        {
            _animators[i].AddAnimation(anim);
        }
    }


    public void AddClip(AnimationClip clip)
    {
        for (int i = 0; i < _animators.Length; i++)
        {
            _animators[i].AddClip(clip);
        }
    }

    public void PlayAll()
    {
        for (int i = 0; i < _animators.Length; i++)
        {
            if (_animators[i] != null)
                _animators[i].PlayAll();
        }
    }

    public void PlayAt(int index)
    {
        for (int i = 0; i < _animators.Length; i++)
        {
            if (_animators[i] != null)
                _animators[i].PlayAt(index);
        }
    }

    public void EnableAnimations(bool value)
    {
        for (int i = 0; i < _animators.Length; i++)
            _animators[i].SetPaused(value);
    }
}