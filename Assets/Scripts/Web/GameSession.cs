using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
internal struct MusicWebData
{
    public string idSong;
}

[Serializable]
internal struct GameSessionWebData 
{
    public string idGameSession;
}

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


public class GameSession : MonoBehaviour, ILoggable
{
    [SerializeField] private MusicHolderSO _musicHolder;

    public event Action OnSetupFinished;
    private MusicWebData _song;

    public string SongId { get => _song.idSong; }
    public string InLogName { get => "GameSession"; }

    private void Start()
    {
        StopAllCoroutines();
        StartCoroutine(CreateSessionCoroutine());
    }

    IEnumerator CreateSessionCoroutine()
    {
        Logger.Log(this, "Solicitou requisição");

        _song.idSong = _musicHolder.GetMusicID();
        string songJson = JsonUtility.ToJson(_song);

        var request = WebRequest.Post(WebConstants.URL.CreateSessionURL, songJson);

        yield return request.SendWebRequest();

        if(request.result == UnityWebRequest.Result.Success)
        {
            GameSessionWebData data = JsonUtility.FromJson<GameSessionWebData>(request.downloadHandler.text);
            CurrentGameSession.ID = data.idGameSession;
            CurrentGameSession.MusicName = _musicHolder.GetMusic().Name;

            Logger.Log(this, "Session Created");
            Logger.Log(this, $"Now session with id {data.idGameSession} is playing song with id {_song.idSong}");
            OnSetupFinished?.Invoke();
        }
        else
        {
            Logger.Log(this, request.error);

            if (FindObjectOfType<ErrorSystem>() is ErrorSystem errorSystem)
                errorSystem.ThrowError(new InGameError(request.error));
        }
    }

    public IEnumerator EndSessionCoroutine()
    {
        yield return null;
    }
}