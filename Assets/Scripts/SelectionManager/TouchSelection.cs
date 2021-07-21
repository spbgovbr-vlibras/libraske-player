using Lavid.Libraske.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TouchSelection : MonoBehaviour, ITouchComponent
{
    [SerializeField] private UnityEvent _onClick;
    [SerializeField] private UnityEvent _onEnter;
    [SerializeField] private UnityEvent _onExit;

    public void OnPointerClick(PointerEventData eventData) => _onClick?.Invoke();
    public void OnPointerEnter(PointerEventData eventData) => _onEnter?.Invoke();
    public void OnPointerExit(PointerEventData eventData) => _onExit?.Invoke();
}