using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class RequestMusicFromURL : MonoBehaviour, ILoggable
{
    public string InLogName => "RequestMusicFromURL";

    [SerializeField] MusicHolderSO _musicHolder;
    [SerializeField] AudioHandler _audioHandler;
    [SerializeField] string _debugUrl;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DownloadMusic(_debugUrl));
    }

    private IEnumerator DownloadMusic(string url)
    {
        var request = WebRequestFormater.GetAudioClip(url);
        yield return request.SendWebRequest();

        if(request.result != UnityWebRequest.Result.Success)
        {
            Logger.Log(this, "Erro ao baixar música em" + url);

            if(FindObjectOfType<ErrorSystem>() is ErrorSystem es)
            {
                es.ThrowError(ErrorList.MusicDownloadError);
            }
        }
        else
        {
            AudioClip clip = DownloadHandlerAudioClip.GetContent(request);
            _audioHandler.SetClip(clip);
            _audioHandler.Play();
        }
    }
}