using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RequestSongs : MonoBehaviour
{
    private Song[] _songs;

    void Start()
    {
        StartCoroutine(GetRequestCoroutine(WebConstants.URL.SongsURL));
    }

    IEnumerator GetRequestCoroutine(WebConstants.URL url)
    {
        Debug.Log("[RequestSongs]:  Solicitou requisição das músicas");

        var webRequest = WebRequest.Get(url);
 
        yield return webRequest.SendWebRequest();

        switch (webRequest.result)
        {
            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.LogError("[RequestSongs]:  " + ": Error: " + webRequest.error);
                break;
            case UnityWebRequest.Result.ProtocolError:
                Debug.LogError("[RequestSongs]:  " + ": HTTP Error: " + webRequest.error);
                break;
            case UnityWebRequest.Result.Success:
                Debug.Log("[RequestSongs]:  " + ":\nReceived: " + webRequest.downloadHandler.text);
                break;
        }   
    }
}