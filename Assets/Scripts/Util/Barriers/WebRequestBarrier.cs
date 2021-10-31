using Lavid.Libraske.DataStruct;
using System;
using UnityEngine;


public class WebRequestBarrier : MonoBehaviour, IBarrier
{
    [SerializeField] private Wrapper<WebRequest> _requests;

    private bool _isUnlocked;

    public bool IsUnlocked { get => _isUnlocked; private set => _isUnlocked = value; }

    public event Action OnUnlockBarrier;


    private void Awake()
    {
        for (int i = 0; i < _requests.Length; i++)
        {
            _requests[i].OnSuccess += TryUnlock;
        }
    }

    private void OnDestroy()
    {
        if (_requests == null)
            return;

        for (int i = 0; i < _requests.Length; i++)
        {
            if(_requests[i] != null)
                _requests[i].OnSuccess -= TryUnlock;
        }
    }

    public void TryUnlock()
    {
        if (!IsUnlocked && ShouldUnlock())
        {
            OnUnlockBarrier?.Invoke();
            IsUnlocked = true;
        }
    }

    public bool ShouldUnlock()
    {
        for(int i = 0; i < _requests.Length; i++)
        {
            if (!_requests[i].RequestWasSuccess)
                return false;
        }

        return true;
    }
}