﻿using Lavid.Libraske.DataStruct;
using Lavid.Libraske.Json;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RequestSongs : MonoBehaviour
{
    [SerializeField] private MusicMenu _musicMenu;
    [SerializeField] private Wrapper<Music> _songs;

    void Start()
    {
        StartCoroutine(GetRequestCoroutine(WebConstants.URL.SongsURL));
    }

    IEnumerator GetRequestCoroutine(WebConstants.URL url)
    {
        Debug.Log("[RequestSongs]:  Solicitou requisição das músicas");

        var webRequest =  WebRequest.Get(url);

        Debug.Log(WebConstants.GetString(url));
 
        yield return webRequest.SendWebRequest();

        switch (webRequest.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                FindObjectOfType<ErrorSystem>().ThrowError(ErrorList.DefaultError);
                Debug.LogError("[RequestSongs]:  " + webRequest.error + " at " + url);
                break;
            case UnityWebRequest.Result.ProtocolError:
                FindObjectOfType<ErrorSystem>(true).ThrowError(new InGameError(webRequest.error));
                //Debug.LogError("[RequestSongs]:  " + webRequest.error);
                break;
            case UnityWebRequest.Result.Success:
                Debug.Log("[RequestSongs]:  " + ":\nReceived: " + webRequest.downloadHandler.text);

                try
                {
                    _songs = JsonArray.FromJson<Music>(webRequest.downloadHandler.text);
                    _musicMenu.SetMusics(_songs);
                }
                catch
                {
                    Debug.LogError("[RequestSongs]:  Faile to cast Music to Array");
                }

                break;
        }   
    }
}