using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequestResender : MonoBehaviour
{
    [SerializeField, Tooltip("Max erros allowed"), Range(1, 10)] int _maxRequestsToSend = 3;
    [SerializeField] WebRequest _request;

    private readonly Color MessageColor = new Color(255, 69, 0);

    private int _requestsSentQuantity;
    public bool ShouldResendRequest() => _requestsSentQuantity <= _maxRequestsToSend -1;

    public void ResendRequest(UnityWebRequest request) => StartCoroutine(ResendRequestCouroutine(request.url));

    private IEnumerator ResendRequestCouroutine(string url)
    {
        _requestsSentQuantity++;

        Logger.LogWithColor(_request,
                            $"Resending request at {url}. Attemp: {_requestsSentQuantity}",
                            MessageColor);

        yield return StartCoroutine(_request.SendRequest());
    }
}