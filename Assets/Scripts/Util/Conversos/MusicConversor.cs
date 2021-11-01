using Lavid.Libraske.DataStruct;
using Lavid.Libraske.Json;
using UnityEngine.Networking;

public static class MusicConversor
{
    private const string CastErrorMessage = "Failed to cast Music to Wrapper";

    public static Wrapper<Music> FromRequestToMusicWrapper(UnityWebRequest request)
    {
        Wrapper<Music> musics;

        try
        {
            musics = FromStringToMusicWrapper(request.downloadHandler.text);
        }
        catch
        {
            throw new System.Exception(CastErrorMessage);
        }

        return musics; 
    }

    public static Wrapper<Music> FromStringToMusicWrapper(string data) => JsonArray.FromJson<Music>(data);
}