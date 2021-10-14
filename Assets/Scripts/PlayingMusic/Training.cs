using Lavid.Libraske.DataStruct;
using Lavid.Libraske.Util;
using System;
using UnityEngine;

public class Training : MonoBehaviour
{
    [Header("Controller")]
    [SerializeField] private MusicHolderSO _musicHolder;
    [SerializeField] private MusicListSO _musicList;
    [SerializeField] private AvatarAnimationController _avatarAnimator;

    [Header("UI")]
    [SerializeField] private GameObject _buttonNext;
    [SerializeField] private GameObject _buttonPrevious;

    private IntClampedValue _currentAnimation;
    private int _quantityOfAnimations;

    private const string AnimatorField = "CurrentIndex";

    private void Awake() => Setup();

    public void Setup()
    {
        int index = 0;// TODO: Fix this

        try
        {
            RuntimeAnimatorController animatorController = _musicList.GetControllerAtIndex(index);

            _avatarAnimator.SetController(animatorController);

            _quantityOfAnimations = animatorController.animationClips.Length - 1;
            _currentAnimation = new IntClampedValue(0, 0, _quantityOfAnimations);
            UpdateUI();
        }
        catch (Exception err)
        {
            Debug.LogException(err);
            if (FindObjectOfType<ErrorSystem>() is ErrorSystem es)
                es.ThrowError(new InGameError("Failed to load music"));
        }
    }

    public void UpdateAnimatorsValues() => _avatarAnimator.SetInteger(AnimatorField, _currentAnimation.GetCurrentValue());

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
