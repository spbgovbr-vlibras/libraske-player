namespace Lavid.Libraske.Subtitle
{
    public class SubtitleLine
    {
        private SubtitleInterval _interval;
        private string _text;

        public SubtitleLine(SubtitleInterval interval, string text)
        {
            _interval = interval;
            _text = text;
        }

        public SubtitleInterval GetInterval() => _interval;
        public string GetText() => _text;
        public void SetText(string value) => _text = value;
    }
}