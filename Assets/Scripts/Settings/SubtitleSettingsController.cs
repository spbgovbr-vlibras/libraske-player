using UnityEngine;

[RequireComponent(typeof(SubtitleSettingsView))]
[RequireComponent(typeof(SubtitleSettingsModel))]
public class SubtitleSettingsController : MonoBehaviour
{
    [SerializeField] private SubtitleSettingsModel _model;
    [SerializeField] private SubtitleSettingsView _view;

    void Start()
    {
        if (!SubtitleSettingsSaveHandler.HasSavedSettings())
            SubtitleSettingsSaveHandler.ResetSettings();

        SubtitleSettingsSaveHandler.AllowSaving();

        _model.SelectValues(
                              SubtitleSettingsSaveHandler.CanShowSubtitles(),
                              (int)SubtitleSettingsSaveHandler.GetSize(),
                              (int)SubtitleSettingsSaveHandler.GetColor()
                            );
        UpdateView();
    }

    public void UpdateView()
    {
        _view.UpdateRender(_model.ShowSubtitlesPreview().Value, _model.GetPreviewSize(), _model.GetPreviewColor());
    }

    /// <summary> Called on canvas to save data on file. /// </summary>
    public void SaveData()
    {
        SubtitleSettingsSaveHandler.EnableSubtitles(_model.ShowSubtitlesPreview());
        SubtitleSettingsSaveHandler.SetSize(_model.GetPreviewSize());
        SubtitleSettingsSaveHandler.SetColor(_model.GetPreviewColor());
    }
}