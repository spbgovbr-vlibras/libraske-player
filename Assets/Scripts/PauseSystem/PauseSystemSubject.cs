using Lavid.Libraske.DataStruct;
using UnityEngine;

public abstract class PauseSystemSubject : MonoBehaviour
{
    private Wrapper<IPauseObserver> _observers;

    public void AddObserver(IPauseObserver observer)
    {
        if (_observers == null)
            _observers = new Wrapper<IPauseObserver>();

        if (!_observers.Contains(observer))
            _observers.Add(observer);
    }   

    public void RemoveObserver(IPauseObserver observer)
    {
        if (_observers != null)
            _observers.Remove(observer);
    }

    public void NotifyObservers(bool newValue)
    {
        if (_observers == null)
            return;

        for(int i = 0; i < _observers.Length; i++)
            _observers[i].UpdatePauseStatus(newValue);
    }
}