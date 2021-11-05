using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public abstract class WebRequest : MonoBehaviour, ILoggable
{
    #region Events
    public event Action OnSuccess;
    public event Action OnError;

    /// <summary> To be called after handle the request, notifying the subscribers about the value. </summary>
    protected void InvokeOnSuccessEvent() => OnSuccess?.Invoke();
    /// <summary> To be called after handle the request, notifying the subscribers about the value. </summary>
    protected void InvokeOnErrorEvent() => OnError?.Invoke();
    #endregion

    #region Prints
    /// <summary> Name that appears in Log. </summary>
    public abstract string GetLogName();
    public string InLogName => GetLogName();

    /// <summary> Text to print if the request was a success. </summary>
    protected virtual string SuccessText(UnityWebRequest request) => "Request was success in " + request.url;

    /// <summary> Text to print if the request has failed. </summary>
    protected virtual string FailText(UnityWebRequest request)
    {
        string msg = "Request Failed in " + request.url;
        msg += " " + request.error;
        msg += request.downloadHandler.error ?? "";
        return msg;
    }

    /// <summary> Print success request text with a prebuilt text style. </summary>
    protected void PrintSuccessText(UnityWebRequest request) => Logger.LogSuccess(this, SuccessText(request));

    /// <summary> Print failed request text with a prebuilt text style. </summary>
    protected void PrintFailText(UnityWebRequest request) => Logger.LogError(this, FailText(request));
    #endregion

    #region Request
    [SerializeField] protected Optional<WebRequestResender> _requestResender;

    protected bool _requestWasSuccess;
    public bool RequestWasSuccess { get => _requestWasSuccess; }

    /// <summary>
    /// Resend request with an amount of times setted by the user. If the WebRequest fails more times than allowed
    /// the method OnRequestError is called.
    /// </summary>
    protected void TryResendFailedRequest(UnityWebRequest request)
    {
        bool shouldResendRequest = _requestResender.IsEnabled
                                   && _requestResender.Value.ShouldResendRequest();

        if (shouldResendRequest)
            _requestResender.Value.ResendRequest(request);
        else
            OnRequestError(request);
    }

    /// <summary> Called if the request was a success.</summary>
    protected abstract void OnRequestSuccess(UnityWebRequest request);

    /// <summary> Called if the request has failed and can not resend the request anymore by WebRequestResender class.</summary>
    protected abstract void OnRequestError(UnityWebRequest request);

    /// <summary> Check if Request has failed. Case true, try to resend. Case false, calls OnRequestSuccess. </summary>
    protected virtual void VerifyRequest(UnityWebRequest request)
    {
        if (request.result == UnityWebRequest.Result.Success)
            OnRequestSuccess(request);
        else
            TryResendFailedRequest(request);
    }

    /// <summary> Abstract method to send request and verify the reponse  to handle it. </summary>
    public abstract IEnumerator SendRequest();
    #endregion
}