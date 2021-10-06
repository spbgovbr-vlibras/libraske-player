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
    public int idGameSession;
}


public class GameSession : MonoBehaviour, ILoggable
{
    [SerializeField] private MusicHolderSO _musicHolder;

    public event Action OnSetupFinished;

    private GameSessionWebData _data;
    private MusicWebData _song;

    public string Id { get => _data.idGameSession.ToString(); }
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
            _data = JsonUtility.FromJson<GameSessionWebData>(request.downloadHandler.text);
            Logger.Log(this, "Session Created");
            Logger.Log(this, $"Now session with id {_data.idGameSession} is playing song with id {_song.idSong}");
            OnSetupFinished?.Invoke();
        }
        else
        {
            Logger.Log(this, request.error);

            if (FindObjectOfType<ErrorSystem>() is ErrorSystem errorSystem)
                errorSystem.ThrowError(new InGameError(request.error));
        }
    }
}