using UnityEngine;

public class PontuationFeedback : MonoBehaviour, ILoggable
{
    private const string GoodPontuation = "GoodPontuation";
    private const string BadPontuation = "BadPontuation";
    private const int GoodFeedbackMinValue = 30;

    [SerializeField] Animator _anim;

    public string InLogName => "PontuationFeedback";

    public void ProcessPontuation(PontuationWebData pontuation)
    {
        Logger.Log(this, "Session score " + pontuation.sessionScore);

        if(pontuation.pontuations != null && pontuation.pontuations.Length > 0)
        {
            int last = pontuation.pontuations.Length - 1;
            int currentValue = pontuation.pontuations[last];
            Logger.Log(this, "Last pontuation got " + currentValue);

            string animToPlay = currentValue >= GoodFeedbackMinValue ? GoodPontuation : BadPontuation;
            _anim.Play(animToPlay);
        }
    }
}