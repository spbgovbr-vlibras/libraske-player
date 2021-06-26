using System.Collections.Generic;
using UnityEngine;

public class SelectionSubject : MonoBehaviour
{
    List<ISelectionObserver> _observers = new List<ISelectionObserver>();

    public void AddObserver(ISelectionObserver observer) => _observers.Add(observer);
    public void RemoveObserver(ISelectionObserver observer) => _observers.Remove(observer);

    public void NotifyObservers(int newValue)
    {
        foreach (var observer in _observers)
            observer.UpdateSelectionValue(newValue);
    }
}
