using Lavid.Libraske.Web;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Timer))]
public class SendFrameRequest : MonoBehaviour, ILoggable, IPauseObserver
{
    public string InLogName => "SendFrameRequest";

    [SerializeField] private WebCamHandler _webcam;
    [SerializeField] private CreateGameSessionRequest _gameSession;
    [SerializeField, Tooltip("Time between requests")] private float _clockTime = 2;
    [SerializeField] Timer _timer;
    private bool _gameSessionStarted;

    private void Awake()
    {
        if(_gameSession != null)
            _gameSession.OnSetupFinished += Enable;

        if (FindObjectOfType<PauseSystem>() is PauseSystem ps)
            ps.AddObserver(this);

        _timer.FreezeTime();
    }
    public void OnDestroy()
    {
        StopAllCoroutines();

        if (_gameSession != null)
            _gameSession.OnSetupFinished -= Enable;

        if (FindObjectOfType<PauseSystem>() is PauseSystem ps)
            ps.RemoveObserver(this);

        if (_timer != null)
            _timer.OnReachTime -= OnReachTime;
    }

    private void Enable()
    {
        _gameSessionStarted = true;
        _timer.OnReachTime += OnReachTime;
        _timer.Setup(_clockTime, true);
    }

    private int _currentRequest;
    private int _idSession = 10;
    private bool _isSendingFrame;

    private void OnReachTime()
    {
        if (_isSendingFrame)
            return;

        StartCoroutine(SendFrameCoroutine());
    }

    IEnumerator SendFrameCoroutine()
    {
		_isSendingFrame = true;
        Logger.Log(this, "Solicitou requisição");

        byte[] image = _webcam.GetImageInBytes(); // TODO: Fix Dispose Error

		if(image != null)
		{
			var www = WebRequestFormater.SendFrame(_currentRequest, image, _idSession.ToString(), "/" + AccessData.AccessToken);

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

			www.Dispose();
		}

        _isSendingFrame = false;
    }

    public void UpdatePauseStatus(bool isPaused)
    {
        if (isPaused)
            _timer.FreezeTime(true);
        else if (_gameSessionStarted)
            _timer.FreezeTime(false);
    }
}