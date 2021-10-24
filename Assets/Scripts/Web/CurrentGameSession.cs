public static class CurrentGameSession
{
    public enum Fields
    {
        ID,
        Name,
        Pontuation
    }

    private static GameSessionWebData data;
    private static PontuationWebData pontuation;

    public static string ID { get => data.idGameSession; set => data.idGameSession = value; }
    public static string MusicName { get; set; }

    public static void SetPontuation(PontuationWebData data)
    {
        pontuation = data;
    }

    public static int GetPontuation()
    {
        return pontuation.sessionScore;
    }
}
