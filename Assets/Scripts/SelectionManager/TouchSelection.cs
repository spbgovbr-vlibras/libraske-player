using Lavid.Libraske.Interfaces;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class TouchSelection : MonoBehaviour, ITouchComponent
{
    [Header("Events")]
    [SerializeField] private UnityEvent _onClick;
    [SerializeField] private UnityEvent _onPointerDown;
    [SerializeField] private UnityEvent _onEnter;
    [SerializeField] private UnityEvent _onExit;

    [Header("Sounds"), Space(2)]
    [SerializeField] private AudioClip _soundOnClick;
    [SerializeField] private AudioClip _soundOnPointerDown;
    [SerializeField] private AudioClip _soundOnEnter;
    [SerializeField] private AudioClip _soundOnExit;
    [SerializeField] private SoundFxController _audioController;


    public void OnPointerClick(PointerEventData eventData)
    {
        _onClick?.Invoke();
        PlaySoundFx(_soundOnClick);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _onPointerDown?.Invoke();
        PlaySoundFx(_soundOnPointerDown);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _onEnter?.Invoke();
        PlaySoundFx(_soundOnEnter);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _onExit?.Invoke();
        PlaySoundFx(_soundOnExit);
    }

    private void PlaySoundFx(AudioClip audioClip)
    {
        if (audioClip == null || _audioController == null)
            return;

        _audioController.PlaySoundFx(audioClip);
    }
}