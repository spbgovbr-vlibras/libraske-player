using Lavid.Libraske.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TouchSelection : MonoBehaviour, ITouchComponent
{
    [SerializeField] private Animator _anim;
    [SerializeField] private UnityEvent _onClick;
    [SerializeField] private UnityEvent _onEnter;
    [SerializeField] private UnityEvent _onExit;

    private const string AnimIsDown = "isDown";
    private const string AnimOnPress = "isPressed";

    public void OnPointerClick(PointerEventData eventData)
    {
        if(_anim != null)
            _anim.SetTrigger(AnimOnPress);

        _onClick?.Invoke();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_anim != null)
            _anim.SetBool(AnimIsDown, true);

        _onEnter?.Invoke();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (_anim != null)
            _anim.SetBool(AnimIsDown, false);

        _onExit?.Invoke();
    }
}