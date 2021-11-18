using System.Collections.Generic;

public static class WebConstants
{
    public enum URL 
    {
        BaseURL,
        SongsURL,
        UsersURL,
        CreateSessionURL,
        PontuationURL,
        SendFrame,
        FakeLogin,
        CloseSessionURL,

        PersonalizationsColors,
        PersonalizationsGroups,

        SongStoreURL,
        BuyColorSet
    }

    // Game session
    public static readonly string SongIdField = "idSongId";
    public static readonly string UserIdField = "idUser";

    // Sending frames
    public static readonly string FrameField = "frame";
    public static readonly string FrameIdField = "idFrame";

    // Request pontuation
    public static readonly string PontuationTab = "pontuation";

    private static Dictionary<URL, string> UrlDictionary;

    private static void SetupDictionary()
    {
        UrlDictionary = new Dictionary<URL, string>();

        //UrlDictionary.Add(URL.BaseURL, "https://libraske-back-dth.vlibras.gov.br");
        //UrlDictionary.Add(URL.BaseURL, "http://localhost:8080");
        UrlDictionary.Add(URL.BaseURL, "http://150.165.204.122:4000");
		
        UrlDictionary.Add(URL.SongsURL, UrlDictionary[URL.BaseURL] + "/libraske/songs");
        UrlDictionary.Add(URL.UsersURL, UrlDictionary[URL.BaseURL] + "/libraske/users");
        UrlDictionary.Add(URL.CreateSessionURL, UrlDictionary[URL.BaseURL] + "/libraske/game/pontuation/session");
        UrlDictionary.Add(URL.PontuationURL, UrlDictionary[URL.BaseURL] + "/libraske/game");
        UrlDictionary.Add(URL.SendFrame, UrlDictionary[URL.BaseURL] + "/libraske/game/frame");
        UrlDictionary.Add(URL.FakeLogin, UrlDictionary[URL.BaseURL] + "/libraske/auth/fake-login");
        UrlDictionary.Add(URL.CloseSessionURL, UrlDictionary[URL.BaseURL] + "/libraske/game/pontuation/session");

        UrlDictionary.Add(URL.PersonalizationsColors, UrlDictionary[URL.BaseURL] + "/libraske/personalizations-color");
        UrlDictionary.Add(URL.PersonalizationsGroups, UrlDictionary[URL.BaseURL] + "/libraske/personalizations-group");

        UrlDictionary.Add(URL.SongStoreURL, UrlDictionary[URL.BaseURL] + "/libraske/store/song/");
        UrlDictionary.Add(URL.BuyColorSet, UrlDictionary[URL.BaseURL] + "/libraske/store/personalizations-group");
    }

    public static string FormatPersonalizationColorUrl(CustomizationGroups.Groups group)
    {
        if (UrlDictionary == null)
            SetupDictionary();

        return UrlDictionary[URL.PersonalizationsColors] + $"/personalization/{CustomizationGroups.ToUrlSection(group)}";
    }

    public static string FormatPontuationUrl(string gameSessionId)
    {
        if (UrlDictionary == null)
            SetupDictionary();

        return UrlDictionary[URL.PontuationURL] + $"/{gameSessionId}/{PontuationTab}";
    }

    public static string GetURLFrom(URL url)
    {
        if (UrlDictionary == null)
            SetupDictionary();

        return UrlDictionary[url];
    }
}