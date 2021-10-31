using Lavid.Libraske.DataStruct;
using UnityEngine;

public class TrainingController : MonoBehaviour
{
    [SerializeField] MusicMediaHolderSO _mediaHolderSO;
    [SerializeField] AvatarAnimationController _avatarsController;

    [Header("UI")]
    [SerializeField] private GameObject _buttonNext;
    [SerializeField] private GameObject _buttonPrevious;

    private IntClampedValue _animationClamp;

    private void Start() => SetupAnimations();

    public void UpdateAnimatorsValues() => _avatarsController.PlayAt(_animationClamp.GetCurrentValue());

    public void UpdateUI()
    {
        if (_buttonPrevious == null || _buttonNext == null)
            return;

        bool enablePrevious = _animationClamp.GetCurrentValue() > 0;
        bool enableNext = _animationClamp.GetCurrentValue() < _animationClamp.GetMaxValue();

        _buttonNext.SetActive(enableNext);
        _buttonPrevious.SetActive(enablePrevious);
    }

    public void NextStep()
    {
        _animationClamp.Add(1);
        UpdateAnimatorsValues();
        UpdateUI();
    }
    public void PreviousStep()
    {
        _animationClamp.Add(-1);
        UpdateAnimatorsValues();
        UpdateUI();
    }

    public void SetupAnimations()
    {
        AvatarAnimation[] animations = _mediaHolderSO.TrainingAnimations;
        _animationClamp = new IntClampedValue(0, 0, animations.Length - 1);

        for (int i = 0; i < animations.Length; i++)
        {
            _avatarsController.AddAnimation(animations[i]);
        }

        UpdateUI();
        UpdateAnimatorsValues();
    }
}