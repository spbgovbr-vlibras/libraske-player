using Lavid.Libraske.Subtitle;
using Lavid.Libraske.UI;
using UnityEngine;
using UnityEngine.Video;

public class SubtitleReader : MonoBehaviour
{
    [SerializeField] private VideoPlayer _video;
    [SerializeField] private Subtitle _subs;
    [SerializeField] private SubtitleBar _subtitleBar;
    [SerializeField] private TextUI _text;

    private double _timeCurrent;  
    private bool _setup;
    private bool _isDisplayingText;

    private SubtitleLine _nextLine;

    private void Start()
    {
        _text.ResetText();
        _nextLine = null;
    }

    private void Update()
    {
        if (!_setup && !_subs.HasNextLine())
            return;

        if (!_setup)
        {
            _nextLine = _subs.GetNextLine();
            _isDisplayingText = false;
            _setup = true;
        }

        _timeCurrent = _video.time;

        var nextLineInterval = _nextLine.GetInterval();

        if(_timeCurrent >= nextLineInterval.GetExitTime())
        {
            _setup = false;
            _text.ResetText();
            _subtitleBar.Disable();
        }            
        else if(_timeCurrent >= nextLineInterval.GetEnterTime() && !_isDisplayingText)
        {
            string nextLine = _nextLine.GetText();
            _text.SetText(nextLine);
            _subtitleBar.SetSize(nextLine);
            _isDisplayingText = true;
        }
    }
}