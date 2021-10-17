using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float _currentTime;
    private float _maxTime;
    private bool _setup;
    private bool _allowLoop;
    private bool _isFreezed;

    public event Action OnReachTime;

    public void FreezeTime(bool value=true) => _isFreezed = value;

    public void Setup(float time, bool allowLoop)
    {
        _maxTime = time;
        _setup = true;
        _allowLoop = allowLoop;
        _isFreezed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_setup || _isFreezed)
            return;

        _currentTime += Time.deltaTime;

        if (_currentTime >= _maxTime)
        {
            OnReachTime?.Invoke();

            if (_allowLoop)
                _currentTime = 0;
            else
                enabled = false;
        }
    }
}