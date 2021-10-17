using UnityEngine;

[System.Serializable]
public struct AvatarAnimation 
{
    private AnimationClip _clip;
    private float _defaultSpeed;
    private string _name;

    public readonly AnimationClip Clip => _clip;
    public readonly float DefaultSpeed => _defaultSpeed;
    public readonly string Name => _name;

    public AvatarAnimation(AnimationClip clip, string name)
    {
        _clip = clip;
        _name = name;
        _defaultSpeed = 1;
    }

    public AvatarAnimation(AnimationClip clip, string name, float defaultSpeed)
    {
        _clip = clip;
        _name = name;
        _defaultSpeed = defaultSpeed;
    }
}
