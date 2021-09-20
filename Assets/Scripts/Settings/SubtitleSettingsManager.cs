using UnityEngine;

[RequireComponent(typeof(SubtitleSettingsView))]
public class SubtitleSettingsManager : MonoBehaviour
{
    [SerializeField] private SubtitleSettingsView _view;

    private void OnEnable()
    {
        _view.OnUIUpdate += OnUIUpdate;
    }

    private void OnUIUpdate()
    {
        SubtitleSettingsSaveHandler.EnableSubtitles(_view.ShowSubtitles());
        SubtitleSettingsSaveHandler.SetSize(_view.GetSize());
        SubtitleSettingsSaveHandler.SetColor(_view.GetColor());
    }

    private void OnDestroy()
    {
        if(_view != null)
            _view.OnUIUpdate -= OnUIUpdate;
    }
}
