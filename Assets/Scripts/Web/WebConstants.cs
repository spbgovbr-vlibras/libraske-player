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

    private static Dictionary<URL, string> UrlDictionary;

    private static void SetupDictionary()
    {
        UrlDictionary = new Dictionary<URL, string>();

        UrlDictionary.Add(URL.BaseURL, "http://localhost:3333");
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