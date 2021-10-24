﻿using Lavid.Libraske.DataStruct;
using Lavid.Libraske.Json;
using Lavid.Libraske.Web;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RequestMusicList : MonoBehaviour, ILoggable
{
    [SerializeField] private MusicMenu _musicMenu;
    [SerializeField] private Wrapper<Music> _songs;

    public string InLogName => "RequestMusics";

    void OnEnable()
    {
       StartCoroutine(RequestMusicsCoroutine());
    }

    void OnDestroy() => StopAllCoroutines();

    IEnumerator RequestMusicsCoroutine()
    {
        Logger.Log(this, "Solicitou requisição das músicas");

        var webRequest =  WebRequestFormater.Get(WebConstants.URL.SongsURL);
 
        yield return webRequest.SendWebRequest();

        if(webRequest.result == UnityWebRequest.Result.Success)
        {
            Logger.Log(this, ":\nRecebeu: " + webRequest.downloadHandler.text);
            SetDataToArray(webRequest);
        }
        else
        {
            Logger.Log(this, webRequest.error);
            FindObjectOfType<ErrorSystem>().ThrowError(new InGameError(webRequest.error));
        }
    }

    private void SetDataToArray(UnityWebRequest webRequest)
    {
        try
        {
            _songs = JsonArray.FromJson<Music>(webRequest.downloadHandler.text);
            _musicMenu.SetMusics(_songs);
        }
        catch
        {
            Logger.Log(this, "Faile to cast Music to Wrapper");
            if (FindObjectOfType<ErrorSystem>() is ErrorSystem es)
                es.ThrowError(ErrorList.BundleDownloadError);
        }
    }
}