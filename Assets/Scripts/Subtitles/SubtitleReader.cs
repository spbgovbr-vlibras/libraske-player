using Lavid.Libraske.Subtitle;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleReader : MonoBehaviour
{
    [SerializeField] private Subtitle _subs;
    [SerializeField] private SubtitleLine _nextLine;
    [SerializeField] private Text _text;

    private float _timeCurrent;  
    private bool _setup;
    private bool _isDisplayingText;

    private void Start()
    {
        _text.text = "";
        _nextLine = null;
    }

    private void Update()
    {
        if (!_subs.HasNextLine())
            return;

        if (!_setup)
        {
            _nextLine = _subs.GetNextLine();
            _isDisplayingText = false;
            _setup = true;
        }

        _timeCurrent += Time.deltaTime;

        var nextLineInterval = _nextLine.GetInterval();

        if(_timeCurrent >= nextLineInterval.GetExitTime())
        {
            _setup = false;
            _text.text = "";
        }            
        else if(_timeCurrent >= nextLineInterval.GetEnterTime() && !_isDisplayingText)
        {
            _text.text = _nextLine.GetText();
            _isDisplayingText = true;
        }
    }
}