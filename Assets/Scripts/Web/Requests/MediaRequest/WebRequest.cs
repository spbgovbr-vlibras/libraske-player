using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public abstract class WebRequest : MonoBehaviour, ILoggable
{
    #region Events
    public event Action OnSuccess;
    public event Action OnError;

    protected void InvokeOnSuccessEvent() => OnSuccess?.Invoke();
    protected void InvokeOnErrorEvent() => OnError?.Invoke();
    #endregion

    #region Prints
    public abstract string GetLogName();
    public string InLogName => GetLogName();
    protected virtual string SuccessText(UnityWebRequest request) => "Request was success in " + request.url;
    protected virtual string FailText(UnityWebRequest request)
    {
        string msg = "Request Failed in " + request.url;
        msg += " " + request.error;
        msg += request.downloadHandler.error ?? "";
        return msg;
    }
    protected void PrintSuccessText(UnityWebRequest request) => Logger.LogSuccess(this, SuccessText(request));
    protected void PrintFailText(UnityWebRequest request) => Logger.LogError(this, FailText(request));
    #endregion

    #region Request
    protected bool _requestWasSuccess;
    public bool RequestWasSuccess { get => _requestWasSuccess; }

    protected abstract void OnRequestSuccess(UnityWebRequest request);
    protected abstract void OnRequestError(UnityWebRequest request);

    protected virtual void VerifyRequest(UnityWebRequest request)
    {
        if (request.result == UnityWebRequest.Result.Success)
            OnRequestSuccess(request);
        else
            OnRequestError(request);
    }

    protected abstract IEnumerator SendRequest();
    #endregion
}