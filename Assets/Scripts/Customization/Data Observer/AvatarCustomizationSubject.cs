using Lavid.Libraske.DataStruct;
using UnityEngine;

public abstract class AvatarCustomizationSubject : ScriptableObject
{
    private Wrapper<IAvatarCustomizationObserver> _observers;

    public void NotifyUpdateToObservers()
    {
        if (_observers == null)
            return;

        for (int i = 0; i < _observers.Length; i++)
            _observers[i].OnCustomizationUpdate();
    }

    public void AddObserver(IAvatarCustomizationObserver observer)
    {
        if (_observers == null)
            _observers = new Wrapper<IAvatarCustomizationObserver>();

        if (!_observers.Contains(observer))
            _observers.Add(observer);
    }

    public void RemoveObserver(IAvatarCustomizationObserver observer)
    {
        if (_observers == null)
            return;

        if (_observers.Contains(observer))
            _observers.Remove(observer);
    }
}