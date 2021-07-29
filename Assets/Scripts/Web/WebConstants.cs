using System.Collections.Generic;

public static class WebConstants
{
    public enum URL 
    {
        BaseURL,
        SongsURL,
        CreateSessionURL,
        PontuationURL
    }

    // Game session
    public static string SongIdField = "idSongId";
    public static string UserIdField = "idUser";

    // Sending frames
    public static string FrameField = "frame";
    public static string FrameIdField = "idFrame";

    private static Dictionary<URL, string> UrlDictionary;

    private static void SetupDictionary()
    {
        UrlDictionary = new Dictionary<URL, string>();

        //UrlDictionary.Add(URL.BaseURL, "http://localhost:3333");
        UrlDictionary.Add(URL.BaseURL, "https://libraske-back-dth.vlibras.gov.br");
        UrlDictionary.Add(URL.SongsURL, UrlDictionary[URL.BaseURL] + "/libraske/songs");
        UrlDictionary.Add(URL.CreateSessionURL, UrlDictionary[URL.BaseURL] + "/libraske/game/pontuation/session");
        UrlDictionary.Add(URL.PontuationURL, UrlDictionary[URL.BaseURL] + "/libraske/game/pontuation/session");
    }

    public static string GetString(URL url)
    {
        if (UrlDictionary == null)
            SetupDictionary();

        return UrlDictionary[url];
    }
}