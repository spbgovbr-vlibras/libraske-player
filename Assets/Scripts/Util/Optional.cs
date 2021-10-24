using UnityEngine;

[System.Serializable]
public struct Optional<T>
{
    [SerializeField] private bool _enabled;
    [SerializeField] private T _value;

    public bool IsEnabled => _enabled;
    public T Value => _value;

    public void DiscardValue()
    {
        _value = default;
        _enabled = false;
    }

    public Optional(T value)
    {
        _value = value;
        _enabled = true;
    }
}
