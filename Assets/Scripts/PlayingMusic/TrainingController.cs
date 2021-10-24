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

        //string[] url = new string[5];
        //url[0] = "https://dicionario2.vlibras.gov.br/2018.3.1/ANDROID/" + "1S_AVISAR_3P"; 
        //url[1] = "https://dicionario2.vlibras.gov.br/2018.3.1/ANDROID/" + "1S_ACONSELHAR_2P";
        //url[2] = "https://dicionario2.vlibras.gov.br/2018.3.1/ANDROID/" + "1S_PEDIR_3P";
        //url[3] = "https://dicionario2.vlibras.gov.br/2018.3.1/ANDROID/" + "1S_CHOCAR_1S";
        //url[4] = "https://dicionario2.vlibras.gov.br/2018.3.1/ANDROID/" + "1S_ENGANAR_1S";

        for (int i = 0; i < TrainingSteps; i++)
        {
            yield return StartCoroutine(_bundleRequest.SendRequest(music.GetTrainingURL(i)));
            clip = _bundleRequest.TryGetFirstClip(_bundleRequest.GetLastRequest());
            _avatarAnimators.AddClip(clip);
        }

        UpdateUI();
        UpdateAnimatorsValues();
    }
}