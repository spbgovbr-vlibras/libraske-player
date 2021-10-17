using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;

public struct PontuationWebData
{
    public int sessionScore;
    public int[] pontuations;
}

[RequireComponent(typeof(Timer))]
public class PontuationController : MonoBehaviour, IPauseObserver, ILoggable
{
    [SerializeField] private GameSession _gameSession;
    [SerializeField, Tooltip("Time between requests")] private float _clockTime = 2;
    [SerializeField] PontuationFeedback _pontuationFeedback;
    [SerializeField] Timer _timer;

    private bool _gameSessionStarted;

    public string InLogName => "PontuationController";

    private void Awake()
    {
        _gameSession.OnSetupFinished += Enable;

        if (FindObjectOfType<PauseSystem>() is PauseSystem ps)
            ps.AddObserver(this);

        _timer.FreezeTime();
    }

    public void OnDestroy()
    {
        if (_timer != null)
            _timer.OnReachTime -= OnReachTime;

        if (_gameSession != null)
            _gameSession.OnSetupFinished -= Enable;

        if (FindObjectOfType<PauseSystem>() is PauseSystem ps)
            ps.RemoveObserver(this);
    }

    private void Enable()
    {
        _gameSessionStarted = true;
        _timer.OnReachTime += OnReachTime;
        _timer.Setup(_clockTime, true);
    }

    private void OnReachTime()
    {
        StopAllCoroutines();
        StartCoroutine(GetRequestCoroutine());
    }

    IEnumerator GetRequestCoroutine()
    {
        var webRequest = WebRequest.GetPontuation(CurrentGameSession.ID);
        Logger.Log(this, $"Requisitou pontuação em {WebConstants.FormatPontuationUrl(CurrentGameSession.ID)}");

        yield return webRequest.SendWebRequest();    

        if(webRequest.result == UnityWebRequest.Result.Success)
        {
            Logger.Log(this, $"Pontuação pega: " + webRequest.downloadHandler.text);
            var pontuation = JsonUtility.FromJson<PontuationWebData>(webRequest.downloadHandler.text);
            _pontuationFeedback.ProcessPontuation(pontuation);
        }
        else
        {
            Logger.Log(this, webRequest.error);
        }

        Logger.Log(this, $"Next request in {_clockTime}");
        yield return new WaitForSeconds(_clockTime);   
    }

    public void UpdatePauseStatus(bool isPaused)
    {
        if (isPaused)
            _timer.FreezeTime(true);
        else if (_gameSessionStarted)
            _timer.FreezeTime(false);
    }
}