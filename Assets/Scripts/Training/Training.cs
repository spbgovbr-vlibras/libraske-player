using Lavid.Libraske.DataStruct;
using UnityEngine;

public class Training : MonoBehaviour
{
    [SerializeField] private Wrapper<Animator> _avatarAnimators;

    [Header("UI")]
    [SerializeField] private GameObject _buttonNext;
    [SerializeField] private GameObject _buttonPrevious;

    private IntClampedValue _currentAnimation;
    private int _quantityOfAnimations;

    private const string AnimatorField = "CurrentIndex";


    // To Debug -----------------------
    public RuntimeAnimatorController _musicToApply;
    private void Start()
    {
        Setup(_musicToApply);
        UpdateUI();
    }
    // -------------------

    public void Setup(RuntimeAnimatorController music)
    {
        for (int i = 0; i < _avatarAnimators.Length; i++)
            _avatarAnimators[i].runtimeAnimatorController = music;

        _quantityOfAnimations = music.animationClips.Length - 1;
        _currentAnimation = new IntClampedValue(0, 0, _quantityOfAnimations);
    }

    public void UpdateAnimatorsValues()
    {
        for (int i = 0; i < _avatarAnimators.Length; i++)
            _avatarAnimators[i].SetInteger(AnimatorField, _currentAnimation.GetCurrentValue());
    }

    public void UpdateUI()
    {
        if (_buttonPrevious == null || _buttonNext == null)
            return;

        _buttonNext.SetActive(true);
        _buttonPrevious.SetActive(false);

        if (_currentAnimation.GetCurrentValue() > 0)
            _buttonPrevious.SetActive(true);

        if (_currentAnimation.GetCurrentValue() == _quantityOfAnimations)
            _buttonNext.SetActive(false);
    }

    public void NextStep()
    {
        _currentAnimation.Add(1);
        UpdateAnimatorsValues();
        UpdateUI();
    }
    public void PreviousStep()
    {
        _currentAnimation.Add(-1);
        UpdateAnimatorsValues();
        UpdateUI();
    }
}
