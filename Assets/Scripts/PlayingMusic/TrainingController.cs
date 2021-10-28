using Lavid.Libraske.DataStruct;
using System.Collections;
using UnityEngine;

public class TrainingController : InGameController 
{
    private const int TrainingSteps = 5;

    [Header("UI")]
    [SerializeField] private GameObject _buttonNext;
    [SerializeField] private GameObject _buttonPrevious;

    private IntClampedValue _currentAnimation;

    private void Awake()
    {
        _currentAnimation = new IntClampedValue(0, 0, TrainingSteps - 1);
        StartCoroutine(SetupAnimations());
    }

    public void UpdateAnimatorsValues() => _avatarAnimators.PlayAt(_currentAnimation.GetCurrentValue());

    public void UpdateUI()
    {
        if (_buttonPrevious == null || _buttonNext == null)
            return;

        bool enablePrevious = _currentAnimation.GetCurrentValue() > 0;
        bool enableNext = _currentAnimation.GetCurrentValue() < TrainingSteps -1;

        _buttonNext.SetActive(enableNext);
        _buttonPrevious.SetActive(enablePrevious);
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

    public override IEnumerator SetupAnimations()
    {
        Music music = _musicHolder.GetMusicData();
        AnimationClip clip;

        for (int i = 0; i < TrainingSteps; i++)
        {
            yield return StartCoroutine(_bundleRequest.SendRequest(music.GetTrainingAnimationURL(i)));
            clip = _bundleRequest.GetClipOnBundle(_bundleRequest.GetLastRequest());
            _avatarAnimators.AddClip(clip);
            _bundlesDownloadeds.Add(_bundleRequest.GetLastBundle());
        }

        UpdateUI();
        UpdateAnimatorsValues();
    }
}