using System.Collections;
using UnityEngine;
using System;

public class WebCamAuthRequester : MonoBehaviour, ILoggable
{
    int _currentAttemp;
    [SerializeField, Min(1)] int _maxAttemps = 3;

    public event Action OnWebcamAllowed;

    public string InLogName => "WebCamAuthRequester";
    public bool IsAuthorized => Application.HasUserAuthorization(UserAuthorization.WebCam);

    IEnumerator Start ()
    {
        while (!IsAuthorized && _currentAttemp < _maxAttemps)
        {
            yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
            _currentAttemp++;
        }     

        if (IsAuthorized)
        {
            Logger.LogSuccess(this, "Usuário permitiu o acesso à webcam.");
            OnWebcamAllowed?.Invoke();
        }
        else
        {
            Logger.LogError(this, "Usuário não permitiu o acesso à webcam");

            if(FindObjectOfType<ErrorSystem>() is ErrorSystem es)
            {
                es.ThrowError(ErrorList.WebcamAuthError);
            }
        }
    }
}