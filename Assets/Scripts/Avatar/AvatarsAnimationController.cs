using Lavid.Libraske.DataStruct;
using UnityEngine;

public class AvatarsAnimationController : MonoBehaviour, IPauseObserver
{
    [SerializeField] private Wrapper<Animator> _avatarAnimators;
    [SerializeField] private int _animationsQuantity;

    private IntClampedValue _currentAnimation;
    private const string AnimatorField = "CurrentIndex";

    // To Debug -----------------------
    public RuntimeAnimatorController _musicToApply;
    private void Start()
    {
        if (FindObjectOfType<PauseSystem>() is PauseSystem pauseSystem)
            pauseSystem.AddObserver(this);

        Setup(_musicToApply);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
            Next();

        if (Input.GetKeyDown(KeyCode.P))
            Previous();
    }

    // -----------------------------------

    public void Setup(RuntimeAnimatorController music)
    {
        for (int i = 0; i < _avatarAnimators.Length; i++)
            _avatarAnimators[i].runtimeAnimatorController = music;

        _currentAnimation = new IntClampedValue(0, 0, music.animationClips.Length - 1);
    }


    public void EnableAnimators(bool value)
    {
        for (int i = 0; i < _avatarAnimators.Length; i++)
            _avatarAnimators[i].enabled = value;
    }
    public void UpdateAnimatorsValues()
    {
        for (int i = 0; i < _avatarAnimators.Length; i++)
            _avatarAnimators[i].SetInteger(AnimatorField, _currentAnimation.GetCurrentValue());
    }
    public void Next()
    {
        _currentAnimation.Add(1);
        UpdateAnimatorsValues();
    }
    public void Previous()
    {
        _currentAnimation.Add(-1);
        UpdateAnimatorsValues();
    }

    public void UpdatePauseStatus(bool isPaused) => EnableAnimators(!isPaused);
}