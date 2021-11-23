using System;
using UnityEngine;

public class AuthorizeWebcamBarrier : MonoBehaviour, IBarrier
{
    [SerializeField] WebCamAuthRequester _request;

    private bool _isUnlocked;
    public bool IsUnlocked { get => _isUnlocked; private set => _isUnlocked = value; }

    public event Action OnUnlockBarrier;

    private void Awake()
    {
        if(_request != null)
            _request.OnWebcamAllowed += TryUnlock;
    }

    private void OnDestroy() 
    {
        if(_request != null)
            _request.OnWebcamAllowed -= TryUnlock;
    }

    public bool ShouldUnlock()
    {
        return _request.IsAuthorized;
    }

    public void TryUnlock()
    {
        if (!IsUnlocked && ShouldUnlock())
        {
            OnUnlockBarrier?.Invoke();
            IsUnlocked = true;
        }
    }
}
