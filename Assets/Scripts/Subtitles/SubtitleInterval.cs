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
            string[] _ = time.Split(':');

            int.TryParse(_[0], out int hours);
            int.TryParse(_[1], out int minutes);
            float.TryParse(_[2], out float ml);

            return TimeConversor.ToSeconds(hours, minutes, ml);
        }
    }
}