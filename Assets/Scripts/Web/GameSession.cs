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
        public string idSong = "bd74237d-6c89-4f77-9800-667bc3cc2208";//"afdf2ebf-a371-45b9-98e6-eb42129e410c";
        //public string idUser = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJjcGYiOiIxMjM0NTY3ODkwMCIsImlhdCI6MTYzMDAyMDIxMSwiZXhwIjoxNjMwMTA2NjExfQ.sgoEOTlbm1v-JwMxAcFfPgN7RK88ZvOe1h8EPWOhRVY";
    }

    private void Start()
    {
        Setup();
    }

    public void Setup()
    {
        StopAllCoroutines();
        StartCoroutine(SendDataCoroutine());
    }

    private void SetGameSessionId(DownloadHandler downloadHandler)
    {
        string str = downloadHandler.text.Split(':')[1];
        str = str.Substring(1, str.Length - 3);
        _id = str;
    }

    IEnumerator SendDataCoroutine()
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