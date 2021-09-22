using Lavid.Libraske.UI;
using UnityEngine;


public class SubtitleSettingsView : MonoBehaviour
{
    [SerializeField] private GameObject _subtitlePanelContainer;
    [SerializeField] private RectTransform _subtitleBarPreview;
    [SerializeField] TextUI _subtitleTextPreview;

    private enum SubtitleFontSize
    {
        Low = 14,
        Middle = 20,
        High = 26
    }

    private static Vector2 LowSubtitleRect = new Vector2(391, 26.11f);
    private static Vector2 MiddleSubtitleRect = new Vector2(569, 38);
    private static Vector2 HighSubtitleRect = new Vector2(718.74f, 48);

    public void UpdateRender
    (
        bool showSubtitles,
        SubtitleSettingsSaveHandler.Size size,
        SubtitleSettingsSaveHandler.Color color
    )
    {
        _subtitlePanelContainer.SetActive(showSubtitles);
        SetSubtitlePreview(size, color);
    }

    private void SetSubtitlePreview(SubtitleSettingsSaveHandler.Size size, SubtitleSettingsSaveHandler.Color color)
    {
        SubtitleFontSize m_fontSize = 0;
        Vector2 m_rectSize = LowSubtitleRect;
        Color m_color = Color.white;

        switch (size)
        {
            case SubtitleSettingsSaveHandler.Size.Small:
                m_rectSize = LowSubtitleRect;
                m_fontSize = SubtitleFontSize.Low;
                break;
            case SubtitleSettingsSaveHandler.Size.Regular:
                m_rectSize = MiddleSubtitleRect;
                m_fontSize = SubtitleFontSize.Middle;
                break;
            case SubtitleSettingsSaveHandler.Size.Big:
                m_rectSize = HighSubtitleRect;
                m_fontSize = SubtitleFontSize.High;
                break;
        }

        switch (color)
        {
            case SubtitleSettingsSaveHandler.Color.White:
                m_color = Color.white;
                break;
            case SubtitleSettingsSaveHandler.Color.Yellow:
                m_color = Color.yellow;
                break;
        }

        _subtitleBarPreview.sizeDelta = m_rectSize;
        _subtitleTextPreview.SetFontSize((int)m_fontSize);
        _subtitleTextPreview.SetColor(m_color);
    }
}