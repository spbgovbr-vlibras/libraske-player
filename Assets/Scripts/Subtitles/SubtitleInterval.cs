namespace Lavid.Libraske.Subtitle
{
    internal class TimeConversor
    {
        public static float ToSeconds(int hours, int minutes, float seconds) => (hours * 60 * 60) + (minutes * 60) + seconds;
    }

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
            return TimeConversor.ToSeconds(int.Parse(_[0]), int.Parse(_[1]), int.Parse(_[2]));
        }
    }
}