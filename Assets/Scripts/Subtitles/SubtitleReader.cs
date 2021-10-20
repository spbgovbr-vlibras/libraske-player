using Lavid.Libraske.Subtitle;
using Lavid.Libraske.UI;
using UnityEngine;

public class SubtitleReader : MonoBehaviour
{
    [SerializeField] private AudioHandler _audio;
    [SerializeField] private SubtitleBar _subtitleBar;
    [SerializeField] private TextUI _text;

    private double _timeCurrent;  
    private bool _setup;
    private bool _isDisplayingText;

    private SubtitleLine _nextLine;
    private Subtitle _subs;

    public void StartReading(Subtitle subtitle)
    {
        _subs = subtitle;
        CanStartReading = true;
    }

    private bool CanStartReading { get; set; }

    private void Awake()
    {
        _text.ResetText();
    }

    private void Update()
    {
        if (!CanStartReading || !_subs.HasNextLine())
            return;

        if (!_setup)
        {
            _nextLine = _subs.GetNextLine();
            _isDisplayingText = false;
            _setup = true;
        }

        _timeCurrent = _audio.CurrentTime;

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