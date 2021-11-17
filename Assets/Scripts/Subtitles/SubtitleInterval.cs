using Lavid.Libraske.Util;

namespace Lavid.Libraske.Subtitles
{

    [System.Serializable]
    public class SubtitleInterval
    {
        private float _timeWhenEnter;
        private float _timeWhenExit;

        public float GetEnterTime() => _timeWhenEnter;
        public float GetExitTime() => _timeWhenExit;

        public SubtitleInterval(string time)
        {
            string[] interval = time.Trim().Split('#');

            _timeWhenEnter = GetInSeconds(interval[0]);
            _timeWhenExit = GetInSeconds(interval[1]);
        }

        private float GetInSeconds(string time)
        {
            string[] _ = time.Split(":".ToCharArray());

            _[0] = SubtitleStringFilter.ToNumberString(_[0]);
            _[1] = SubtitleStringFilter.ToNumberString(_[1]);
            _[2] = SubtitleStringFilter.ToNumberString(_[2]);

            int hours = int.Parse(_[0], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            int minutes = int.Parse(_[1], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            float ml = float.Parse(_[2], System.Globalization.CultureInfo.InvariantCulture.NumberFormat);

            return TimeConversor.ToSeconds(hours, minutes, ml);
        }
    }
}