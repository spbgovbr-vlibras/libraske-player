using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontuationFeedback : MonoBehaviour, ILoggable
{
    private const string GoodPontuation = "GoodPontuation";
    private const string BadPontuation = "BadPontuation";

    [SerializeField] Animator _anim;

    public string InLogName => "PontuationFeedback";

    public void ProcessPontuation(PontuationWebData pontuation)
    {
        //Logger.Log(this, pontuation.pontuations);
        //Logger.Log(this, pontuation.sessionScore);

        if(pontuation.pontuations != null && pontuation.pontuations.Length > 0)
        {
            int last = pontuation.pontuations.Length - 1;
            int currentValue = pontuation.pontuations[last];
            Logger.Log(this, "got " + currentValue);

            if (currentValue >= 40)
                _anim.Play(GoodPontuation);
            else
                _anim.Play(BadPontuation);
        }
    }
}