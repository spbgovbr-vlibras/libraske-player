using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public struct PontuationWebData
{
    int sessionScore;
    int[] pontuations;
}

public class PontuationController : MonoBehaviour, IPauseObserver, ILoggable
{
    [SerializeField] private GameSession _gameSession;
    [SerializeField, Tooltip("Time between requests")] private float _clockTime = 2;

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
            var webRequest = WebRequest.GetPontuation(_gameSession.Id);
            Logger.Log(this, $"Requisitou pontuação em {WebConstants.FormatPontuationUrl(_gameSession.Id)}");

            yield return webRequest.SendWebRequest();    

            if(webRequest.result == UnityWebRequest.Result.Success)
            {
                string pontuation = webRequest.downloadHandler.text;
                Logger.Log(this, $"Pontuação pega: " + pontuation);
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