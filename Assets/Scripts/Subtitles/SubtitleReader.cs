using Lavid.Libraske.Subtitles;
using UnityEngine;

public class SubtitleReader : MonoBehaviour
{
    [SerializeField] private AudioHandler _audio;
    [SerializeField] private SubtitleHUD _subtitleHUD;

    private double _timeCurrent;  
    private bool _setup;
    private bool _isDisplayingText;

    private SubtitleLine _nextLine;
    private Subtitle _subs;

    public void ReadSubtitle(Subtitle subtitle)
    {
        _subs = subtitle;
        CanStartReading = true;
    }

    private bool CanStartReading { get; set; }

    private void Awake() => _subtitleHUD.ResetText();

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
            _subtitleHUD.ResetText();
        }            
        else if(_timeCurrent >= nextLineInterval.GetEnterTime() && !_isDisplayingText)
        {
            string nextLine = _nextLine.GetText();
            _subtitleHUD.ApplyText(nextLine);
            _isDisplayingText = true;
        }
    }
}