using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using System;

public struct PontuationWebData
{
    public int sessionScore;
    public int[] pontuations;
}

public class PontuationController : MonoBehaviour, IPauseObserver, ILoggable
{
    [SerializeField] private GameSession _gameSession;
    [SerializeField, Tooltip("Time between requests")] private float _clockTime = 2;
    [SerializeField] PontuationFeedback _pontuationFeedback;

    private bool _gameSessionStarted;

    public string InLogName => "PontuationController";

    private void Awake()
    {
        _gameSession.OnSetupFinished += Enable;

        if (FindObjectOfType<PauseSystem>() is PauseSystem ps)
            ps.AddObserver(this);
    }

    public void OnDestroy()
    {
        StopAllCoroutines();

        if (_gameSession != null)
            _gameSession.OnSetupFinished -= Enable;

        if (FindObjectOfType<PauseSystem>() is PauseSystem ps)
            ps.RemoveObserver(this);
    }

    private void Enable()
    {
        _gameSessionStarted = true;
        StartCoroutine(GetRequestCoroutine());
    }

    IEnumerator GetRequestCoroutine()
    {
        while (true)
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
    }

    public void UpdatePauseStatus(bool isPaused)
    {
        if (isPaused)
            StopAllCoroutines();
        else if (_gameSessionStarted && gameObject.activeInHierarchy)
            StartCoroutine(GetRequestCoroutine());
    }
}