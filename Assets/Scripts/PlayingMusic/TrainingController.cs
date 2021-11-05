using Lavid.Libraske.DataStruct;
using UnityEngine;

public class TrainingController : MonoBehaviour
{
    [SerializeField] MusicDataHolderSO _musicDataHolder;
    [SerializeField] MusicMediaHolderSO _mediaHolderSO;
    [SerializeField] AvatarAnimationController _avatarsController;

    [Header("UI")]
    [SerializeField] private GameObject _buttonNext;
    [SerializeField] private GameObject _buttonPrevious;
    [SerializeField] private SubtitleHUD _subtitleHUD;

    private IntClampedValue _animationClamp;

    public const int TrainingStepsQuantity = 4;

    private void Start() => SetupAnimations();
    public void SetupAnimations()
    {
        AvatarAnimation[] animations = _mediaHolderSO.TrainingAnimations;
        _animationClamp = new IntClampedValue(0, 0, animations.Length - 1);

        for (int i = 0; i < animations.Length; i++)
        {
            _avatarsController.AddAnimation(animations[i]);
        }

        UpdateValues();
    }

    public void NextStep() => UpdateValues(1);
    public void PreviousStep() => UpdateValues(-1);
    public void UpdateValues(int valueToIncrease = 0)
    {
        _animationClamp.Add(valueToIncrease);
        int currIndex = _animationClamp.GetCurrentValue();
        UpdateAnimatorsValues(currIndex);
        UpdateUI(currIndex, _animationClamp.GetMaxValue());
        UpdateSubtitle(currIndex);
    }

    public void UpdateSubtitle(int currIndex)
    {
        string description = _musicDataHolder.GetMusicData().GetTrainingDescription(currIndex);
        _subtitleHUD.ApplyText(description);
    }
    public void UpdateAnimatorsValues(int currIndex) => _avatarsController.PlayAt(currIndex);
    public void UpdateUI(int currIndex, int maxIndex)
    {
        if (_buttonPrevious == null || _buttonNext == null)
            return;

        bool enablePrevious = currIndex > 0;
        bool enableNext = currIndex < maxIndex;

        _buttonNext.SetActive(enableNext);
        _buttonPrevious.SetActive(enablePrevious);
    }
}