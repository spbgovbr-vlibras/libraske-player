using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Optional<T>
{
    [SerializeField] private bool _enabled;
    [SerializeField] private T _value;

    public bool IsEnabled => _enabled;
    public T Value => _value;

    public Optional(T value)
    {
        _value = value;
        _enabled = true;
    }
}
