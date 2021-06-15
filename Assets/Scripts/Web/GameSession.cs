using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class GameSession : MonoBehaviour
{
    private string _id;

    private string _userId;
    private string _songId;
    private int _pontuation;

    public event Action OnSetupFinished;

    private class Data
    {
        public string idSong = "afdf2ebf-a371-45b9-98e6-eb42129e410c";
        public string idUser = "562e354d-772b-492a-8c28-ce7d29735324";
    }

    private void Start()
    {
        string songId = "afdf2ebf-a371-45b9-98e6-eb42129e410c";// songId;
        string userId = "562e354d-772b-492a-8c28-ce7d29735324";//id;

        Setup(songId, userId);
    }

    public void Setup(string songId, string user)
    {
        _songId = "afdf2ebf-a371-45b9-98e6-eb42129e410c";// songId;
        _userId = "562e354d-772b-492a-8c28-ce7d29735324";//id;

        StopAllCoroutines();
        StartCoroutine(SendDataCoroutine(_songId, _userId));
    }

    private void SetGameSessionId(DownloadHandler downloadHandler)
    {
        string str = downloadHandler.text.Split(':')[1];
        str = str.Substring(1, str.Length - 3);
        _id = str;
    }

    IEnumerator SendDataCoroutine(string songId, string userId)
    {
        Debug.Log("[GameSession]: Solicitou requisição");

        string json = JsonUtility.ToJson(new Data());

        var request = WebRequest.Post(WebConstants.URL.CreateSessionURL, json);

        yield return request.SendWebRequest();

        string status = request.result == UnityWebRequest.Result.Success ? "Session Created" : request.error;

        if(request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("[GameSession]: " + "Session Created");
            SetGameSessionId(request.downloadHandler);
            OnSetupFinished?.Invoke();
        }
        else
        {
            Debug.Log("[GameSession]: " + request.error);
        }
    }

    public string UserId { get => _userId;}
    public string SongId { get => _songId;}
    public int Pontuation { get => _pontuation;}
    public string Id { get => _id;}
}