using Lavid.Libraske.Web;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class SendFrameRequest : MonoBehaviour, ILoggable, IPauseObserver
{
    public string InLogName => "SendFrameRequest";

    [SerializeField] private WebCamHandler _webcam;
    [SerializeField] private GameSession _gameSession;
    [SerializeField, Tooltip("Time between requests")] private float _clockTime = 2;
    private bool _gameSessionStarted;


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
        StartCoroutine(SendFrameCoroutine());
    }

    private int _currentRequest;
    private int _idSession = 10;

    IEnumerator SendFrameCoroutine()
    {
        while (true)
        {
            Logger.Log(this, "Solicitou requisição");

            var image = _webcam.GetImageInBytes();

            var www = WebRequest.SendFrame(_currentRequest, image, _idSession.ToString(), "/" + AccessData.AccessToken);

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                _currentRequest++;
                Logger.Log(this, "Form upload complete!");
            }
            else
            {
                Logger.Log(this, www.error);

                if (FindObjectOfType<ErrorSystem>() is ErrorSystem es)
                    es.ThrowError(new InGameError(www.error));
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
            StartCoroutine(SendFrameCoroutine());
    }
}