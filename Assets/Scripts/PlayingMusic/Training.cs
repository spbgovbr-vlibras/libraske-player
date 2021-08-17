using Lavid.Libraske.DataStruct;
using UnityEngine;

public class Training : PlayingMusicController
{
    [Header("UI")]
    [SerializeField] private GameObject _buttonNext;
    [SerializeField] private GameObject _buttonPrevious;

    private IntClampedValue _currentAnimation;
    private int _quantityOfAnimations;

    private const string AnimatorField = "CurrentIndex";

    public override void Setup()
    {
        try
        {
            base.Setup();
            _quantityOfAnimations = _animatorController.animationClips.Length - 1;
            _currentAnimation = new IntClampedValue(0, 0, _quantityOfAnimations);
            UpdateUI();
        }
        catch {}
    }

    public void UpdateAnimatorsValues()
    {
        for (int i = 0; i < _avatarAnimators.Length; i++)
        {
            if(_avatarAnimators[i] != null)
                _avatarAnimators[i].SetInteger(AnimatorField, _currentAnimation.GetCurrentValue());
        }
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
