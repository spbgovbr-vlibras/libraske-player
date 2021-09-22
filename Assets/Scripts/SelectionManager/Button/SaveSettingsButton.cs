using Lavid.Libraske.Touch;
using UnityEngine;
using UnityEngine.EventSystems;

public class SaveSettingsButton : TouchButton
{
    [SerializeField] GameObject _inactive;
    [SerializeField] GameObject _imageWhenEnter;
    [SerializeField] GameObject _imageWhenExit;

    bool _hasUnsavedChanges;

    public override void OnPointerEnter(PointerEventData eventData)
    {
        if (_hasUnsavedChanges)
        {
            base.OnPointerEnter(eventData);
            _imageWhenEnter.SetActive(true);
            _imageWhenExit.SetActive(false);
        }
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        if (_hasUnsavedChanges)
        {
            base.OnPointerExit(eventData);
            _imageWhenEnter.SetActive(false);
            _imageWhenExit.SetActive(true);
        }
    }

    private void Start() => HasUnsavedChanges(false);

    public void HasUnsavedChanges(bool value)
    {
        _hasUnsavedChanges = value;
        _inactive.SetActive(!value);
        _imageWhenEnter.SetActive(false);
        _imageWhenExit.SetActive(value);
    }
}
