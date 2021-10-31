using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;


public class CreateGameSessionRequest : MonoBehaviour, ILoggable
{
    [SerializeField] private MusicDataHolderSO _musicHolder;

    public event Action OnSetupFinished;
    private MusicWebData _song;

    public string InLogName { get => "CreateGameSessionRequest"; }

    private void Start()
    {
        StopAllCoroutines();
        StartCoroutine(CreateSessionCoroutine());
    }

    IEnumerator CreateSessionCoroutine()
    {
        Logger.Log(this, "Solicitou requisição");

        _song.idSong = _musicHolder.GetMusicData().Id;
        string songJson = JsonUtility.ToJson(_song);

        var request = WebRequestFormater.Post(WebConstants.URL.CreateSessionURL, songJson);

        yield return request.SendWebRequest();

        if(request.result == UnityWebRequest.Result.Success)
        {
            GameSessionWebData data = JsonUtility.FromJson<GameSessionWebData>(request.downloadHandler.text);
            CurrentGameSession.ID = data.idGameSession;
            CurrentGameSession.MusicName = _musicHolder.GetMusicData().Name;

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

        request.Dispose();
    }
}