namespace Lavid.Libraske.Util
{
    public class TimeConversor
    {
        public static float ToSeconds(int hours, int minutes, float seconds) => (hours * 60 * 60) + (minutes * 60) + seconds;
    }
}